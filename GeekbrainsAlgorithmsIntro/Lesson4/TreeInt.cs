namespace GeekbrainsAlgorithmsIntro.Lesson4;

public class TreeInt:ITree
{
    private TreeNode<int> _root;

    //Сколько позиций отведем для отображения одного узла при печати
    public int _nodeTemplateWidth = 2;

    
    
    /// <summary>
    /// Количество символов на отображение данных node включая границы
    /// </summary>
    public int NodeDataViewWidth
    {
        get => _nodeTemplateWidth + 2;
    }

    //определяем максимальную глубину дерева, идущего от узла node
    private int GetLevelCount(TreeNode<int> node )
    {
        if (node == null) return 0;
        if (node.Left == null && node.Right == null) return 1;
        
        int subLevelsLeft = (node.Left != null)? GetLevelCount(node.Left) : 0;
        int subLevelsRight = (node.Right != null)? GetLevelCount(node.Right) : 0;

        return Math.Max(subLevelsLeft, subLevelsRight) + 1;
    }

   

    //Вспомогательная функция для формирования того, как будет выглядеть узел при отображении. Требует оптимизации
    private string FormNodeTemplate(TreeNode<int> node, int level)
    {
        // узел будет выглядеть так:  ┌ (левая оеонцовка) -- (стикер0-удлинитель) [00] (само изображение) -- ┐ (правая оконцовка)
        string template = (node != null)?node.Data.ToString():"";
        template = "[" + template.PadLeft(_nodeTemplateWidth, ' ') + "]"; 
        
        //Для самого последнего ряда (листья) предусмотрим пробелы слева и справа, чтобы отделять листья визуально
        int spaceForElement = (NodeDataViewWidth+2) * ((int)Math.Pow(2, LevelsCount - level));

        int stickerLength = Math.Max((spaceForElement/2 - NodeDataViewWidth - 2)/2, 0);
        string sticker = "".PadLeft(stickerLength, '─');

        int marginLength = (spaceForElement - NodeDataViewWidth - 2 - stickerLength*2 + 1) / 2;
        string margin = "".PadLeft(marginLength, ' ');

        string letfEdging = (level != LevelsCount) ? "┌" : "";
        string rightEdging = (level != LevelsCount) ? "┐" : "";

        if (level == LevelsCount)
        {
            template = " "+template +" "; //особый случай - последний ряд, иначе очень много место занимает дерево
        } 
        else 
        {
            template= margin+letfEdging+sticker+template+sticker+rightEdging+margin;
        }
        return template.PadRight(spaceForElement, ' ');
        
    }

    
    public TreeNode<int> Root
    {
        get => GetRoot();  //Ну, как бы да.... но по интерфейсу надо реализовать GetRoot, не выбрасывать же ...
        set { _root = value;  }
    }
    
    /// <summary>
    /// Максимальное количество уровней, начиная с корня
    /// </summary>
    public int LevelsCount { get=>GetLevelCount(GetRoot());  }

      
    /// <summary>
    /// Функция отрисовки декрева
    /// </summary>
    /// <param name="nodeArray"> необязательный параметр - массив элекентов уровня level</param>
    /// <param name="level"> необязательный параметр - уровень</param>
    public void DrawTree(TreeNode<int>[] nodeArray = null, int level = 1)
    {
        if (nodeArray == null)
        {
            nodeArray = new TreeNode<int>[1];
            nodeArray[0] = GetRoot();
        }
        for (int i = 0; i < nodeArray.Length; i++)
        {
            Console.Write(FormNodeTemplate(nodeArray[i], level));
        }
        Console.WriteLine();

        if (level < LevelsCount) 
        {
            TreeNode<int>[] newNodeArray = new TreeNode<int>[2*nodeArray.Length];
            for (int j = 0; j < nodeArray.Length; j++)
            {
                newNodeArray[2 * j] = nodeArray[j].Left;
                newNodeArray[(2 * j) + 1] = nodeArray[j].Right;
            }
            DrawTree(newNodeArray, level+1);
        }
    }

    public TreeNode<int> GetRoot()
    {
        return _root;
    }

    /// <summary>
    /// Вставляет новый элемент с перестроением
    /// </summary>
    /// <param name="value">полезная нагрузка нового элемента</param>
    public void AddItem(int value)
    {
        if (Root == null)
        {
            _root = new TreeNode<int>() { Data = value };
        }
        else
        {
            SearchAndAdd(Root, value);
        }
    }

    
    /// <summary>
    /// Добавляет значение в оптимальное место в дереве
    /// </summary>
    /// <param name="node">Узел с которого стартрует поиск для вставки</param>
    /// <param name="value">Вставляемое значение</param>
    private void SearchAndAdd(TreeNode<int> node, int value)
    {
        if (node.Data == value) return; //такой узел уже существует, неинтересно
        if (node.Data > value) //Надо как-то подставить слева
        {
            if (node.Left == null)
            {
                node.Left = new TreeNode<int>() { Data = value };
            }
            else
            {
                SearchAndAdd(node.Left, value);
            }
        }
        else if (node.Data < value)
        {
            //случай, когда значение в узде меньше подставляемого - надо как-то подставить справа
            if (node.Right == null)
            {
                node.Right = new TreeNode<int>() { Data = value };
            }
            else
            {
                SearchAndAdd(node.Right, value);
            }
        }
    }

    public void RemoveItem(int value)
    {
        //неправильная реализация. Отключает всю ветку безвинных node. TODO Переделать 
        TreeNode<int> nodeToRemove = GetNodeByValue(value);
        if (nodeToRemove != null)
        {
            TreeNode<int> parent = GetParent(nodeToRemove, Root);
            if (parent.Left == nodeToRemove) parent.Left = null;
            if (parent.Right == nodeToRemove) parent.Right = null;
        }
    }

    /// <summary>
    /// Вспомогательная функция поиска рекурсивно по значению
    /// </summary>
    /// <param name="value">искомое значение</param>
    /// <param name="node">стартовый узел</param>
    /// <returns> адрес узла </returns>
    private TreeNode<int> SearchNodeByValue(int value, TreeNode<int> node)
    {
        TreeNode<int> result = null;
        
        if (node.Data == value) return node;
        if (node.Left != null)
        {
            result = SearchNodeByValue(value, node.Left);
            if (result != null) return result;
        }

        if (node.Right != null)
        {
            result = SearchNodeByValue(value, node.Right);
            if (result != null) return result;
        }

        return null;

    }

    /// <summary>
    /// Возвращает ссылку на родителя заданного узла
    /// </summary>
    /// <param name="node">Узел, родителя которого мы ищем </param>
    /// <returns>ссылка на родительский узел </returns>
    private TreeNode<int> GetParent(TreeNode<int> node, TreeNode<int> parent  )
    {
        TreeNode<int> result = null;
        if (parent == null) return null;
        if (parent.Left == node || parent.Right == node) return parent;
        result = GetParent(node, parent.Left);
        if (result != null) return result;
        result = GetParent(node, parent.Right);
        if (result != null) return result;
        
        return result;
    }

    /// <summary>
    /// Поиск узда в дереве по значению
    /// </summary>
    /// <param name="value">Значение для поиска</param>
    /// <returns>Адрес узла</returns>
    public TreeNode<int> GetNodeByValue(int value)
    {
        if (Root == null) return null;
        return SearchNodeByValue(value, Root);
    }

    public void PrintTree()
    {
        DrawTree();
    }
}