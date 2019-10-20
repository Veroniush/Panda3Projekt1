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
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("1. Pobierz plik z internetu.");
                Console.WriteLine("2. Zlicz liczbę liter w pobranym pliku.");
                Console.WriteLine("3. Zlicz liczbę wyrazów w pliku.");
                Console.WriteLine("4. Zlicz liczbę znaków interpunkcyjnych w pliku.");
                Console.WriteLine("5. Zlicz liczbę zdań w pliku.");
                Console.WriteLine("6. Wygeneruj raport o użyciu liter (A-Z).");
                Console.WriteLine("7. Zapisz statystyki z punktów 2-5 do pliku statystyki.txt .");
                Console.WriteLine("8. Exit");
                int menuOption = Convert.ToInt32(Console.ReadLine());

                if (menuOption == 1)
                {
                    WebClient webClient = new WebClient();
                    try
                    {
                        webClient.DownloadFile("https://s3.zylowski.net/public/input/5.txt?fbclid=IwAR1E-7Oh6St9e89VcEIQZ2zVyZhFoCY1fNK73fKvAtsanknNxUbbXVyCnMc", "5.txt");
                    }
                    catch (Exception e)
                    {
                        // some error
                    }
                }

                if (menuOption == 3)
                {
                    if (File.Exists("5.txt"))
                    {
                        string s = File.ReadAllText("5.txt");
                        Console.WriteLine("Number of words: {0}", StringHelper.CountWords(s));
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();

                    }

                    else
                    {
                        Console.WriteLine("File doesn't exist");
                        break;
                    }


                    if (menuOption == 8)
                    {
                        if (File.Exists("5.txt"))//directory 5.txt!
                        {

                            try
                            {
                                File.Delete("5.txt");//directory 5.txt!
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine(e.Message);


                                if (File.Exists("statistic.txt"))//directory statistic.txt!
                                {

                                    try
                                    {
                                        System.IO.File.Delete("statistic.txt");//directory statistic.txt!
                                    }
                                    catch (IOException a)
                                    {
                                        Console.WriteLine(a.Message);
                                        return;

                                        
                                    }

                                }
                            }
                        }
                    }
                }
                
                if (menuOption == 2)
                {
                    if (File.Exists("5.txt")) //directory 5.txt!
                    {
                        string s = File.ReadAllText("5.txt");
                        Console.WriteLine("Number of letters: {0}", StringHelper.Countwords(s));
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                        break;
                    }

                }
                if (menuOption == 6)
                {
                    if (File.Exists("5.txt")) //directory 5.txt!
                    {
                        int[] c = new int[(int)char.MaxValue];

                        string s = File.ReadAllText("5.txt");

              
                        foreach (char t in s)
                        {
                         
                            c[(int)t]++;
                        }

                     
                        for (int i = 0; i < (int)char.MaxValue; i++)
                        {
                            if (c[i] > 0 &&
                                char.IsLetterOrDigit((char)i))
                            {
                                Console.WriteLine("Letter: {0}  Frequency: {1}",
                                    (char)i,
                                    c[i]);
                            }
                        }
                        Console.WriteLine("File downloaded correctly.");

                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                        break;
                    }

                }
                if (menuOption == 4)
                {
                    if (File.Exists("5.txt"))
                    {
                        string s = File.ReadAllText("5.txt");

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
                if (menuOption == 5)
                {
                    if (File.Exists("5.txt"))
                    {
                        string s = File.ReadAllText("5.txt");
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

                if(menuOption == 7)
                {
                    if (File.Exists("5.txt"))
                    {
                        string s = File.ReadAllText("5.txt");
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
            }
        }
    }
}