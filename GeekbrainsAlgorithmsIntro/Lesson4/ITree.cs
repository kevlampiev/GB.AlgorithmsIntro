namespace GeekbrainsAlgorithmsIntro.Lesson4;

public interface ITree
{
    TreeNode<int> GetRoot();
    void AddItem(int value); // добавить узел
    void RemoveItem(int value); // удалить узел по значению
    TreeNode<int> GetNodeByValue(int value); //получить узел дерева по значению
    void PrintTree(); //вывести дерево в консоль
}