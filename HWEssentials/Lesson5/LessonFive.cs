using HWEssentials.Lesson4;
using HWCommonInterfaces;

namespace HWEssentials.Lesson5;

public class LessonFive : ILesson
{
    private TreeInt _tree;
    public int LessonNumber { get; set; }
    public string Descriptopn { get; set; }

    public LessonFive()
    {
        LessonNumber = 5;
        Descriptopn = "5";
    }

    /// <summary>
    /// Иницифлизация дерева для урока
    /// </summary>
    private void Init()
    {
        _tree = new TreeInt();
        var rnd = new Random();

        for (var i = 0; i < 10; i++) _tree.AddItem(rnd.Next(99));
    }

    /// <summary>
    /// Поиск в ширину элемента с позезной нагрузкой value
    /// </summary>
    /// <param name="value">Полезная нагрузка искомого элемента</param>
    /// <returns>Адрес элемента</returns>
    private TreeNode<int> BFSearch(int value)
    {
        if (_tree.GetRoot() == null) return null;

        var queue = new Queue<TreeNode<int>>();
        var node = _tree.GetRoot();
        queue.Enqueue(node);

        while (node.Data != value && queue.Count > 0)
        {
            if (node.Left != null) queue.Enqueue(node.Left);
            if (node.Right != null) queue.Enqueue(node.Right);
            node = queue.Dequeue();
        }

        if (queue.Count == 0) return null;
        else return node;
    }


    /// <summary>
    /// Поиск в глубину элемента с позезной нагрузкой value
    /// </summary>
    /// <param name="value">изкомое значение полезной нагрузки</param>
    /// <returns>адрес элемента</returns>
    private TreeNode<int> DFSearch(int value)
    {
        if (_tree.GetRoot() == null) return null;

        var stack = new Stack<TreeNode<int>>();
        var node = _tree.GetRoot();
        stack.Push(node);

        while (node.Data != value && stack.Count > 0)
        {
            if (node.Left != null) stack.Push(node.Left);
            if (node.Right != null) stack.Push(node.Right);
            node = stack.Pop();
        }

        return node.Data == value ? node : null;
    }


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

    /// <summary>
    /// Основная функция урока
    /// </summary>
    public void Run()
    {
        var rnd = new Random();
        Init();
        _tree.PrintTree();
        var searchValue = rnd.Next(99);
        bool found;
        var realValue = GetValueFromTree(out found);

        Console.WriteLine("Поиск в ширину.");
        var node = BFSearch(searchValue);
        Console.WriteLine($"Значение {searchValue} {(node == null ? "не" : "")} найдено в дереве");
        if (found)
        {
            node = BFSearch(realValue);
            Console.WriteLine($"Значение {realValue} {(node == null ? "не" : "")} найдено в дереве");
        }

        Console.WriteLine("Поиск в глубину.");
        node = DFSearch(searchValue);
        Console.WriteLine($"Значение {searchValue} {(node == null ? "не" : "")} найдено в дереве");
        if (found)
        {
            node = DFSearch(realValue);
            Console.WriteLine($"Значение {realValue} {(node == null ? "не" : "")} найдено в дереве");
        }
    }
}