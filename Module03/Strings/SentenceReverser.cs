using System;
using System.Text;

namespace Strings
{
    public static class SentenceReverser
    {
        public static string ReverseWords(string sentence)
        {
            if (sentence == null)
                throw new ArgumentNullException(nameof(sentence));

            string[] words = sentence.Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder reversedSentence = new StringBuilder();

            for (var word = words.Length - 1; word >= 0; word--)
            {
                if (word == 0) reversedSentence = reversedSentence.Append(words[word]);
                else reversedSentence = reversedSentence.Append(words[word] + " ");
            }

            return reversedSentence.ToString();
        }
    }
}
