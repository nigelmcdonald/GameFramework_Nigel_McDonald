using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    abstract public class Game : IPlayerObserverPattern
    {
        //Player Observers
        private List<IPlayerObserver> playerObservers;

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

        //observer updateable info
        private int[] _movesMade;
        public int[] MovesMade
        {
            get { return _movesMade; }
            set
            {
                _movesMade = value; //update the observers when the moves mad is updated
                Notify();
            }
        }

        public List<char> Symbols { get; protected set; }

        public abstract void Play();
        public abstract bool CheckForWin(string[,] board);
        public abstract bool IsDraw(string[,] board);

        //default game constructor
        public Game()
        {
            playerObservers = new List<IPlayerObserver>();
            _movesMade = new int[2];
        }

        //print current state of the game board
        public void PrintMyBoard()
        {
            board.PrintBoard();
        }

        //used to notify all of the registered Observer players of changes
        public void Notify()
        {
            for (int i = 0; i < playerObservers.Count; i++)
            {
                playerObservers[i].Update(this);
            }
        }

        //adds a new observer to the list to be updated of changes when they occur
        public void Subscribe(IPlayerObserver observer)
        {
            playerObservers.Add(observer);
        }
    }
}
