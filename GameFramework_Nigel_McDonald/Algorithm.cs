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
        protected string name;
        protected string [,] thisBoard;

        public string Name { get => name; protected set => name = value; }

        public abstract void MakeBestMove();
    }
}
