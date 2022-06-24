using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWCommonInterfaces;

namespace HWEssentials.Lesson8
{
    internal class LessonEight : ILesson
    {

        // Границы диапаона
        private int _lowBorder = 0;
        private int _highBorder = 10;

        //Количество элементов
        private int _elementsCount = 30;

        private int[] _intArray;

        /// <summary>
        /// Свойства границы диапазона
        /// </summary>
        public int LowBorder { get => _lowBorder; set { SetLowerBorder(value); } }
        public int HighBorder { get => _highBorder; set { SetUpperBorder(value); } }

        /// <summary>
        /// Свойство Количество элементов массива
        /// </summary>
        public int ElementsCount { get => _elementsCount; set { if (value >= 1) _elementsCount = value; } }

        public int LessonNumber { get; set; }
        public string Descriptopn { get; set; }

        //Вспомогательная функция, чтобы не перепутывались границы
        private void SetUpperBorder(int value)
        {
            if (value >= LowBorder)
            {
                _highBorder = value;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Попытка установить верхнее значение меньше чем нижняя граница диапазона проигнорирована");
                Console.ResetColor();
            }
        }

        //Вспомогательная функция, чтобы не перепутывались границы
        private void SetLowerBorder(int value)
        {
            if (value <= HighBorder)
            {
                _lowBorder = value;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Попытка установить нижнее значение больше чем текущая верхняя граница диаразона проигнорирована");
                Console.ResetColor();
            }
        }


        //Вспомогательная функция ввода целого
        private int GetIntFromKeyboard(string prompt)
        {
            Console.Write(prompt + ": ");
            bool success = int.TryParse(Console.ReadLine(), out int result);
            if (success) return result;
            else
            {
                Console.WriteLine("Введено что-то непонятное, введенное значение будет преобразовано к нулю.");
                return 0;
            }
        }


        /// <summary>
        /// Запрашивает ввод с клавиатуры значений верхней и нижней границы диапазона и кол-ва элементов
        /// </summary>
        public void GetParams()
        {
            Console.WriteLine();
            LowBorder = GetIntFromKeyboard($"Введите минимально возможную нижнюю границу диапазона");
            HighBorder = GetIntFromKeyboard("Введите максимально возможную верхнюю границу диапазона");
            ElementsCount = GetIntFromKeyboard("Введите количество элементов массива для генерации");
        }

        // Вспомогательная функция генерации массива
        private void InitArray()
        {
            Random rnd = new Random();
            int[] newArray = new int[ElementsCount];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = rnd.Next(LowBorder, HighBorder);
            }
            _intArray = newArray;
        }

        //Вывод без затей
        private void displayArray()
        {
            Console.WriteLine();
            for (int i = 0; i < _intArray.Length; i++)
            {
                Console.Write(" " + _intArray[i] + " ");
            }
            Console.WriteLine();
        }

        private void SortArray()
        {
            int[] countingArray = new int[HighBorder - LowBorder + 1];
            //Не уверен, что это необходимо, но на всякий случай
            Array.Clear(countingArray);

            for (int i = 0; i < _intArray.Length; i++)
            {
                int index = _intArray[i] - LowBorder;
                countingArray[index]++;
            }

            //разворачиваем обратно
            Array.Clear(_intArray);
            int currentIndex = 0; //индекс в отсортированном массиве
            for (int i = 0; i < countingArray.Length; i++)
            {
                for (int j = 0; j < countingArray[i]; j++)
                {
                    _intArray[currentIndex++] = i + LowBorder;
                }
            }

        }

        //Вспомогательная функция:гоняет процесс инициализация-сортировка-отображение
        private void DisplaySortingProcess()
        {
            InitArray();
            Console.WriteLine($"Исходный массив из {_elementsCount} элементов с диапаоном значений [{LowBorder} - {HighBorder}]:");
            displayArray();
            SortArray();
            Console.WriteLine("Отсортированный массив:");
            displayArray();
        }


        public LessonEight()
        {
            LessonNumber = 8;
            Descriptopn = "Урок 8. Реализовать алгоритм сортировки подсчетом";
        }



        public void Run()
        {
            ConsoleKeyInfo commandKey = new ConsoleKeyInfo();
            do
            {
                DisplaySortingProcess();
                Console.WriteLine("Для задания новых параметров для инициализации массива нажмите клавишу <o>, любую другую - для выхода");
                commandKey = Console.ReadKey();
                if (commandKey.Key == ConsoleKey.O)
                {
                    GetParams();
                }
            } while (commandKey.Key == ConsoleKey.O);
        }
    }
}
