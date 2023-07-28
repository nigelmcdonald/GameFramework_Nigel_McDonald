using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class PlayerFactory
    {
        private List<Player> players = new List<Player>();// game holder

        //constructor
        public PlayerFactory()
        {
            players.Add(new AIPlayer(".."));
            players.Add(new HumanPlayer(".."));
        }

        public Player CreatePlayer()
        {   // Factory method to create players
            // Returns a concrete Player instance based on selection from players list           

            // Display available player types to the user
            Console.WriteLine("Available Player Types:");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine(i + " : " + players[i].DefaultPlayerType);
            }

            // Prompt the user to create a player
            Console.WriteLine("Enter type of player you would like to create: ");
            string userInput = Console.ReadLine();
            while (!GameManager.Validator.ValidateInput(userInput, 0, players.Count - 1))
            {
                Console.WriteLine("Error: Invalid input, please try again");
                userInput = Console.ReadLine();
            }
            int typeNumber = Int32.Parse(userInput);// number selection of player type storage

            
            //setup player name
            Console.WriteLine("Enter that players name: ");
            userInput = Console.ReadLine();           
            players[typeNumber].PlayerName = userInput;
            
            return players[typeNumber];
        }
    }
}
