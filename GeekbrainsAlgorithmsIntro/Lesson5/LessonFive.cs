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

        while (node.Data != value && queue.Count > 0)
        {
            if (node.Left != null) queue.Enqueue(node.Left);
            if (node.Right != null) queue.Enqueue(node.Right);
            node = queue.Dequeue();
            
        }
        return (node.Data == value? node: null);
    }



    private TreeNode<int> DFSearch(int value)
    {
        if (_tree.GetRoot() == null) return null;
        
        Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
        TreeNode<int> node = _tree.GetRoot();

        while (node.Data != value && stack.Count > 0)
        {
            if (node.Left != null) stack.Push(node.Left);
            if (node.Right != null) stack.Push(node.Right);
            node = stack.Pop();
            
        }
        return (node.Data == value? node: null);
        
        
    }


    public void Run()
    {
        Random rnd = new Random();
        Init();
        _tree.PrintTree();
        int searchValue = rnd.Next(99);

        TreeNode<int> node = BFSearch(searchValue);
        Console.WriteLine($"Поиск в ширину. Значение {searchValue} {(node == null?"не":"" )} найдено в дереве");

        node = DFSearch(searchValue);
        Console.WriteLine($"Поиск в шлубину. Значение {searchValue} {(node == null?"не":"" )} найдено в дереве");
    }
}