using System;

namespace Strings
{
    public static class AverageWordLength
    {
        public static double GetAverageWordLength(string sentence)
        {
            if (sentence == null)
                throw new ArgumentNullException(nameof(sentence));
            
            string[] words = DoubleLetters.SplitSentence(sentence);

            if (words.Length == 0) return 0;

            double sumOfLettersInWords = 0;
            foreach (var word in words)
                sumOfLettersInWords += word.Length;

            return sumOfLettersInWords / words.Length;
        }
    }
}