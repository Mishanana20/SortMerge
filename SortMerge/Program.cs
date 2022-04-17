///Сортировка слиянием (Merge sort) 
///исходная последовательность А разделяется на 2 меньшие части А1 и А2
///которые рекурсивно сортируются
///офигеть, сортировка раз в 100 быстрее чем прошлые методы
///


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[100000];
            for (int i = 99999; i >= 0; i--)
            {
                array[i] = 100000 - i;
            }

            Console.WriteLine(string.Join(",", array));
            Stopwatch stopwatch = new Stopwatch();
            //засекаем время начала операции
           
            
            Console.WriteLine(string.Join(",", SortMerge(array)));

            stopwatch.Start();
            int[] sortArray = SortMerge(array);
            stopwatch.Stop();
            //смотрим сколько миллисекунд было затрачено на выполнение
            Console.WriteLine("Время выполнения {0}", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.ReadKey();
        }


        public static int[] SortMerge(int[] massive) //сама сортировка
        {
            if (massive.Length == 1)
                return massive; //если длина массива равна 1 = возращаем наш массив
            int mid_point = massive.Length / 2; //определяем середину массива
            return merge(SortMerge(massive.Take(mid_point).ToArray()), SortMerge(massive.Skip(mid_point).ToArray())); //рекурсия
        }


        public static int[] merge(int[] mass1, int[] mass2) //слияние
        {
            int a = 0, b = 0;
            int[] merged = new int[mass1.Length + mass2.Length]; //создаем новый массив длинною в два маленьких
            for (int i = 0; i < merged.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length) //если индекс обхда меньше длины массивов (если один массив закончился)
                    if (mass1[a] > mass2[b] && b < mass2.Length) //ну и дальше просто из двух исходных массивов 
                        merged[i] = mass2[b++];                  //записываем в merged, и сдвгиаем индексы обхода для одного из них и для общего
                    else
                        merged[i] = mass1[a++];
                else
                    if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            }
            return merged;
        }

    }
}
