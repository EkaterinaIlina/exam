using System;
using System.Collections.Generic;
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
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        static private void FillAutos()
        {
                for (int i = 0; i <= n; i++)
                {
                    Autos[i] = new Auto();
                    Console.WriteLine($"Введите марку автомобиля {0}: ", i);
                    Autos[i].Mark = Console.ReadLine();
                    Console.WriteLine($"Введите модель автомобиля {0}: ", i);
                    Autos[i].Model = Console.ReadLine();
                    Console.WriteLine($"Введите цену автомобиля {0}: ", i);
                    string read = Console.ReadLine();
                bool Read = read.AsEnumerable().Any(ch => char.IsLetter(ch));
                if (!Read)
                    Autos[i].Price = Convert.ToDecimal(read);
                else
                {
                    Console.WriteLine("Цена не должно содержать буквы");
                }
                while (Read) ;
                }

        }
    }
}
