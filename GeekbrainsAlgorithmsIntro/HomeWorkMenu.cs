using HWEssentials.Lesson1;
using HWEssentials.Lesson2;
using HWEssentials.Lesson3;
using HWEssentials.Lesson4;
using HWEssentials.Lesson5;
using HWCommonInterfaces;
using System.Collections;
using System.Reflection;

namespace GeekbrainsAlgorithmsIntro;


public delegate void LessonRunner();

/// <summary>
/// Структура для отображения пункта меню с уроком или командой
/// </summary>
public struct MenuItem
{
    public string Description;
    public LessonRunner RunnerFunc;

}


public class HomeWorkMenu
{

    private List<ILesson> _menuList;
    private int _menuIndex;

    //Смещение меню относительно верхнего левого угла экрана
    private int _menuStartColumnPos = 3;
    private int _menuStartRowPos = 3;

    //Режим работы программы. Если true - работает. Над названием надо поработать
    private bool _goOn;

    //Активный номер в пункте меню
    public int MenuIndex { get => _menuIndex; set { SetMenuIndex(value); } }

    public HomeWorkMenu()
    {
        var assembly = Assembly.LoadFile(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "HWEssentials.dll");
        
        var classesImplementingIList = assembly
            .GetTypes()
            .Where(type=> type.IsClass && typeof(ILesson).IsAssignableFrom(type))
            .ToArray();
        
        _menuIndex = 0;
        _menuList = new List<ILesson>();
        foreach (Type el in classesImplementingIList)
        {
            ILesson newPoint = (ILesson) Activator.CreateInstance(el);
            _menuList.Add(newPoint);
        }

        _menuList = _menuList.OrderBy(x => x.LessonNumber).ToList();
        Init();
    }

    private void DisplayMenu()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(_menuStartColumnPos, _menuStartRowPos);
        Console.Write("Выбор урока для отображения");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(_menuStartColumnPos, _menuStartRowPos + 1);
        Console.Write("Для премещения по пунктам используйте клавиши стрелок, для выбора - клавишу Enter, для выхода -Q ");

        for (int i = 0; i < _menuList.Count; i++)
        {
            string textToDisplay;
            Console.ResetColor();
            Console.SetCursorPosition(_menuStartColumnPos, i + 3 + _menuStartRowPos);
            if (i == _menuIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                textToDisplay = "-> " + "Урок № "+_menuList[i].LessonNumber;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                textToDisplay = "   " + "Урок № "+_menuList[i].LessonNumber;
            }

            Console.Write(textToDisplay);
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
        Console.ResetColor();
        Console.Clear();
        DisplayHeader();
        DisplayMenu();
    }


    //Рисует все что надо по заданию урока
    private void DisplayLesson(ILesson lesson)
    {
        Console.ResetColor();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.SetCursorPosition(0, 0);
        Console.Write(lesson.Descriptopn);
        Console.SetCursorPosition(0, 1);
        Console.ResetColor();
        lesson.Run();
        Console.Write("Нажмите любую клавишу для продолжения");
        Console.ReadKey(true);
        Repaint();
    }

    private void SetMenuIndex(int value)
    {
        if (value < 0)
        {
            _menuIndex = _menuList.Count - 1;
        }
        else if (value >= _menuList.Count)
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
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    --MenuIndex;
                    break;
                case ConsoleKey.DownArrow:
                    ++MenuIndex;
                    break;
                case ConsoleKey.Q: 
                    _goOn = false;
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

}