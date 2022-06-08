using HWEssentials.Lesson4;

namespace HWEssentials.Lesson6;

public static class TreeIntExtension
{
    
    
    public static TreeNode<int> BFSearch(this TreeInt _tree, int value)
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
    
    public static TreeNode<int> DFSearch(this TreeInt _tree, int value)
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
    
}