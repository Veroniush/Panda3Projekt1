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
        public static string WebFilePath = "https://s3.zylowski.net/public/input/5.txt";

        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("1. Wybierz plik wejściowy.");
                Console.WriteLine("2. Zlicz liczbę liter w pobranym pliku.");
                Console.WriteLine("3. Zlicz liczbę wyrazów w pliku.");
                Console.WriteLine("4. Zlicz liczbę znaków interpunkcyjnych w pliku.");
                Console.WriteLine("5. Zlicz liczbę zdań w pliku zakończonymi znakami interpunkcyjnymi.");
                Console.WriteLine("6. Wygeneruj raport o użyciu liter (A-Z).");
                Console.WriteLine("7. Zapisz statystyki z punktów 2-5 do pliku statystyki.txt .");
                Console.WriteLine("8. Exit");
                int menuOption = Convert.ToInt32(Console.ReadLine());

                if (menuOption == 1)
                {
                    Console.WriteLine("[T/N]");
                    char choise = Console.ReadKey().KeyChar;
                   if (choise== 'T' || choise == 't')
                    {
                        Console.WriteLine("Podaj ścieżkę pliku");
                        string filepath = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Podaj nazwę pliku");
                        string namefile = Convert.ToString(Console.ReadLine());
                        WebClient webClient = new WebClient();
                        try
                        {
                            webClient.DownloadFile(filepath, namefile);
                        }

                        catch (Exception e)
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


                            File.ReadAllText(nametxt);
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
                        Console.WriteLine("Number of letters: {0}", StringHelper.CountLetters(s));                      
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        break;
                    }
                }
                else if(menuOption == 3)
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
                else if (menuOption == 4)
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
                else if (menuOption == 5)
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
                else if (menuOption == 6)
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
                else if (menuOption == 7)
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
                else if (menuOption == 8)
                {
                    break;
                }
            }
        }
    }
}
