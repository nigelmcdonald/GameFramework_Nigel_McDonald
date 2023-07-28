using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    abstract public class Player : IPlayerObserver
    {
        private string defaultPlayerType;
        private string playerName;


        //properties
        public string DefaultPlayerType { get; protected set; }
        public string PlayerName { get => playerName; set => playerName = value; }

        protected Player(string name) 
        { 
            playerName = name;
            GameManager.Instance.Subscribe(this); // sub ot observer pattern
        }

        public abstract void MakeMove();

        public void Update(IPlayerObserverPattern patternHolder)
        {
            //Console.WriteLine("DEBUGGING: Update Called!");//DEBUGGING
            if (patternHolder is GameManager manager)
            {
                Console.WriteLine(PlayerName + " the last move made was to row:" + GameManager.Instance.MovesMade[0] + " Collumn: " + GameManager.Instance.MovesMade[1]);
            }
        }

        // Common player methods...
    }
}
