using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    abstract public class Player
    {
        protected Game thisGame;
        protected InputValidator validate = new InputValidator();

        public Player(Game game) { thisGame = game; }

        public abstract void MakeMove();

        // Common player methods...
    }
}
