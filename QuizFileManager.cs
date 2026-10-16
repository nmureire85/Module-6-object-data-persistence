using System.Xml.Serialization;

namespace quiz_maker;

public class QuizFileManager
{
    const string RELATIVE_PATH = @"../../../quiz.xml";
    static XmlSerializer serializer = new XmlSerializer(typeof(Quiz));

    public static void SaveQuiz(Quiz quiz)
    {
        using (FileStream file = File.Create(RELATIVE_PATH))
        {
            serializer.Serialize(file, quiz);
        }
    }

    public static Quiz LoadQuiz()
    {
        using (FileStream file = File.OpenRead(RELATIVE_PATH))
        {
            Quiz quiz = (Quiz)serializer.Deserialize(file)!;
            return quiz;
        }
    }
    
    public static int GetNumberOfAnswers()
    {
        int numberOfAnswers;

        while (!int.TryParse(Console.ReadLine(), out numberOfAnswers) ||
               numberOfAnswers < 1)
        {
            Console.WriteLine("Please enter a valid positive number.");
        }

        return numberOfAnswers;
    }
    
}