using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class AlgorithmFactory
    {
        private List<Algorithm> algorithms = new List<Algorithm>();// game holder

        //constructor
        public AlgorithmFactory()
        {
            algorithms.Add(new MinimaxAlgorithm());
            algorithms.Add(new GreedyAlgorithm());
            algorithms.Add(new ReinforcmentLearningAlgorithm());
        }

        public Algorithm CreateAlgorithm()
        {   // Factory method to create games based on gameType parameter
            // Returns a concrete Game instance based on the gameType           

            // Display available game names to the user
            Console.WriteLine("Available Algorithms:");
            for (int i = 0; i < algorithms.Count; i++)
            {
                Console.WriteLine(i + " : " + algorithms[i].Name);
            }

            // Prompt the user to choose a game
            Console.WriteLine("Enter the number of the algorithm you would like to play: ");
            string userInput = Console.ReadLine();
            while (!GameManager.Validator.ValidateInput(userInput, 0, algorithms.Count - 1))
            {
                Console.WriteLine("Error: Invalid input, please try again");
                userInput = Console.ReadLine();
            }
            int inputNumber = Int32.Parse(userInput);

            return algorithms[inputNumber];
        }
    }
}
