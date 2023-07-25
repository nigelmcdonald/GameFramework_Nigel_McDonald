using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class AlgorithmFactory
    {
        public Algorithm CreateAlgorithm(string algorithmType, Game theGame)
        {
            // Factory method to create algorithms based on algorithmType parameter
            // Returns a concrete Algorithm instance based on the algorithmType

            switch (algorithmType.ToLower())
            {
                case "minimax":
                    return new MinimaxAlgorithm(theGame);
                case "greedy":
                    return new GreedyAlgorithm(theGame);
                default:
                    throw new ArgumentException("Invalid algorithm type.");
            }
        }

        public List<string> GetAvailableAlgorithmNames()
        {
            return new List<string>
            {
                "Minimax",
                "Greedy"
            };
        }
    }
}
