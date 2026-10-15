using System.Xml.Serialization;

namespace quiz_maker;

public class QuizFileManager
{
    static XmlSerializer serializer = new XmlSerializer(typeof(Quiz));

    public static void SaveQuiz(Quiz quiz, String path)
    {
        using (FileStream file = File.Create(path))
        {
            serializer.Serialize(file, quiz);
        }
    }

    public static Quiz LoadQuiz(string path)
    {
        using (FileStream file = File.OpenRead(path))
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