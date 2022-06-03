using System.Diagnostics;
using HWCommonInterfaces;

namespace HWEssentials.Lesson3;

public class LessonThree:ILesson
{
    public int LessonNumber { get; set; }
    public string Descriptopn { get; set; }
    
    /// <summary>
    /// Инициализация массива классов
    /// </summary>
    /// <param name="membersCount">Количество элементов массива</param>
    /// <returns>Массив классов точек</returns>
    public PointClassDouble[] InitClasses(int membersCount)
    {
        var rnd = new Random();
        var pointArray = new PointClassDouble[membersCount];
        for (var i = 0; i < membersCount; i++)
            pointArray[i] = new PointClassDouble() { X = rnd.Next(-300, 300) / 3.0, Y = rnd.Next(-300, 300) / 3.0 };
        return pointArray;
    }

    /// <summary>
    /// Инициализация масива структур
    /// </summary>
    /// <param name="membersCount">Количество элементов массива</param>
    /// <returns></returns>
    public PointStructDouble[] InitStructures(int membersCount)
    {
        var rnd = new Random();
        var pointArray = new PointStructDouble[membersCount];
        for (var i = 0; i < membersCount; i++)
            pointArray[i] = new PointStructDouble() { X = rnd.Next(-300, 300) / 3.0, Y = rnd.Next(-300, 300) / 3.0 };
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
    public double CalcDistance(double x1, double y1, double x2, double y2)
    {
        var dX = x2 - x1;
        var dY = y2 - y1;
        return Math.Sqrt(dX * dX + dY * dY);
    }

    /// <summary>
    /// Функция подсчета времени выполнения расчекта дистанций между точками заданными структурами
    /// </summary>
    /// <param name="membersCount">количество элементов</param>
    /// <returns>время в миллисекундах</returns>
    public long CalcStrunctureDistances(int membersCount)
    {
        var structArray = InitStructures(membersCount);

        var timer = new Stopwatch();
        timer.Start();
        for (var i = 0; i < membersCount; i++)
        for (var j = i + 1; j < membersCount; j++)
        {
            //double distance = CalcDistance(structArray[i].X, structArray[i].Y, structArray[j].X, structArray[j].Y);
            var distance = Math.Pow(structArray[i].X - structArray[j].X, 2) +
                           Math.Pow(structArray[i].Y - structArray[j].Y, 2);
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
    public long CalcClassDistances(int membersCount)
    {
        var classArray = InitClasses(membersCount);

        var timer = new Stopwatch();
        timer.Start();
        for (var i = 0; i < membersCount; i++)
        for (var j = i + 1; j < membersCount; j++)
        {
            //double distance = CalcDistance(structArray[i].X, structArray[i].Y, structArray[j].X, structArray[j].Y);
            var distance = Math.Pow(classArray[i].X - classArray[j].X, 2) +
                           Math.Pow(classArray[i].Y - classArray[j].Y, 2);
        }

        timer.Stop();
        return timer.ElapsedMilliseconds;
    }


    /// <summary>
    /// Функция делает много классов без использования массива и считает вхолостую расстоянгие между точками
    /// </summary>
    /// <param name="memberCount">количество действий  </param>
    /// <returns>время выполнения в милисекундах</returns>
    public long MeasureTimeClases(int memberCount)
    {
        var sw = new Stopwatch();
        var rnd = new Random();
        sw.Start();
        for (var i = 1; i <= memberCount; i++)
        {
            var startPoint = new PointClassDouble()
                { X = rnd.Next(-300, 300) / 3.0, Y = rnd.Next(-300, 300) / 3.0 };
            var endtPoint = new PointClassDouble()
                { X = rnd.Next(-300, 300) / 3.0, Y = rnd.Next(-300, 300) / 3.0 };
            var distance = CalcDistance(startPoint.X, startPoint.Y, endtPoint.X, endtPoint.Y);
        }

        sw.Stop();
        return sw.ElapsedMilliseconds;
    }


    /// <summary>
    /// Функция делает много структур без использования массива и считает вхолостую расстоянгие между точками
    /// </summary>
    /// <param name="memberCount">количество действий  </param>
    /// <returns>время выполнения в милисекундах</returns>
    public long MeasureTimeStructures(int memberCount)
    {
        var sw = new Stopwatch();
        var rnd = new Random();
        sw.Start();
        for (var i = 1; i <= memberCount; i++)
        {
            var startPoint = new PointStructDouble()
                { X = rnd.Next(-300, 300) / 3.0, Y = rnd.Next(-300, 300) / 3.0 };
            var endtPoint = new PointStructDouble()
                { X = rnd.Next(-300, 300) / 3.0, Y = rnd.Next(-300, 300) / 3.0 };
            var distance = CalcDistance(startPoint.X, startPoint.Y, endtPoint.X, endtPoint.Y);
        }

        sw.Stop();
        return sw.ElapsedMilliseconds;
    }

    /// <summary>
    /// Основная функция Урока 3
    /// </summary>
    public void Run()
    {
        var countIncrement = 10000;
        Console.WriteLine("Вариант 1. Массив значений");
        Console.WriteLine("length of arrays | time elapsed (structures), ms | time elapsed(classes), ms | time ratio ");
        Console.WriteLine("------------------------------------------------------------------------------------------");

        for (var i = 1; i <= 2; i++)
        {
            var timeClasses = CalcClassDistances(countIncrement * i);
            var timeStructures = CalcStrunctureDistances(countIncrement * i);
            var outputStr =
                string.Format(" {0:d6}          |                        {1:d6} |                    {2:d6} | {3:f6}",
                    countIncrement * i, timeStructures, timeClasses, timeStructures / (float)timeClasses);
            Console.WriteLine(outputStr);
        }

        Console.WriteLine("\nВариант 2. Без использования массивов");
        Console.WriteLine("number of pairs  | time elapsed (structures), ms | time elapsed(classes), ms | time ratio ");
        Console.WriteLine("------------------------------------------------------------------------------------------");
        for (var i = 1; i <= 2; i++)
        {
            var timeClasses = MeasureTimeClases(100000 * i);
            var timeStructures = MeasureTimeStructures(100000 * i);
            var outputStr =
                string.Format(" {0:d6}          |                        {1:d6} |                    {2:d6} | {3:f6}",
                    100000 * i, timeStructures, timeClasses, timeStructures / (float)timeClasses);
            Console.WriteLine(outputStr);
        }
    }
}