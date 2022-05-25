using System.Diagnostics;
using System.Threading;
using System;

namespace GeekbrainsAlgorithmsIntro.Lesson3;

public class LessonThree
{
    /// <summary>
    /// Инициализация массива классов
    /// </summary>
    /// <param name="membersCount">Количество элементов массива</param>
    /// <returns>Массив классов точек</returns>
    public static PointClassDouble[] InitClasses(int membersCount)
    {
        Random rnd = new Random();
        PointClassDouble[] pointArray = new PointClassDouble[membersCount];
        for (int i = 0; i < membersCount; i++)
        {
            pointArray[i] = new PointClassDouble() { X = rnd.Next(-300, 300) / 3.0, Y = rnd.Next(-300, 300) / 3.0 };
        }
        return pointArray;
    }
    
    /// <summary>
    /// Инициализация масива структур
    /// </summary>
    /// <param name="membersCount">Количество элементов массива</param>
    /// <returns></returns>
    public static PointStructDouble[] InitStructures(int membersCount)
    {
        Random rnd = new Random();
        PointStructDouble[] pointArray = new PointStructDouble[membersCount];
        for (int i = 0; i < membersCount; i++)
        {
            pointArray[i] = new PointStructDouble() { X = rnd.Next(-300, 300) / 3.0, Y = rnd.Next(-300, 300) / 3.0 };
        }
        return pointArray;
    }

    /// <summary>
    /// Вычисление дистанции между двуя точками с 
    /// </summary>
    /// <param name="x1">Координата x первой точки</param>
    /// <param name="y1">Координата y первой точки</param>
    /// <param name="x2">Координата x второй точки</param>
    /// <param name="y2">Координата y второй точки</param>
    /// <returns>Дистанция между двумя точками</returns>
    public static double CalcDistance(double x1, double y1, double x2, double y2)
    {
        double dX = x2 - x1;
        double dY = y2 - y1; 
        return Math.Sqrt(dX * dX + dY * dY);
    }

    /// <summary>
    /// Функция подсчета времени выполнения расчекта дистанций между точками заданными структурами
    /// </summary>
    /// <param name="membersCount">количество элементов</param>
    /// <returns>время в миллисекундах</returns>
    public static long CalcStrunctureDistances(int membersCount)
    {
        PointStructDouble[] structArray = InitStructures(membersCount);

        Stopwatch timer = new Stopwatch();
        timer.Start();
        for (int i = 0; i < membersCount; i++)
        {
            for (int j = i+1; j < membersCount; j++)
            {
                //double distance = CalcDistance(structArray[i].X, structArray[i].Y, structArray[j].X, structArray[j].Y);
                double distance = Math.Pow(structArray[i].X - structArray[j].X, 2) + Math.Pow(structArray[i].Y - structArray[j].Y, 2);
            }
        }
        timer.Stop();
        return timer.ElapsedMilliseconds;
    }
    
    //Вообще, получается функция - близнец и хочется просто передать ей в качестве агрумента некий массив (структур
    //или классов), а внутри преобразовать типы, но, боюсь, что это усложнит эксперимент и интерпретацию его результатов
    
    /// <summary>
    /// Функция подсчета времени выполнения расчекта дистанций между точками заданными объектами.
    /// </summary>
    /// <param name="membersCount">количество элементов</param>
    /// <returns>время в миллисекундах</returns>
    public static long CalcClassDistances(int membersCount)
    {
        PointClassDouble[] classArray = InitClasses(membersCount);

        Stopwatch timer = new Stopwatch();
        timer.Start();
        for (int i = 0; i < membersCount; i++)
        {
            for (int j = i+1; j < membersCount; j++)
            {
                //double distance = CalcDistance(structArray[i].X, structArray[i].Y, structArray[j].X, structArray[j].Y);
                double distance = Math.Pow(classArray[i].X - classArray[j].X,2) + Math.Pow(classArray[i].Y - classArray[j].Y,2);

            }
        }
        timer.Stop();
        return timer.ElapsedMilliseconds;
    }
    
    /// <summary>
    /// Основная функция Урока 3
    /// </summary>
    public static void Run()
    {
        int countIncrement = 10000;
        Console.WriteLine("length of arrays | time elapsed (structures), ms | time elapsed(classes), ms | time ratio ");
        Console.WriteLine("------------------------------------------------------------------------------------------");

        for (int i = 1; i <= 20; i++)
        {
            
            long timeClasses = CalcClassDistances(countIncrement*i);
            long timeStructures = CalcStrunctureDistances(countIncrement * i);
            string outputStr =
            string.Format(" {0:d6}          |                        {1:d6} |                    {2:d6} | {3:f6}", countIncrement * i, timeStructures, timeClasses, timeStructures / (float)timeClasses);
            Console.WriteLine(outputStr);
        }
    }
}