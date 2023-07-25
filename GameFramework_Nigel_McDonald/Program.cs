using System;
using System.Collections.Generic;//lists

namespace GameFramework
{
    public class Program
    {
        static void Main()
        {
            //new validator
            InputValidator validate = new InputValidator();
            
            // Factories
            GameFactory gameFactory = new GameFactory();            
            List<string> availableGameNames = gameFactory.GetAvailableGameNames();// Get available game names
            

            // Display available game names to the user
            Console.WriteLine("Available Games:");
            for (int i = 0; i < availableGameNames.Count; i++)
            {
                Console.WriteLine(i + " : " + availableGameNames[i]);
            }        

            // Prompt the user to choose a game
            Console.WriteLine("Enter the number of the game you would like to play: ");
            string userInput = Console.ReadLine();
            while (!validate.ValidateInput(userInput, 0, availableGameNames.Count-1))
            {
                Console.WriteLine("Error: Invalid input, please try again");
                userInput = Console.ReadLine();
            }        

            //instantiate game using the gameFactory
            Game selectedGame = gameFactory.CreateGame(availableGameNames[Int32.Parse(userInput)]);// create the game instance
                        
            // Play the game
            selectedGame.Play();

            Console.WriteLine("Game Over!");
        }
    }
}
