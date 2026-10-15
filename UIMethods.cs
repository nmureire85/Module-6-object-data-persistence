namespace quiz_maker;

public class UIMethods
{
    public static String GetQuestion()
    {
        Console.WriteLine("Enter a question:");
        return Console.ReadLine();
    }

    public static String GetNumberOfAnswers()
    {
        Console.WriteLine("How many answers would you like?");
        return Console.ReadLine();
    }

    public static String GetAnAnswer()
    {
        Console.WriteLine("Enter an answer:");
        return Console.ReadLine();
    }

    public static String GetCorrectAnswerYesorNo()
    {
        Console.WriteLine("Is this answer correct? (y/n)");
        return Console.ReadLine();
    }

    public static void PrintEnterAValidNumber()
    {
        Console.WriteLine("Please enter a valid number.");
    }

    public static String GetAnotherQuestion()
    {
        Console.WriteLine("Do you want to add another question? (y/n)");
        return Console.ReadLine();
    }

    public static void DisplayQuestionAndAnswers(Question question)
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


    public static int GetAnswerChoice(int numberOfAnswers)
    {
        Console.Write("Choose your answer: ");

        int answerChoice;

        while (!int.TryParse(Console.ReadLine(), out answerChoice) ||
               answerChoice < 1 ||
               answerChoice > numberOfAnswers)
        {
            Console.WriteLine("Invalid choice. Please enter a valid answer number.");
            Console.Write("Choose your answer: ");
        }

        return answerChoice;
    }

    public static void PrintScore(int score)
    {
        Console.WriteLine($"Current score: {score}");
    }

    public static void PrintAnswerIsCorrect()
    {
        Console.WriteLine("Correct!");
        Console.WriteLine();
    }

    public static void PrintAnswerIsIncorrect()
    {
        Console.WriteLine("Incorrect!");
        Console.WriteLine();
    }

    public static void DisplayFinalScore(int score, Quiz quiz)
    {
        Console.WriteLine();
        Console.WriteLine("Quiz completed!");
        Console.WriteLine($"Your final score is {score}/{quiz.Questions.Count}");
    }
}