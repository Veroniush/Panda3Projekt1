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

        /// <summary>
        /// function for counting sentenses
        /// </summary>
        public static int CountSentenses(string text)
        {
            string[] sentenses = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return sentenses.Length;
        }

        /// <summary>
        /// function for counting letters
        /// </summary>
        public static int CountLetters(string text)
        {
            char[] chars = text.ToCharArray();
            int numberOfLetters = 0;
            for(int i=0; i<text.Length; i++)
            {
                if(char.IsLetter(chars[i]) == true)
                {
                    numberOfLetters = numberOfLetters + 1;
                }
            }
            return numberOfLetters;
        }

        /// <summary>
        /// not implemented
        /// function for counting words
        /// </summary>
        public static int CountWords(string text)
        {
            return 0;
        }
    }
}
