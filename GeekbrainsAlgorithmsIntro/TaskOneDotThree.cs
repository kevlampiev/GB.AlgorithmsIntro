using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekbrainsAlgorithmsIntro
{
    public static class TaskOneDotThree
    {

        /// <summary>
        /// Вычисление числа Фибоначи рекурсивно
        /// </summary>
        /// <param name="member">Номер последовательности</param>
        /// <returns>Значение числа Фибоначи</returns>
        public static long FibonacciByRecursion(int member)
        {
            if (member < 0)
            {
                throw new ArgumentOutOfRangeException("Номер члена последовательнсти должен быть больше 0");
            }
            if (member == 0) return 0;
            if (member == 1) return 1;
            return (FibonacciByRecursion(member - 1) + FibonacciByRecursion(member - 2));
        }

        public static long FibonacciByCicle(int member) 
        {
            long prev = (member==0)?0:1;
            long beforePrev = 0;
            if (member < 0)
            {
                throw new ArgumentOutOfRangeException("Номер члена последовательнсти должен быть больше 0");
            }
            for (int i = 1; i < member; i++) {
                prev += beforePrev;
                beforePrev = prev - beforePrev;              
            }
            return prev;
        }

        public static void CalcFibonacciSquence()
        {
            int maxNumber = 5;
            Console.WriteLine($"Значение первых {maxNumber} чисел Фибоначчи, вычисленных рекурсией и без");
            for (int i = 0; i <= maxNumber; i++) Console.WriteLine($"Номер {i} число с рекурсией {FibonacciByRecursion(i)}  без рекурсии {FibonacciByCicle(i)}");
        }

    }
}
