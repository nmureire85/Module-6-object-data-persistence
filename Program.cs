using System.Xml.Serialization;

namespace quiz_maker;

class Program
{
    static void Main(string[] args)
    {
        Quiz quiz = new Quiz();
        quiz.Questions = new List<Question>();
        int score = 0;

        Random random = new Random();

        bool addAnotherQuestion = true;

        while (addAnotherQuestion)
        {
            Question question = new Question();

            Console.WriteLine("Enter a question:");
            question.Text = Console.ReadLine();

            question.Answers = new List<Answer>();

            Console.WriteLine("How many answers would you like?");
            int numberOfAnswers;
            while (!int.TryParse(Console.ReadLine(), out numberOfAnswers))
            {
                Console.WriteLine("Please enter a valid number.");
            }

            for (int i = 0; i < numberOfAnswers; i++)
            {
                Answer answer = new Answer();

                Console.WriteLine("Enter an answer:");
                answer.Text = Console.ReadLine();

                Console.WriteLine("Is this answer correct? (y/n)");
                string correctAnswer = Console.ReadLine();

                answer.IsCorrect = correctAnswer == "y";

                question.Answers.Add(answer);
                Console.WriteLine("Answer is correct? (y/n)");
            }

            quiz.Questions.Add(question);

            Console.WriteLine("Do you want to add another question? (y/n)");
            string anotherQuestion = Console.ReadLine();

            addAnotherQuestion = anotherQuestion == "y";
        }

        foreach (Question question in quiz.Questions)
        {
            Console.WriteLine(question.Text);

            int answerNumber = 1;

            foreach (Answer answer in question.Answers)
            {
                Console.WriteLine($"{answerNumber}. {answer.Text}");
                answerNumber++;
            }

            Console.WriteLine();
        }


        XmlSerializer serializer = new XmlSerializer(typeof(Quiz));
        string relativePath = @"../../../quiz.text";
        using (FileStream file = File.Create(relativePath))
        {
            serializer.Serialize(file, quiz);
        }


        using (FileStream file = File.OpenRead(relativePath))
        {
            quiz = (Quiz)serializer.Deserialize(file)!;
        }

        List<Question> questionsToPlay = new List<Question>(quiz.Questions);
        while (questionsToPlay.Count > 0)
        {
            Answer answer = new Answer();
            int questionIndex = random.Next(questionsToPlay.Count);

            Question question = questionsToPlay[questionIndex];

            questionsToPlay.RemoveAt(questionIndex);
            // Display the question
            Console.WriteLine();
            Console.WriteLine(question.Text);
            // Display answers here
            for (int i = 0; i < question.Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Answers[i].Text}");
            }

            // Get user's answer here
            Console.Write("Choose your answer: ");

            int answerChoice;
            while (!int.TryParse(Console.ReadLine(), out answerChoice) ||
                   answerChoice < 1 ||
                   answerChoice > question.Answers.Count)
            {
                Console.WriteLine("Invalid choice. Please enter a valid answer number.");
                Console.Write("Choose your answer: ");
            }

            // Get the selected answer from the list
            Answer selectedAnswer = question.Answers[answerChoice - 1];

            // Check if answer is correct
            if (selectedAnswer.IsCorrect)
            {
                Console.WriteLine("Correct!");

                // score++ if correct
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            Console.WriteLine($"Current score: {score}");
        }

        // Display final score
        Console.WriteLine();
        Console.WriteLine("Quiz completed!");
        Console.WriteLine($"Your final score is {score}/{quiz.Questions.Count}");
    }
}
