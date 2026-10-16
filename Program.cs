using System.Xml.Serialization;

namespace quiz_maker;

class Program
{
    const int MODE_ONE = 1;
    const int MODE_TWO = 2;

    static void Main(string[] args)
    {
        Quiz quiz = new Quiz();
        quiz.Questions = new List<Question>();
        int score = 0;

        Random random = new Random();

        bool addAnotherQuestion = true;

        Console.WriteLine("###### Let the games begin! ######");
        Console.WriteLine("Choose a mode:");
        Console.WriteLine("1 - Create a quiz");
        Console.WriteLine("2 - Play a quiz");


        int mode = int.Parse(Console.ReadLine());

        if (mode <MODE_ONE || mode > MODE_TWO)
        {
            return;
        }

        if (MODE_ONE == mode)
        {
            GameMode.CreatQuiz(addAnotherQuestion, quiz);
        }

        if (MODE_TWO == mode)
        {
            GameMode.PlayQuiz(score, quiz, random);
        }
    }
}