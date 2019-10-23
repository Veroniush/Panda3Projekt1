using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace Panda3
{
    class Program
    {
        /// <summary>
        /// local path to downloaded file
        /// </summary>
        public static string LocalFilePath = "5.txt";
        //public static string WebFilePath = "https://s3.zylowski.net/public/input/5.txt";

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
                Console.WriteLine("7. Wygeneruj raport o użyciu liter (A-Z) oraz liczbe zdań i wyrazów.");
                Console.WriteLine("8. Zapisz statystyki z punktów 2-5 do pliku statystyki.txt .");
                Console.WriteLine("9. Exit");

                int menuOption = Convert.ToInt32(Console.ReadLine());

                if (menuOption == 1)
                {
                    Console.WriteLine("Czy pobrać plik z internetu? [T/N]");
                    char choise = Console.ReadKey().KeyChar;

                    if (choise == 'T' || choise == 't')
                    {
                        Console.WriteLine("Podaj ścieżkę pliku");
                        string filepath = Console.ReadLine();

                        WebClient webClient = new WebClient();
                        try
                        {
                            webClient.DownloadFile(filepath, "5.txt");
                            LocalFilePath = "5.txt";
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Podaj prawidłowe dane");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Podaj nazwę pliku");
                        string nametxt = Convert.ToString(Console.ReadLine());
                        if (File.Exists(nametxt))
                        {
                            LocalFilePath = nametxt;
                        }
                        else
                        {
                            Console.WriteLine("Plik nie istnieje.");
                        }
                    }
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
                else if (menuOption == 4)
                {
                    if (File.Exists(LocalFilePath))
                    {
                        string s = File.ReadAllText(LocalFilePath);
                        Console.WriteLine("Number of words: {0}", StringHelper.CountWordsWithout1letterWords(s));
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

                        string vs = s.Replace("<", "").Replace(",", "").Replace(":", "").Replace(";", "").Replace("'", "").Replace("!","").Replace(">","");
                        Console.WriteLine("Numer of punctuation marks: {0}", StringHelper.CountPunctuationMark(vs));
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
                    if (File.Exists("5.txt"))
                    {
                        try
                        {
                            File.Delete("5.txt");
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine(e.Message);    
                        }
                    }

                    if (File.Exists(Statistics.StatisticsFilePath))
                    {
                        try
                        {
                            System.IO.File.Delete(Statistics.StatisticsFilePath);
                        }
                        catch (IOException a)
                        {
                            Console.WriteLine(a.Message);                         
                        }
                    }
                    return;
                }
            }
        }
    }
}
