using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class TicTacToeGame : Game
    {
        public int min = 3;
        public int max = 20;
        int turnsLeft; 


        public TicTacToeGame()
        {
            minBoardDimention = 3;
            maxBoardDimention = 15;
            Symbols = new List<char>();
            Symbols.Add('X');
            Symbols.Add('O');           

            BoardSetup();            
        }               
        
        // Board setup
        private void BoardSetup()
        {
            // Prompt the user to choose board Length/height
            Console.WriteLine("Enter the board width of the board between " + minBoardDimention + " and " + maxBoardDimention);
            string userInput = Console.ReadLine();
            while (!validate.ValidateInput(userInput, minBoardDimention, maxBoardDimention))
            {
                Console.WriteLine("Error: Invalid input, please try again");
                userInput = Console.ReadLine();
            }
            board = new Board(Int32.Parse(userInput), Int32.Parse(userInput));
            turnsLeft = board.matrix.GetLength(0) * board.matrix.GetLength(1);//count total turns possible
        }

        // helper function used to check if the values of multiple cells are equal
        private bool AreEqual(params string[] values)
        {
            return values.All(value => !string.IsNullOrEmpty(value) && value.Equals(values[0]));
        }

        //checks for three in a row in the horizontal, vertical, and diagonal directions by comparing the values of the cells in the n sized board array
        public override bool CheckForWin(string[,] board)
        {            
            // row
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col <= board.GetLength(1) - 3; col++)
                {
                    if (AreEqual(board[row, col], board[row, col + 1], board[row, col + 2]))
                    {
                        return true;
                    }
                }
            }
            //column
            for (int col = 0; col < board.GetLength(1); col++)
            {
                for (int row = 0; row <= board.GetLength(0) - 3; row++)
                {
                    if (AreEqual(board[row, col], board[row + 1, col], board[row + 2, col]))
                    {
                        return true;
                    }
                }
            }
            //diag
            for (int row = 0; row <= board.GetLength(0) - 3; row++)
            {
                for (int col = 0; col <= board.GetLength(1) - 3; col++)
                {
                    if (AreEqual(board[row, col], board[row + 1, col + 1], board[row + 2, col + 2]))
                    {
                        return true;
                    }
                }
            }
            for (int row = 0; row <= board.GetLength(0) - 3; row++)
            {
                for (int col = 2; col < board.GetLength(1); col++)
                {
                    if (AreEqual(board[row, col], board[row + 1, col - 1], board[row + 2, col - 2]))
                    {
                        return true;
                    }
                }
            }
            //no runs of 3 in a row
            return false;

        }

        // Add this new function to your Game class:
        public override bool IsDraw(string[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    // If any cell is empty, it's not a draw
                    if (board[row, col] == null)
                    {
                        return false;
                    }
                }
            }
            // If all cells are filled, it's a draw            
            return true;
        }

        public override void Play()
        {
            Player1 = playerFactory.CreatePlayer("AIPlayer", this);
            Player2 = playerFactory.CreatePlayer("HumanPlayer", this);
            while (!CheckForWin(board.matrix) || IsDraw(board.matrix))
            {
                Player1.MakeMove();
                board.PrintBoard();
                if (!CheckForWin(board.matrix) || IsDraw(board.matrix))
                {                    
                    Player2.MakeMove();
                    board.PrintBoard();
                }
            }
            if (IsDraw(board.matrix))
            {
                Console.WriteLine("It's a Draw!");
            }
        }
    }
}
