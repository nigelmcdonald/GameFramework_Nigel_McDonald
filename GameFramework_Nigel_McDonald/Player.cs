using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    abstract public class Player : IPlayerObserver
    {
        private string playerName;
        protected Game thisGame;
        protected InputValidator validate = new InputValidator();

        //properties
        public string PlayerName { get => playerName; protected set => playerName = value; }

        public Player(Game game, string name) 
        { 
            thisGame = game;
            playerName = name;
        }

        public abstract void MakeMove();

        public void Update(IPlayerObserverPattern patternHolder)
        {
            if (patternHolder is Game game)
            {
                Console.WriteLine(playerName + " the last move made was to row:" + game.MovesMade[0] + " Collumn: " + game.MovesMade[1]);
            }
        }

        // Common player methods...
    }
}
