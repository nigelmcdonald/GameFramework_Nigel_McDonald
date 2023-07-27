using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class PlayerFactory
    {
        public Player CreatePlayer(string playerType, Game theGame, string name)
        {
            // Factory method to create algorithms based on algorithmType parameter
            // Returns a concrete Algorithm instance based on the algorithmType

            switch (playerType.ToLower())
            {
                case "aiplayer":
                    return new AIPlayer(theGame, name);
                case "humanplayer":
                    return new HumanPlayer(theGame, name);
                default:
                    throw new ArgumentException("Invalid player type.");
            }
        }

        public List<string> GetAvailableAlgorithmNames()
        {
            return new List<string>
            {
                "AIPlayer",
                "HumanPlayer"
            };
        }
    }
}
