namespace HWEssentials.Lesson4;

public class TreeNode<T>
{
    public T Data { get; set; }
    public TreeNode<T> Left { get; set; }

    public TreeNode<T> Right { get; set; }
    //public TreeNode<T> Parent { get; set; }
}