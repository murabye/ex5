using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace ex5
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("Введите матрицу построчно через пробелы: ");
                var first = Console.ReadLine();
                if (first == "")
                {
                    Console.WriteLine("Неверный ввод: ");
                    continue;
                }

                var count = first.Split(' ').Length;

            }
        }
    }
}
