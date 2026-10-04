namespace quiz_maker;

class Program
{
    static void Main(string[] args)
    {
        Quiz quiz = new Quiz();
        quiz.Questions = new List<Question>();

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

    }
}