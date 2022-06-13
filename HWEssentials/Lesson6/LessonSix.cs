using HWCommonInterfaces;
using HWEssentials.Lesson4;

namespace HWEssentials.Lesson6;

public class LessonSix : ILesson
{
    private TreeInt _tree;
    public int LessonNumber { get; set; }
    public string Descriptopn { get; set; }

//Вообще вспомогательная функция
    private int GetValueFromTree(out bool found)
    {
        var node = _tree.GetRoot();
        if (node == null)
        {
            found = false;
            return -1;
        }

        while (node.Right != null) node = node.Right;

        found = true;
        return node.Data;
    }

    public LessonSix()
    {
        LessonNumber = 6;
        Descriptopn = "6";

        Init();
    }

    /// <summary>
    /// Иницифлизация дерева для урока
    /// </summary>
    private void Init()
    {
        _tree = new TreeInt();
        var rnd = new Random();

        for (var i = 0; i < 7; i++) _tree.AddItem(rnd.Next(99));
    }

    /// <summary>
    /// Основная функция урока
    /// </summary>
    public void Run()
    {
        var rnd = new Random();

        _tree.PrintTree();
        var searchValue = rnd.Next(99);
        bool found;
        var realValue = GetValueFromTree(out found);

        Console.WriteLine("Поиск в ширину.");
        var node = _tree.BFSearch(searchValue);
        Console.WriteLine($"Значение {searchValue} {(node == null ? "не" : "")} найдено в дереве");
        if (found)
        {
            node = _tree.BFSearch(realValue);
            Console.WriteLine($"Значение {realValue} {(node == null ? "не" : "")} найдено в дереве");
        }

        Console.WriteLine("Поиск в глубину.");
        node = _tree.DFSearch(searchValue);
        Console.WriteLine($"Значение {searchValue} {(node == null ? "не" : "")} найдено в дереве");
        if (found)
        {
            node = _tree.DFSearch(realValue);
            Console.WriteLine($"Значение {realValue} {(node == null ? "не" : "")} найдено в дереве");
        }
    }
}