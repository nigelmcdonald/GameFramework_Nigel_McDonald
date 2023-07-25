using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class HumanPlayer : Player
    {
        int row = 0;
        int column = 0;
        public HumanPlayer(Game theGame) : base(theGame) { }

        //this function asks the player to enter the cell in which they want to make a move
        // it repeats if the cell is already full
        public override void MakeMove()
        {
            do
            {
                Console.WriteLine("Human Players Turn. ");
                // Row
                Console.WriteLine("Enter the row: ");
                string userInput = Console.ReadLine();
                while (!validate.ValidateInput(userInput, 0, thisGame.board.matrix.GetLength(0) - 1))
                {
                    Console.WriteLine("Error: Invalid input, please try again");
                    userInput = Console.ReadLine();
                }
                row = Int32.Parse(userInput);

                // Column
                Console.WriteLine("Enter the column: ");
                userInput = Console.ReadLine();
                while (!validate.ValidateInput(userInput, 0, thisGame.board.matrix.GetLength(1) - 1))
                {
                    Console.WriteLine("Error: Invalid input, please try again");
                    userInput = Console.ReadLine();
                }
                column = Int32.Parse(userInput);
                if (!thisGame.board.CellIsEmpty(row, column))
                {
                    Console.WriteLine("Error: Cell already taken");
                }
            } while (!thisGame.board.CellIsEmpty(row, column));
            thisGame.board.matrix[row, column] = thisGame.Symbols[1].ToString();
        }
    }
}
