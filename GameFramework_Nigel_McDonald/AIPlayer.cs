using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class AIPlayer : Player
    {

        public AIPlayer(string name) : base (name)  {
            DefaultPlayerType = "AI Player";
        }        

        public override void MakeMove()
        {
            GameManager.SelectedAlgorithm.MakeBestMove();
        }
    }
}
