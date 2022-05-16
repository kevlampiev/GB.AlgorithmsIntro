namespace GeekbrainsAlgorithmsIntro;


public delegate void LessonRunner();

/// <summary>
/// ����� ���� � ������� ������������� ����� ��� ��� ��� 
/// </summary>
public struct MenuItem
{
    public string Description;
    public LessonRunner RunnerFunc;

}





public class HomeWorkMenu
{

    private MenuItem[] _menuList; 
    private int _menuIndex;

    //�������� ���� ������������ �������� ������ ���� ������
    private int _menuStartColumnPos = 3;
    private int _menuStartRowPos = 3;

    //����� ������ ���������. ���� true - ��������. ��� ��������� ���� ����������
    private bool _goOn;

    //�������� ����� � ������ ����
    public int MenuIndex {get=>_menuIndex; set { SetMenuIndex(value); } }

    public HomeWorkMenu()
    {
        _menuIndex = 0;
        _menuList = new MenuItem[2];
        _menuList[0] = new MenuItem { Description = "���� 1", RunnerFunc = new LessonRunner( LessonOne.Run ) };
        _menuList[1] = new MenuItem { Description = "�����", RunnerFunc = new LessonRunner(this.Done) };
        Init();
    }

    private void DisplayMenu() 
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(_menuStartColumnPos, _menuStartRowPos);
        Console.Write("����� ����� ��� �����������");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(_menuStartColumnPos, _menuStartRowPos+1);
        Console.Write("��� ���������� �� ������� ����������� ������� �������, ��� ������ - ������� Enter ");
        


        for (int i = 0; i < _menuList.Length; i++) 
        {
            string textToDisplay;
            Console.ResetColor();
            Console.SetCursorPosition(_menuStartColumnPos, i + 3 + _menuStartRowPos);
            if (i == _menuIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                textToDisplay = "-> " + _menuList[i].Description;
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                textToDisplay = "   " + _menuList[i].Description;
            }

            Console.Write(textToDisplay);
        }
    }

    private void DisplayHeader() 
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(0, 0);
        Console.Write("�������� ������� �� ����� ��������� � ��������� ������");      
        Console.SetCursorPosition(0, 1);
        Console.ResetColor();
        Console.Write("�������� ���������� �.�.");
        Console.SetCursorPosition(0, 2);
        Console.Write("-------------------------------------------------------");
    }


    private void Repaint() 
    {
        Console.ResetColor();
        Console.Clear();
        DisplayHeader();
        DisplayMenu();
    }


    //������ ��� ��� ���� �� ������� �����
    private void DisplayLesson(MenuItem lesson)    
    {
        Console.ResetColor();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.SetCursorPosition(0, 0);
        Console.Write(lesson.Description);
        Console.SetCursorPosition(0, 1);
        Console.ResetColor();
        lesson.RunnerFunc();
        Console.Write("������� ����� ������� ��� �����������");
        Console.ReadKey(true);
        Repaint();
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
        _goOn = true;
        Repaint();
    }

    public void Run()
    {
        ConsoleKeyInfo keyInfo;
        while (_goOn) 
        {
            keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key) {
                case ConsoleKey.UpArrow:
                    --MenuIndex;
                    break;
                case ConsoleKey.DownArrow:
                    ++MenuIndex;
                    break;
                case ConsoleKey.Enter:
                    DisplayLesson(_menuList[MenuIndex]);
                    break;
                default: 
                    Repaint(); 
                    break;
            }
        }
    }

    public void Done()
    {
        _goOn = false;
    }

    public void Lesson1() 
    {
        Console.WriteLine("Lorem");
        Console.ReadKey(true);
    }
}