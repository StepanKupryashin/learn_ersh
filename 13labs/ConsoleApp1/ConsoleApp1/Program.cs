using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Заполните динамическую матрицу 40×50 целыми случайными
//числами от –3 до 2. Найдите среднее арифметическое всех элементов этой матрицы. Зная точное значение данной величины
//(
//2-(-3)/2
//), вычислите ее относительную погрешность (в процентах)
//по формуле:
//100 % *(ТочноеЗначение – ПриблЗначение) / ДлинаДиапазона
//Замечания:
//1.Количество целых чисел в диапазоне от –3 до 2 равно 2 –
//(–3) +1 = 6.
//161
//2.Чтобы напечатать символ %, используйте в функции printf
//спецификатор «%%».



namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int Width, Height;
            int MinD, MaxD;
            double total = 0;
            Console.WriteLine($"Введите ширину матрицы:");
            Width = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"Введите высоту матрицы:");
            Height = Convert.ToInt16(Console.ReadLine());
            int[,] array = new int [Width, Height];

            Random randomise = new Random();

            Console.WriteLine($"Введите начало диапазона");
            MinD = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"Введите конец диапазона");
            MaxD = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"Матрица со случайными числами:");

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    array[i, j] = randomise.Next(MinD, MaxD);
                    Console.Write(array[i, j] + "\t");
                    total += array[i, j];
                }
              
            }
            //int diap = MaxD - MinD;
            //double AAA = (2 - (-3)) / 2;
            double arithmetic = total / array.Length;
            Console.WriteLine($"\nСреднее арифметическое всех элементов: {arithmetic}");
            double percent = 100 * (2.5 - arithmetic) / 6;
            Console.WriteLine($"\nПогрешность: {percent} %" );
            Console.ReadLine();
        }
    }
}
