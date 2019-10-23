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
        /// function for counting sentences with '.' and '?'
        /// </summary>
        public static int CountSentenses(string text)
        {
            string[] sentenses = text.Split(new char[] { '.', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return sentenses.Length;
        }

        /// <summary>
        /// function for counting letters
        /// </summary>
        public static int CountVowels(string text)
        {
            char[] chars = text.ToCharArray();
            int numberOfVowes = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (
                    char.IsLetter(chars[i]) == true
                    && (chars[i].ToString().ToLower() == "a" || chars[i].ToString().ToLower() == "e" || chars[i].ToString().ToLower() == "i"
                        || chars[i].ToString().ToLower() == "o" || chars[i].ToString().ToLower() == "u" || chars[i].ToString().ToLower() == "y")
                   )
                {
                    numberOfVowes = numberOfVowes + 1;
                }
            }
            return numberOfVowes;
        }

        public static int CountConstatnts(string text)
        {
            char[] chars = text.ToCharArray();
            int numberOfLetters = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(chars[i]) == true)
                {
                    numberOfLetters = numberOfLetters + 1;
                }
            }
            return numberOfLetters - StringHelper.CountVowels(text);
        }

        public static int CountWordsWithout1letterWords(string text)
        {
            char[] chars = text.ToCharArray();
            string newText = "";
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsPunctuation(chars[i]) != true && char.IsDigit(chars[i]) != true && char.IsWhiteSpace(chars[i]) != true)
                {
                    newText = newText + chars[i].ToString();
                }
                else
                {
                    newText = newText + " ";
                }
            }
            string[] words = newText.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            int numberOfWords = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 1)
                {
                    numberOfWords++;
                }
            }
            return numberOfWords;
        }

        public static int[] CountDiffLetters(string text)
        {
            int[] c = new int[(int)char.MaxValue];

            foreach (char t in text)
            {
                c[(int)t]++;
            }

            return c;
        }
    }
}