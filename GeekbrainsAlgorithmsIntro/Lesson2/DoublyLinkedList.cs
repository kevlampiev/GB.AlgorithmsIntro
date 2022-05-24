using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekbrainsAlgorithmsIntro.Lesson2
{
    public class DoublyLinkedList : ILinkedList
    {
        //Начальная и конечная ноды
        private Node _startNode;
        private Node _endNode;

        public Node StartNode { get => _startNode; }
        public Node EndNode { get => _endNode; }

        public DoublyLinkedList(Node startNode)
        {
            _startNode = startNode;
            _endNode = _startNode;
            _startNode.PrevNode = null; //Неизвестно с каким наследством пришел этот нод
            _startNode.NextNode = null;
        }

        public DoublyLinkedList(int value)
        {
            _startNode = CreateSingleNode(value);
            _endNode = _startNode;
        }

        public DoublyLinkedList()
        {
            _startNode = null;
            _endNode = null;
        }

        //Вспомогательная функция для создания одинокого нода (вне списка)
        private Node CreateSingleNode(int value)
        {
            return new Node() { Value = value, NextNode = null, PrevNode = null };
        }


        /// <summary>
        /// Получает Node по его номеру в списке
        /// </summary>
        /// <param name="index">Номер Node'a. Нумерация от нуля</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"> Исключение при отрицательном индексе или индексе большем чем количество элементов в списке</exception>
        public Node GetNodeByIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            };
            int currentIndex = 0;
            Node currentNode = _startNode;
            while (currentNode != null && currentIndex < index)
            {
                currentIndex++;
                currentNode = currentNode.NextNode;
            }

            if (currentNode == null)
            {
                throw new ArgumentOutOfRangeException();
            };


            return currentNode;
        }

        /// <summary>
        /// Добавляет новый нод в конец списка
        /// </summary>
        /// <param name="value">полезная нагрузка</param>
        public void AddNode(int value)
        {
            if (_endNode == null)
            {
                _startNode = CreateSingleNode(value);
                _endNode = _startNode;
            }
            else
            {
                Node neoNode = CreateSingleNode(value);
                neoNode.PrevNode = _endNode;
                _endNode.NextNode = neoNode;
                _endNode = neoNode;
            }
        }

        /// <summary>
        /// Добавляет нод после заданного
        /// </summary>
        /// <param name="node">Нод после которого надо вставить новый нод</param>
        /// <param name="value">Полезная нагрузка нового нода</param>
        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = CreateSingleNode(value);

            newNode.PrevNode = node;
            newNode.NextNode = node.NextNode;
            //Может так случиться, что вставляем после _endMode, тогда объявляем нового короля
            if (node == _endNode)
            {
                node.NextNode = newNode;
                _endNode = newNode;
            }
            else
            {
                node.NextNode.PrevNode = newNode;
                node.NextNode = newNode;
            }

        }


        /// <summary>
        /// Добавляет нод в определенную позицию
        /// </summary>
        /// <param name="index">Номер нода, после которого надо вставить новый нод</param>
        /// <param name="value">Полезная нагрузка нового нода</param>
        public void AddNodeAfterIndex(int index, int value)
        {
            Node node = GetNodeByIndex(index);
            AddNodeAfter(node, value);
        }


        /// <summary>
        /// Поиск номера по значению
        /// </summary>
        /// <param name="searchValue">Значение для поиска</param>
        /// <returns>нод </returns>
        public Node FindNode(int searchValue)
        {
            if (_startNode == null) return null;
            Node currentNode = _startNode;
            while (currentNode != null)
            {
                if (currentNode.Value == searchValue) return currentNode;
                currentNode = currentNode.NextNode;
            }
            return null;
        }

        /// <summary>
        /// Возвращает общее количество элементов в списке
        /// </summary>
        /// <returns>Кол-во элементов</returns>
        public int GetCount()
        {

            if (_startNode == null) return 0;

            Node currentNode = _startNode;
            int count = 1;
            while (currentNode.NextNode != null)
            {
                count++;
                currentNode = currentNode.NextNode;
            }
            return count;
        }

        /// <summary>
        /// Удаляет Node с определенным номером от начала списка
        /// </summary>
        /// <param name="index">Номер в списке от 0</param>
        public void RemoveNode(int index)
        {
            Node node = FindNode(index);
            RemoveNode(node);
        }

        /// <summary>
        /// Удаляет заданный node из списка
        /// </summary>
        /// <param name="node">нод из списка </param>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveNode(Node node)
        {
            if (node == null)
            {
                throw new ArgumentException();
            }

            if (node.PrevNode != null) node.PrevNode.NextNode = node.NextNode;

            if (node.NextNode != null) node.NextNode.PrevNode = node.PrevNode;

            if (node == _startNode) _startNode = _startNode.NextNode;

            if (node == _endNode) _endNode = _endNode.PrevNode;

            node.PrevNode = null;
            node.NextNode = null;

        }


        override public string ToString()
        {
            Node currentNode = _startNode;
            string resultString = "";

            while (currentNode != null)
            {
                resultString += "[" + currentNode.Value + "] -";
                currentNode = currentNode.NextNode;
            }

            return resultString;
        }

    }
}
