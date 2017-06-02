using System;
using MyLib;

// дважды ошибка

namespace ex5
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                var str = Ask.Word("Введите матрицу построчно через пробелы: \n");

                // по первой строке инициализируем порядок матрицы
                // инициализируем матрицу по полученным данным

                var count = str.Split(' ').Length;
                var matrix = new int[count][];

                // попытка расщифровки
                try
                {
                    // первая (уже заполненная) строка
                    matrix[0] = ToArr(str, count);

                    // дешифровка всех оставшихся строк
                    for (var i = 1; i < count; i++)
                    {
                        str = Console.ReadLine();
                        matrix[i] = ToArr(str, count);
                    }
                }
                catch (AggregateException e)
                {
                    // если встречена ошибка, то выписать
                    Console.WriteLine(e);
                    continue;
                }

                // если строка четная, то выписать
                Console.Write("Четные строки: ");
                for (var i = 0; i < count; i++)
                {
                    if (IsEven(matrix[i]))
                        Console.Write(" " + i);
                }

                OC.Stay();

            }
        }

        static int[] ToArr(string str, int count)
        {
            // функция для перевода из строки с цифрами в одномерный массив

            var arr = new int[count];
            var nums = str.Split(' ');

            // если недостаточно, то
            if (nums.Length != count)
                throw new AggregateException("Недостаточно цифр в строке матрицы");

            for (var i = 0; i < count; i++)
            {
                if (!int.TryParse(nums[i], out arr[i]))
                    throw new AggregateException("Неверно введено число");
            }

            return arr;
        }
        static bool IsEven(int[] arr)
        {
            var ans = true;
            foreach (var num in arr)
                ans = ans && (num % 2 == 0);

            return ans;
        }
    }
}
