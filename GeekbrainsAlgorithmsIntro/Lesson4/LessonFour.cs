namespace GeekbrainsAlgorithmsIntro.Lesson4;

public class LessonFour
{

    public static void DisplayStep(string description)
    {
        Console.WriteLine();
        Console.WriteLine(description);
    }

    public static void Run()
    {
        DisplayStep("1. Создаем простое дерево из 3-х элеменов");
        TreeInt tree = new TreeInt();
        tree.AddItem(5);
        tree.AddItem(15);
        tree.AddItem(2);
        tree.DrawTree();
        
        DisplayStep("2. Добавляем в дерево заведомо больший элемент. Он должен быть листом справа в конце");
        tree.AddItem(17);
        tree.AddItem(3);
        tree.AddItem(1);
        tree.PrintTree();    
        
        // DisplayStep("3. Добавляем в дерево элемент меньше максимального. Он должен быть листом в центре");
        // tree.AddItem(80);
        // tree.PrintTree();  
        
    
    }
}