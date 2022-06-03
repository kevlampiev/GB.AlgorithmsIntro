using System.Diagnostics;
using System.Text;
using HWCommonInterfaces;

namespace HWEssentials.Lesson4;

public class LessonFour:ILesson
{
    
    public int LessonNumber { get; set; }
    public string Descriptopn { get; set; }
    
    public void DisplayStep(string description)
    {
        Console.WriteLine();
        Console.WriteLine(description);
    }

    /// <summary>
    /// Генерит что-то
    /// </summary>
    /// <returns>строка случайных символов</returns>
    public string RandomString()
    {
        var random = new Random();

        var symbols = "abcdefghijklmnopqrstuvwxyz1234567890 ";
        var strSize = 100;

        var result = new StringBuilder();

        for (var i = 0; i < strSize; i++) result.Append(symbols[random.Next(symbols.Length - 1)]);

        return result.ToString();
    }

    /// <summary>
    /// Функция по задаче 2 (Сравнение массива и Hashset)
    /// </summary>
    public void TryHash()
    {
        var iterations = 100000;
        var strArray = new string[iterations];
        var strHashSet = new HashSet<string>();

        for (var i = 0; i < iterations; i++)
        {
            var rndStr = RandomString();
            strArray[i] = rndStr;
            strHashSet.Add(rndStr);
        }

        var realString = strArray[iterations - 100];

        Console.WriteLine("a) Ищем строку в массиве");
        var sw = new Stopwatch();
        sw.Start();
        for (var i = 0; i < iterations; i++)
            if (strArray[i] == realString)
            {
                Console.WriteLine($"Строка {realString} найдена в массиве");
                break;
            }

        sw.Stop();
        Console.WriteLine($"На операцию поиска в массиве ушло {sw.ElapsedMilliseconds} миллисекунд");

        sw.Reset();
        sw.Start();
        if (strHashSet.Contains(realString))
            Console.WriteLine($"Строка {realString} найдена в Hashset");
        else
            Console.WriteLine($"Строка {realString} не найдена в Hashset");
        Console.WriteLine($"На операцию поиска в HashSet ушло {sw.ElapsedMilliseconds} миллисекунд");
        ;

        sw.Stop();
    }

    /// <summary>
    /// Функция по задаче 1 (работа с деревьями)
    /// </summary>
    public void BTrees()
    {
        DisplayStep("a) Создаем простое дерево из 3-х элеменов");
        var tree = new TreeInt();
        tree.AddItem(5);
        tree.AddItem(15);
        tree.AddItem(2);
        tree.DrawTree();

        DisplayStep("b)  Добавляем в дерево заведомо больший элемент. Он должен быть листом справа в конце");
        tree.AddItem(20);
        tree.AddItem(3);
        tree.AddItem(1);
        tree.PrintTree();

        DisplayStep("c) Добавляем в дерево элемент меньше максимального. Он должен быть листом в центре");
        tree.AddItem(0);
        tree.AddItem(80);
        tree.AddItem(18);
        tree.PrintTree();

        DisplayStep("d) Удаляем позицию 20");
        tree.RemoveItem(15);
        tree.PrintTree();
    }


    public void Run()
    {
        DisplayStep("Задание 1. Работа с деревьями");
        BTrees();
        DisplayStep("Задание 2. Работа с HashSet");
        TryHash();
    }


}