using GeekbrainsAlgorithmsIntro.Lesson4;

namespace GeekbrainsAlgorithmsIntro.Lesson5;

public class LessonFive:ILesson
{
    private TreeInt _tree;
    public int LessonNumber { get; set; }
    public string Descriptopn { get; set; }

    private void Init()
    {
        _tree = new TreeInt();
        Random rnd = new Random();
        
        for (int i = 0; i < 10; i++)
        {
            _tree.AddItem(rnd.Next(99));
        }
        
    }

    /// <summary>
    /// Поиск в ширину элемента с позезной нагрузкой value
    /// </summary>
    /// <param name="value">Полезная нагрузка искомого элемента</param>
    /// <returns>Адрес элемента</returns>
    private TreeNode<int> BFSearch(int value)
    {
        if (_tree.GetRoot() == null) return null;
        
        Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();
        TreeNode<int> node = _tree.GetRoot();
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
        
        Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
        TreeNode<int> node = _tree.GetRoot();
        stack.Push(node);

        while (node.Data != value && stack.Count > 0)
        {
            if (node.Left != null) stack.Push(node.Left);
            if (node.Right != null) stack.Push(node.Right);
            node = stack.Pop();
            
        }
        return (node.Data == value? node: null);
    }

    
    //Вообще вспомогательная функция
    private int GetValueFromTree(out bool found)
    {
        TreeNode<int> node = _tree.GetRoot();
        if (node == null)
        {
            found = false;
            return -1;
        }

        while (node.Right != null)
        {
            node = node.Right;
        }

        found = true;
        return node.Data;
    }
    
    public void Run()
    {
        Random rnd = new Random();
        Init();
        _tree.PrintTree();
        int searchValue = rnd.Next(99);
        bool found;
        int realValue = GetValueFromTree(out found);

        Console.WriteLine("Поиск в ширину.");
        TreeNode<int> node = BFSearch(searchValue);
        Console.WriteLine($"Значение {searchValue} {((node == null)?"не":"" )} найдено в дереве");
        if (found) 
        {
            node = BFSearch(realValue);
            Console.WriteLine($"Значение {realValue} {((node == null)?"не":"" )} найдено в дереве");
        }

        Console.WriteLine("Поиск в глубину.");
        node = DFSearch(searchValue);
        Console.WriteLine($"Значение {searchValue} {((node == null)?"не":"" )} найдено в дереве");
        if (found)
        {
            node = DFSearch(realValue);
            Console.WriteLine($"Значение {realValue} {((node == null) ? "не" : "")} найдено в дереве");
        }
    }
}