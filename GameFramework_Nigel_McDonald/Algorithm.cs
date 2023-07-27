using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    //using generics to allow these algorithms to apply across different games
    abstract public class Algorithm
    {
        protected Game thisGame;
        protected string [,] thisBoard;        

        public Algorithm (Game game)
        {
            thisGame = game;
        }
        public abstract void MakeBestMove();
    }
}
