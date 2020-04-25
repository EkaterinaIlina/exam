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
                    string mark = (Console.ReadLine());
                    while (string.IsNullOrEmpty(mark))
                    {
                    Console.WriteLine("Введите марку");
                    mark = Console.ReadLine();
                    }
                    Autos[i].Mark = mark;
                    Console.WriteLine(String.Format("Введите модель автомобиля {0}: ", i));
                    string model = Console.ReadLine();
                    while (string.IsNullOrEmpty(model))
                    {
                    Console.WriteLine("Введите модель");
                    model = Console.ReadLine();
                    }
                    Autos[i].Model = model;
                    Console.WriteLine(String.Format("Введите цену автомобиля {0}: ", i));
                    string priceS = Console.ReadLine();
                    while (string.IsNullOrEmpty(priceS))
                    {
                    Console.WriteLine("Введите цену");
                    priceS = Console.ReadLine();
                    }
                    int price;
                    while (!Int32.TryParse(priceS, out price))
                {
                    Console.WriteLine("Введите целое число");
                    priceS = Console.ReadLine();
                }
                Autos[i].Price = price;
                
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
                Console.WriteLine("Сохранено");
            }
        }
        static public void Sort()
        {
             Autos = Autos.AsQueryable<Auto>().OrderByDescending(c => c.Mark).ThenByDescending(c => c.Price).ToArray();
            Console.WriteLine("Отсортировано");
        }
    }
}
