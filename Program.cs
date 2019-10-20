using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Panda3
{
    class Program
    {
        /// <summary>
        /// local path to downloaded file
        /// </summary>
        public static string LocalFilePath = "5.txt";
        public static string WebFilePath = "https://s3.zylowski.net/public/input/5.txt";

        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("1. Pobierz plik z internetu.");
                Console.WriteLine("2. Zlicz liczbę samoglosek w pobranym pliku.");
                Console.WriteLine("3. Zlicz liczbę społglosek w pobranym pliku.");
                Console.WriteLine("4. Zlicz liczbę wyrazów w pliku.");
                Console.WriteLine("5. Zlicz liczbę znaków interpunkcyjnych w pliku.");
                Console.WriteLine("6. Zlicz liczbę zdań w pliku.");
                Console.WriteLine("7. Wygeneruj raport o użyciu liter (A-Z).");
                Console.WriteLine("8. Zapisz statystyki z punktów 2-5 do pliku statystyki.txt .");
                Console.WriteLine("9. Exit");
                int menuOption = Convert.ToInt32(Console.ReadLine());

                if(menuOption == 1)
                {
                    string fileContent = HttpHelper.GetContent(WebFilePath);
                    File.WriteAllText(LocalFilePath, fileContent);
                }
                else if (menuOption == 2)
                {
                    if (File.Exists(LocalFilePath))
                    {
                        string s = File.ReadAllText(LocalFilePath);
                        Console.WriteLine("Number of vowels: {0}", StringHelper.CountVowels(s));                      
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        break;
                    }
                }
                else if (menuOption == 3)
                {
                    if (File.Exists(LocalFilePath))
                    {
                        string s = File.ReadAllText(LocalFilePath);
                        Console.WriteLine("Number of constrants: {0}", StringHelper.CountConstatnts(s));
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        break;
                    }
                }
                else if(menuOption == 4)
                {
                    if (File.Exists(LocalFilePath)) 
                    {
                        string s = File.ReadAllText(LocalFilePath);
                        Console.WriteLine("Number of words: {0}", StringHelper.CountWords(s));
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        break;
                    }
                }                
                else if (menuOption == 5)
                {
                    if (File.Exists(LocalFilePath))
                    {
                        string s = File.ReadAllText(LocalFilePath);
                        Console.WriteLine("Numer of punctuation marks: {0}", StringHelper.CountPunctuationMark(s));
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        break;
                    }
                }
                else if (menuOption == 6)
                {
                    if (File.Exists(LocalFilePath))
                    {
                        string s = File.ReadAllText(LocalFilePath);
                        Console.WriteLine("Numer of sentenses: {0}", StringHelper.CountSentenses(s));
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        break;
                    }
                }
                else if (menuOption == 7)
                {
                    if (File.Exists(LocalFilePath))
                    {
                        string s = File.ReadAllText(LocalFilePath);
                        int[] c = StringHelper.CountDiffLetters(s);

                        for (int i = 0; i < (int)char.MaxValue; i++)
                        {
                            if (c[i] > 0 && char.IsLetter((char)i))
                            {
                                Console.WriteLine("{0} :{1}", (char)i, c[i]);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        break;
                    }
                }
                else if (menuOption == 8)
                {
                    if (File.Exists(LocalFilePath))
                    {
                        string s = File.ReadAllText(LocalFilePath);
                        Statistics.CreateStatistic(s);
                        Console.WriteLine("Statistics has been wroten in statystyki.txt");
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                        Statistics.CreateStatistic(null);
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        break;
                    }
                }
                else if (menuOption == 9)
                {
                    break;
                }
            }
        }
    }
}