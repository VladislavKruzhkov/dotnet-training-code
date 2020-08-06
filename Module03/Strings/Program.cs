using System;

namespace Strings
{
    public class Program
    {
        public static void TaskTwoDemonstration(string sentence)
        {
            Console.WriteLine($"Average length of words in sentence *{sentence}* is {AverageWordLength.GetAverageWordLength(sentence)}");
        }

        public static void TaskThreeDemonstration(string sentence1, string sentence2)
        {
            Console.WriteLine($"Before doubling the letters: {sentence1}, {sentence2}");
            sentence1 = DoubleLetters.DoubleCommonLetters(sentence1, sentence2);
            Console.WriteLine($"After doubling the letters: {sentence1}");
        }

        public static void Main(string[] args)
        {
            TaskTwoDemonstration("Sasha,Tanya Grisha Nastya.Ivann,    Kolyan");
            
            TaskThreeDemonstration("omg i love shrek", "o kek");
           
            Console.WriteLine(Summator.Sum("413457438957943758943795784598734985794837598735439875398547", "18678347583475983475893478957348975934875984375893475843797"));
           
            Console.WriteLine(SentenceReverser.ReverseWords("The greatest victory is that which requires no battle"));

            PhoneGetter.RewriteNumbers(@"C:\EPAM\Module03\Strings\Text.txt", @"C:\EPAM\Module03\Strings\Numbers.txt");

            Console.ReadKey();
        }
    }
}
