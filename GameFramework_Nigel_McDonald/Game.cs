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

        //validation
        protected InputValidator validate = new InputValidator();            
        
        // Player Setup
        protected static PlayerFactory playerFactory = new PlayerFactory();
        protected Player Player1;//AI
        protected Player Player2;//Human

        //property
        public List<char> Symbols { get; protected set; }

        public abstract void Play();
        public abstract bool CheckForWin(string[,] board);
        public abstract bool IsDraw(string[,] board);

        public void PrintMyBoard()
        {
            board.PrintBoard();
        }
    }
}
