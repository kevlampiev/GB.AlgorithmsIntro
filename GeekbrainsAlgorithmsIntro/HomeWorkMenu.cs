namespace GeekbrainsAlgorithmsIntro;

/// <summary>
/// Пункт меню с вызовом определенного урока или еще что 
/// </summary>
public struct MenuItem
{
    public string Description;
    public delegate void LessonRunner();

}





public class HomeWorkMenu
{

    private MenuItem[] _menuList; 
    private int _menuIndex;

    //Смещение меню относительно верхнего левого угла экрана
    private int _menuStartColumnPos = 3;
    private int _menuStartRowPos = 3;

    //Активный номер в пункте меню
    public int MenuIndex {get; set;}

    private void DisplayMenu() 
    {
        for (int i = 0; i < _menuList.Length; i++) 
        {
            Console.ResetColor();
            Console.SetCursorPosition(_menuStartColumnPos, i + _menuStartRowPos);
            if (i == _menuIndex) 
            { 
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write(_menuList[i].Description);
        }
    }


    private void DisplayHeader() 
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(0, 0);
        Console.Write("Домашнее задание по курсу Алгоритмы и структуры данных");      
        Console.SetCursorPosition(0, 1);
        Console.ResetColor();
        Console.Write("Выполнил Евлампиевв К.В.");
        Console.SetCursorPosition(0, 2);
        Console.Write("-------------------------------------------------------");
    }


    private void Repaint() 
    {
        Console.Clear();
        Console.ResetColor();
        DisplayHeader();
        DisplayMenu();
    }


    private void SetMenuIndex(int value) 
    {
        if (value < 0)
        {
            _menuIndex = _menuList.Length - 1;
        }
        else if (value >= _menuList.Length) 
        {
            _menuIndex = 0;
        }
        else 
        {
            _menuIndex = value;
        }
        Repaint();
    }

    public void Init()
    {
        
    }

    public void Run()
    {
        
    }

    public void Done()
    {
    }
}