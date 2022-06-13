using HWCommonInterfaces;

namespace HWEssentials.Lesson1;

public class LessonOne : ILesson
{
    public int LessonNumber { get; set; }
    public string Descriptopn { get; set; }

    public LessonOne()
    {
        LessonNumber = 1;
        Descriptopn = "1";
    }

    public void Run()
    {
        Console.WriteLine(
            "Задача 1. Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки, простое число или нет.");
        Lesson1Task1.TestCheckIsPrime();

        Console.WriteLine();
        Console.WriteLine("Задача 3. Реализуйте функцию вычисления числа Фибоначчи ..... ");
        Lesson1Task3.CalcFibonacciSquence();
    }
}