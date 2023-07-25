using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class AIPlayer : Player
    {
        // Algorithm Setup
        protected static AlgorithmFactory algorithmFactory = new AlgorithmFactory();
        protected Algorithm selectedAlgorithm;
        public List<string> availableAlgorithmNames = algorithmFactory.GetAvailableAlgorithmNames();

        public AIPlayer(Game game) : base (game)
        {
            AlgorithmSetup();
        }

        private void AlgorithmSetup()
        {
            List<string> availableAlgorithmNames = algorithmFactory.GetAvailableAlgorithmNames();// Get Algos

            //Display Algorithms for the chosen game
            Console.WriteLine("Available Ai Algorithms: ");
            for (int i = 0; i < availableAlgorithmNames.Count; i++)
            {
                Console.WriteLine(i + " : " + availableAlgorithmNames[i]);
            }
            // Prompt the user to choose a game
            Console.WriteLine("Enter the number of the Algorithm you would like the AI player to use: ");

            string userInput = Console.ReadLine();
            while (!validate.ValidateInput(userInput, 0, availableAlgorithmNames.Count - 1))
            {
                Console.WriteLine("Error: Invalid input, please try again");
                userInput = Console.ReadLine();
            }

            // Algorithm instantiation
            selectedAlgorithm = algorithmFactory.CreateAlgorithm(availableAlgorithmNames[Int32.Parse(userInput)], thisGame);
        }

        public override void MakeMove()
        {
            selectedAlgorithm.MakeBestMove();
        }
    }
}
