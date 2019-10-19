using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panda3
{
    public class Statistics
    {
        public static string StatisticsFilePath = "statystiki.txt";
        /// <summary>
        /// functionality to write statistics in file statystiki.txt
        /// </summary>
        public static void CreateStatistic(string text)
        {
            List<string> lines = new List<string>();

            if(text == null)
            {
                lines.Add("File doesn't exist");
            }
            else
            {
                lines.Add("Number of letters: " + StringHelper.CountLetters(text).ToString());
                lines.Add("Number of words: " + StringHelper.CountWords(text).ToString());
                lines.Add("Numer of punctuation marks: " + StringHelper.CountPunctuationMark(text).ToString());
                lines.Add("Numer of sentenses: " + StringHelper.CountSentenses(text).ToString());
            }

            File.WriteAllLines(StatisticsFilePath, lines);
        }
    }
}
