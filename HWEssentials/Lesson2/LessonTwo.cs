using HWCommonInterfaces;

namespace HWEssentials.Lesson2
{
    public class LessonTwo:ILesson
    {
        public int LessonNumber { get; set; }
        public string Descriptopn { get; set; }

        public LessonTwo()
        {
            LessonNumber = 2;
            Descriptopn = "2";
        }

        public void Run()
        {
            Console.WriteLine(@"Задача 1. Реализация типа двусвязного списка. ");
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("a) создаем список чисел от 5 до 13");
            DoublyLinkedList doubleList = new DoublyLinkedList();
            for (int i = 5; i < 14; i++) doubleList.AddNode(i);
            Console.WriteLine(doubleList.ToString());
            Console.WriteLine();

            Console.WriteLine("б) Выбираем ноды с индексами 0, 3, 8");
            Console.WriteLine(doubleList.GetNodeByIndex(0).Value + " " + doubleList.GetNodeByIndex(3).Value + " " + doubleList.GetNodeByIndex(8).Value);
            Console.WriteLine();

            Console.WriteLine("в) вставляем ноды с полезно нагрузкой 333 после нодов с индексами 0 3 8");
            Node node = doubleList.GetNodeByIndex(0);
            doubleList.AddNodeAfter(node, 333);
            node = doubleList.GetNodeByIndex(4);
            doubleList.AddNodeAfter(node, 333);
            node = doubleList.GetNodeByIndex(10);
            doubleList.AddNodeAfter(node, 333);
            Console.WriteLine(doubleList.ToString());
            Console.WriteLine();

            Console.WriteLine("г) вставляем ноды с полезно нагрузкой 111 после нодов с индексами 0 4 10, но другим способом");
            doubleList.AddNodeAfterIndex(0, 111);
            doubleList.AddNodeAfterIndex(5, 111);
            doubleList.AddNodeAfterIndex(12, 111);
            Console.WriteLine(doubleList.ToString());
            Console.WriteLine();

            Console.WriteLine("д) Находим нод с полезной нагрузкой 10 и выводим на экран его полезную нагрузку");
            node = doubleList.FindNode(10);
            Console.WriteLine(node.Value);
            Console.WriteLine();

            Console.WriteLine("е) Выводим список и общее количество элементов");
            Console.WriteLine(doubleList.ToString());
            Console.WriteLine(doubleList.GetCount());
            Console.WriteLine();

            Console.WriteLine("ж) Удаляем элемент с номером 12");
            node = doubleList.GetNodeByIndex(12);
            doubleList.RemoveNode(node);
            Console.WriteLine(doubleList.ToString());
            Console.WriteLine(doubleList.GetCount());
            Console.WriteLine();

            Console.WriteLine("з) Удаляем еще один элемент с номером 12, но другим способом");
            doubleList.RemoveNode(12);
            Console.WriteLine(doubleList.ToString());
            Console.WriteLine(doubleList.GetCount());
            Console.WriteLine();
        }


    }
}
