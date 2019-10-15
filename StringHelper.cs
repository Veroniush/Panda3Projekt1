using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Panda3
{
    /// <summary>
    /// helper class for operatios on text
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// function to count punctional marks in text
        /// problem with ...
        /// </summary>
        public static int CountPunctuationMark(string text)
        {
            char[] chars = text.ToCharArray();
            int numberOfPunctuationMarks = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsPunctuation(chars[i]) == true)
                {
                    if (chars[i] == '.' && i < chars.Length - 2)
                    {
                        if (chars[i + 1] == '.' && chars[i + 2] == '.')
                        {
                            numberOfPunctuationMarks = numberOfPunctuationMarks + 1;
                            i = i + 2;
                        }
                        else
                        {
                            numberOfPunctuationMarks = numberOfPunctuationMarks + 1;
                        }
                    }
                    else
                    {
                        numberOfPunctuationMarks = numberOfPunctuationMarks + 1;
                    }

                }

            }

            return numberOfPunctuationMarks;
        }

        public static int CountSentenses(string text)
        {
            string[] sentenses = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return sentenses.Length;
        }

    }
}
