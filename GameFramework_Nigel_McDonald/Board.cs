using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class Board
    {
        public int Width { get; }
        public int Height { get; }
        public string[,] matrix { get; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            matrix = new string[width, height];
        }

        //check if the cell is empty
        public bool CellIsEmpty(int row, int column)
        {
            if (matrix[row, column] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void PrintBoard()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("[" + matrix[i, j] + "\t" + "]");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
