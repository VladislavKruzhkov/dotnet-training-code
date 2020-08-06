using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strings
{
    public static class DoubleLetters
    {
        public static string[] SplitSentence(string sentence)
        {
            char[] delimiters = { ' ', '.', '!', '?', ',', ';', ':', '-', '"', '(', ')' };
            string[] sentenceToWords = sentence.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return sentenceToWords;
        }

        public static string RemoveDelimiters(string sentenceTwo)
        {
            var sentenceTwoToWords = SplitSentence(sentenceTwo);
            string sentenceTwoNoDelimiters = String.Empty;
            foreach (var word in sentenceTwoToWords)
            {
                sentenceTwoNoDelimiters += word;
            }
            return sentenceTwoNoDelimiters;
        }

        public static string DoubleCommonLetters(string sentenceOne, string sentenceTwo)
        {
            if (sentenceOne == null)
                throw new ArgumentNullException(nameof(sentenceOne));
            if (sentenceTwo == null)
                throw new ArgumentNullException(nameof(sentenceTwo));

            string sentenceTwoNoDelimiters = RemoveDelimiters(sentenceTwo);
            HashSet<char> sentenceTwoToChars = sentenceTwoNoDelimiters.ToHashSet();

            StringBuilder sentenceOneBuilder = new StringBuilder(sentenceOne);

            for (var letterSentenceOne = 0; letterSentenceOne < sentenceOneBuilder.Length; letterSentenceOne++)
            {
                if (sentenceTwoToChars.Contains(sentenceOneBuilder[letterSentenceOne]))
                {
                    sentenceOneBuilder = sentenceOneBuilder.Insert(letterSentenceOne, sentenceOneBuilder[letterSentenceOne]);
                    letterSentenceOne++;
                }
            }
            return sentenceOneBuilder.ToString();
        }
    }
}
