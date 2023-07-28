using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    abstract public class Game
    {
        //board
        public Board board;        
        protected int minBoardDimention;
        protected int maxBoardDimention;

        //sybols used by the board
        protected List<char> symbols;

        //properties
        public List<char> Symbols { get; protected set; }
        public string GameName { get; protected set; }

        public abstract void Play();
        public abstract bool CheckForWin(string[,] board);
        public abstract bool IsDraw(string[,] board);

    

        // Board setup
        public void BoardSetup() {

            // Prompt the user to choose board Length/height
            Console.WriteLine("Enter the board width of the board between " + minBoardDimention + " and " + maxBoardDimention);
            string userInput = Console.ReadLine();
            while (!GameManager.Validator.ValidateInput(userInput, minBoardDimention, maxBoardDimention))
            {
                Console.WriteLine("Error: Invalid input, please try again");
                userInput = Console.ReadLine();
            }
            board = new Board(Int32.Parse(userInput), Int32.Parse(userInput));
            //turnsLeft = board.matrix.GetLength(0) * board.matrix.GetLength(1);//count total turns possible
        }

        //print current state of the game board
        public void PrintMyBoard()
        {
            board.PrintBoard();
        }        
    }
}
