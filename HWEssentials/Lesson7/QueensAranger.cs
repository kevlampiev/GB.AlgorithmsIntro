using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWEssentials.Lesson7
{

    internal class QueensAranger
    {
        //Шахматная доска
        private List<ChessCell> _chessboard;

        //все ферзи
        private List<ChessCell> _queens;


        /// <summary>
        /// Количетсво клеток шахматной доски
        /// </summary>
        int DimensionSize { get; set; }
        /// <summary>
        /// Количество ферзей, которое требуется разместить на шахматной доске
        /// </summary>
        int QueensCount { get; }

        public QueensAranger(int dimensionSize = 8)
        {
            DimensionSize = Math.Max(dimensionSize, 4);
            InitChessboards(DimensionSize);
            _queens = new List<ChessCell>(); //пока пусто
        }

        //Генерация пустой доски
        private void InitChessboards(int dimentionSize)
        {
            _chessboard = new List<ChessCell>();
            _queens = new List<ChessCell>(); //пока пусто
            for (int i = 0; i < dimentionSize; i++)
            {
                for (int j = 0; j < dimentionSize; j++)
                {
                    _chessboard.Add(new ChessCell() { x = i, y = j });
                }
            }

        }



        public bool ArrangeQueens()
        {
            return AddQueens(_chessboard, 0);
        }

        /// <summary>
        /// Возвращает сокращенный набор возможностей, после постановки нового ферзя на доску
        /// </summary>
        /// <param name="availabilities">Набор возможностей до постановки ферзя</param>
        /// <param name="queen">Новый ферзь, сокращающий набор возможностей</param>
        /// <returns></returns>
        private List<ChessCell> GetReducedAvailabilities(List<ChessCell> availabilities, ChessCell queen)
        {
            List<ChessCell> newAvailabilities = new List<ChessCell>();
            foreach (ChessCell el in availabilities)
            {
                if (el.x != queen.x && el.y != queen.y && el.axisOne != queen.axisOne && el.axisTwo != queen.axisTwo)
                {
                    newAvailabilities.Add(el);
                }
            }

            return newAvailabilities;

        }


        /// <summary>
        /// Рекурсивно подставляем ферзей. Построчно, поскольку в одной строке и одном столбце не может быть более одного ферзя
        /// </summary>
        /// <param name="availabilities">массив возможностей </param>
        /// <param name="level"> номер (уровень) ферзя</param>
        /// <returns>признак учпешности или неуспешности расстановки</returns>
        private bool AddQueens(List<ChessCell> availabilities, int level)
        {
            if (level >= DimensionSize) return true;

            bool success = false;

            foreach (ChessCell pretender in availabilities)
            {
                if (pretender.x == level)
                {
                    _queens.Add(pretender);
                    success = AddQueens(GetReducedAvailabilities(availabilities, pretender), level + 1);
                    if (success)
                    {
                        break; //получилось, прекращаем
                    }
                    else
                    {
                        _queens.Remove(pretender); //не получилось
                    }
                }
            }

            return success;
        }


        public void DisplayChessboard()
        {
            _queens.Sort((a, b) => a.y.CompareTo(b.y)); //а мало ли что
            int row = 8;
            foreach (ChessCell queen in _queens)
            {
                Console.Write((row--) + "│");
                for (int i = 0; i < DimensionSize; i++)
                {
                    string output = (i == queen.x) ? " Q " : " . ";
                    Console.Write(output);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  " + "".PadLeft(24, '─'));
            Console.WriteLine("   A  B  C  D  E  F  G  H");

        }


    }
}
