using System;
using System.Collections.Generic;//lists

namespace GameFramework
{
    public class Program
    {
        static void Main()
        {
            //instantiate objects using their Factories
            GameManager.SelectedGame = GameManager.GameFact.CreateGame();
            GameManager.SelectedGame.BoardSetup();
            GameManager.SelectedAlgorithm = GameManager.AlgoFact.CreateAlgorithm();
            for (int i = 0; i < 2; i++)
            {
                GameManager.Players.Add(GameManager.PlayerFact.CreatePlayer());
            }
            GameManager.SelectedGame.Play();

            Console.WriteLine("GAME OVER!");
        }
    }
}
