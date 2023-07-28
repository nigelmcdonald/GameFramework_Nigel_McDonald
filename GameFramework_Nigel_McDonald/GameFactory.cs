using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class GameFactory
    {
        private List<Game> games = new List<Game>();// game holder
        
        //constructor
        public GameFactory()
        {
            games.Add(new TicTacToeGame());
            games.Add(new ChessGame());
            games.Add(new BackgammonGame());
        }

        public Game CreateGame()
        {   // Factory method to create games based on gameType parameter
            // Returns a concrete Game instance based on the gameType           

            // Display available game names to the user
            Console.WriteLine("Available Games:");
            for (int i = 0; i < games.Count; i++)
            {
                Console.WriteLine(i + " : " + games[i].GameName);
            }

            // Prompt the user to choose a game
            Console.WriteLine("Enter the number of the game you would like to play: ");
            string userInput = Console.ReadLine();
            while (!GameManager.Validator.ValidateInput(userInput, 0, games.Count - 1))
            {
                Console.WriteLine("Error: Invalid input, please try again");
                userInput = Console.ReadLine();
            }
            int inputNumber = Int32.Parse(userInput);

            return games[inputNumber];
        }        
    }
}
