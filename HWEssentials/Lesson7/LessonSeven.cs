using HWCommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWEssentials.Lesson7
{
    internal class LessonSeven : ILesson
    {
        public int LessonNumber { get; set; }
        public string Descriptopn { get; set; }

        public LessonSeven()
        {
            LessonNumber = 7;
            Descriptopn = "Урок 7. Расставить 8 ферзей на шахматной доске, так, чтобы они не били друг друга";

            Init();
        }

        /// <summary>
        /// Иницифлизация
        /// </summary>
        private void Init()
        {

        }

        /// <summary>
        /// Основная функция урока
        /// </summary>
        public void Run()
        {
            QueensAranger chess = new QueensAranger(8);
            if (!chess.ArrangeQueens())
            {
                Console.WriteLine("У меня не получилось поставить 8 ферзей на доску 8**");
            }
            else
            {
                chess.DisplayChessboard();
            };

        }
    }
}
