using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class GameFactory
    {
        public Game CreateGame(string gameType)
        {
            // Factory method to create games based on gameType parameter
            // Returns a concrete Game instance based on the gameType

            switch (gameType.ToLower())
            {
                case "tictactoe":
                    return new TicTacToeGame();
                case "chess":
                    return new ChessGame();
                default:
                    throw new ArgumentException("Invalid game type.");
            }
        }
        public List<string> GetAvailableGameNames()
        {
            return new List<string>
            {
                "TicTacToe",
                "Chess"
            };
        }
        
    }

}
