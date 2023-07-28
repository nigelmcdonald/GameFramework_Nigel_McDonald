using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class BackgammonGame : Game
    {
        public BackgammonGame()
        {
            GameName = "Backgammon";
        }


        public override bool CheckForWin(string[,] board)
        {
            throw new NotImplementedException();
        }

        public override bool IsDraw(string[,] board)
        {
            throw new NotImplementedException();
        }

        public override void Play()
        {
            throw new NotImplementedException();
        }
    }
}
