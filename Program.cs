using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                if (menuOption == 8)
                {
                    break;
                }
                if (menuOption == 2)
                {
                    if (File.Exists("5.txt")) //directory 5.txt!
                    {
                        int CharCount = 0;
                        string FilePath = "5.txt"; //check dir 5.txt
                        string FileText = new System.IO.StreamReader(FilePath).ReadToEnd().Replace("\r\n", "\r");
                        CharCount = FileText.Length;
                        Console.WriteLine("File downloaded correctly.");

                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                        break;
                    }

                }

            }
        }
    }
}