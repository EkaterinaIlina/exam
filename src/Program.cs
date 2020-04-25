using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    class Program
    {
        private static int n;
        private static Auto[] Autos;

        private static string ParseString(string input)
        {
            if (input == "")
                return "Пустое значение";
            else
                return input;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите размер массива");
                string read = Console.ReadLine();
                while(!Int32.TryParse(read,out n))
                {
                    Console.WriteLine("Введите целое число");
                    read = Console.ReadLine();
                }
                Autos = new Auto[n];
                FillAutos();
                Sort();
                SaveInFile();
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        static private void FillAutos()
        {
                for (int i = 0; i < n; i++)
                {
                    Autos[i] = new Auto();
                    Console.WriteLine(String.Format("Введите марку автомобиля {0}: ", i));
                    string mark = ParseString(Console.ReadLine());
                    Autos[i].Mark = mark;
                    Console.WriteLine(String.Format("Введите модель автомобиля {0}: ", i));
                    string model = ParseString(Console.ReadLine());
                    Autos[i].Model = model;
                    Console.WriteLine(String.Format("Введите цену автомобиля {0}: ", i));
                bool Read;
                do
                {
                    string read = Console.ReadLine();

                    Read = read.AsEnumerable().Any(ch => char.IsLetter(ch));
                    if (!Read)
                        Autos[i].Price = Convert.ToDecimal(read);
                    else
                    {
                        Console.WriteLine("Цена не должна содержать буквы");
                        read = Console.ReadLine();
                    }
                }
                while (Read);
               
                }

        }
        static public void SaveInFile()
        {
            using (StreamWriter sw = new StreamWriter("file.txt"))
            {
                foreach(Auto a in Autos)
                {
                    sw.WriteLine(a.Mark + "; " + a.Model + "; " + a.Price + "; ");
                }
            }
        }
        static public void Sort()
        {
             Autos = Autos.AsQueryable<Auto>().OrderByDescending(c => c.Mark).ThenByDescending(c => c.Price).ToArray(); ;
        }
    }
}
