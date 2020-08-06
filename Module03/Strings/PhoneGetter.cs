using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Strings
{
    public static class PhoneGetter
    {
        public static void RewriteNumbers(string readFrom, string writeTo)
        {
            StreamReader streamRead = new StreamReader(readFrom);
            string text = streamRead.ReadToEnd();

            string[] patterns = { @"\d{1} \d{3} \d{3}-\d{2}-\d{2}", @"[+]\d{3} [(]\d{2}[)] \d{3}-\d{4}", @"[+]\d{1} [(]\d{3}[)] \d{3}-\d{2}-\d{2}" };

            using (StreamWriter streamWrite = new StreamWriter(new FileStream(writeTo, FileMode.Open, FileAccess.Write)))
            { 
                (streamWrite.BaseStream).Seek(0, SeekOrigin.End);
                foreach (var pattern in patterns)
                {
                    var match = Regex.Match(text, pattern);
                    if (match.Success) streamWrite.WriteLine(match.Value);
                }
            }
            Console.ReadKey();
        }
    }
}
