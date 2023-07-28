using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Singleton Pattern
/// Also Implments and Observer Pattern
/// </summary>
namespace GameFramework
{
    class GameManager : IPlayerObserverPattern
    {
        private static GameManager instance = null; // instance
        private bool gameOver = false;

        //Player Observers
        private List<IPlayerObserver> playerObservers = new List<IPlayerObserver>();
        //Observer updateable info
        private int[] _movesMade = new int[2];
        public int[] MovesMade
        {
            get { return _movesMade; }
            set
            {
                _movesMade = value; //update the observers when the moves mad is updated
                Notify();
            }
        }

        //new validator
        private static InputValidator validator = new InputValidator();

        // Factories
        private static GameFactory gameFactory = new GameFactory();
        private static AlgorithmFactory algorithmFactory = new AlgorithmFactory();
        private static PlayerFactory playerFactory = new PlayerFactory();

        //instances
        private static Game selectedGame;
        private static Algorithm selectedAlgorithm;
        private static List<Player> players = new List<Player>();

        //properties
        public bool GameOver { get => gameOver; set => gameOver = value; }
        public static InputValidator Validator { get => validator; }
        public static GameFactory GameFact { get => gameFactory; }
        public static AlgorithmFactory AlgoFact { get => algorithmFactory; }
        public static PlayerFactory PlayerFact { get => playerFactory; }
        public static Game SelectedGame { get => selectedGame; set => selectedGame = value; }
        public static Algorithm SelectedAlgorithm { get => selectedAlgorithm; set => selectedAlgorithm = value; }
        public static List<Player> Players { get => players; set => players = value; }

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }            
        }

        

        //used to notify all of the registered Observer players of changes
        public void Notify()
        {
            //Console.WriteLine("DEBUGGING: Notify Called!");//DEBUGGING
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
