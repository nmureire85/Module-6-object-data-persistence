namespace quiz_maker;

public class GameMode
{
    const string RELATIVE_PATH = @"../../../quiz.xml";

    public static void CreatQuiz(bool addAnotherQuestion, Quiz quiz)
    {
        while (addAnotherQuestion)
        {
            Question question = new Question();
            question.Text = UIMethods.GetQuestion();
            question.Answers = new List<Answer>();
            int numberOfAnswers = Convert.ToInt32(UIMethods.GetNumberOfAnswers());

            for (int i = 0; i < numberOfAnswers; i++)
            {
                Answer answer = new Answer();
                answer.Text = UIMethods.GetAnAnswer();

                string correctAnswer = UIMethods.GetCorrectAnswerYesorNo();

                answer.IsCorrect = correctAnswer == "y";

                question.Answers.Add(answer);
            }

            quiz.Questions.Add(question);


            string anotherQuestion = UIMethods.GetAnotherQuestion();

            addAnotherQuestion = anotherQuestion == "y";
        }
        
        QuizFileManager.SaveQuiz(quiz);
    }

    public static void PlayQuiz(int score, Quiz quiz, Random random)
    {
        
        if (!File.Exists(RELATIVE_PATH))
        {
            Console.WriteLine("No quiz found. Please create a quiz first.");
            return;
        }
        quiz = QuizFileManager.LoadQuiz();
        List<Question> questionsToPlay = new List<Question>(quiz.Questions);
        while (questionsToPlay.Count > 0)
        {
            int questionIndex = random.Next(questionsToPlay.Count);

            Question question = questionsToPlay[questionIndex];
            questionsToPlay.RemoveAt(questionIndex);
            UIMethods.DisplayQuestionAndAnswers(question);
            int answerChoice = UIMethods.GetAnswerChoice(question.Answers.Count);
            Answer selectedAnswer = question.Answers[answerChoice - 1];
            if (selectedAnswer.IsCorrect)
            {
                UIMethods.PrintAnswerIsCorrect();
                score++;
            }
            else
            {
                UIMethods.PrintAnswerIsIncorrect();
            }

            UIMethods.PrintScore(score);
        }

        UIMethods.DisplayFinalScore(score, quiz); 
    }
}