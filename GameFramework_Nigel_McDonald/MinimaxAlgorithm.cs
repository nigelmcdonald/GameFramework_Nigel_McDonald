﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;


namespace GameFramework
{
    class MinimaxAlgorithm : Algorithm
    {
        private const int MaxDepth = 20; // Maximum depth for the search to limit time taken
        int boardLength; // size of the board

        public MinimaxAlgorithm(Game theGame) : base(theGame){}

        public override void MakeBestMove()
        {
            //thisBoard = thisGame.board.matrix;            
            int bestScore = int.MinValue;
            int[] bestMove = new int[2];
            boardLength = thisGame.board.matrix.GetLength(0) * thisGame.board.matrix.GetLength(1);

            // Iterate over each possible move
            for (int row = 0; row < thisGame.board.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < thisGame.board.matrix.GetLength(1); col++)
                {
                    // Check if the current cell is empty
                    if (thisGame.board.matrix[row, col] == null)
                    {
                        // Make a copy of the board
                        string[,] boardCopy = (string[,])thisGame.board.matrix.Clone();
                        // Make the move on the copied board
                        boardCopy[row, col] = thisGame.Symbols[0].ToString();

                        // Recursively evaluate the current move
                        int score = Minimax(boardCopy, 0, false);

                        // Update the best move if a higher score is found
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove[0] = row;
                            bestMove[1] = col;
                        }
                    }
                }
            }
            //make the best Move found;
            thisGame.board.matrix[bestMove[0], bestMove[1]] = thisGame.Symbols[0].ToString();
            //update last move made
            thisGame.MovesMade[0] = bestMove[0];
            thisGame.MovesMade[1] = bestMove[1];

        }

        private int Minimax(string[,] board, int depth, bool isMaximizingPlayer)
        {
            //Console.WriteLine($"Starting minimax: depth={depth}, isMaximizingPlayer={isMaximizingPlayer}");//DEBUGGING

            // Check if the game is over or maximum depth is reached
            if (thisGame.CheckForWin(board) && !isMaximizingPlayer)
            {
                //return Evaluate(board);
                return boardLength - depth; // path weighting to make the AI choose the quickest path to a win
            }
            else if (thisGame.CheckForWin(board) && isMaximizingPlayer)
            {
                //return Evaluate(board);
                return -boardLength + depth; // path weighting to make the AI choose the quickest path to a win
            }
            else if (thisGame.IsDraw(board)) // Add a new function to check for a draw
            {
                return 0; // Or any score that represents a draw
            }
            else if (depth == MaxDepth)
            {
                if (isMaximizingPlayer)
                {
                    return -boardLength + depth * 2;
                }
                else
                {
                    return boardLength - depth * 2;
                }
            }

            if (isMaximizingPlayer)
            {
                int bestScore = -boardLength;//-(board.GetLength(0) ^ 2); // dynamic score based on baord size

                // Iterate over each possible move
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        // Check if the current cell is empty
                        if (board[row, col] == null)
                        {
                            //Console.WriteLine($"Evaluating move: row={row}, col={col}");//DEBUGGING

                            // Make a copy of the board
                            string[,] boardCopy = (string[,])board.Clone();

                            // Make the move on the copied board
                            boardCopy[row, col] = thisGame.Symbols[0].ToString(); // Assuming player 1 is maximizing player

                            // Recursively evaluate the current move for the minimizing player
                            int score = Minimax(boardCopy, depth + 1, false);

                            //Console.WriteLine($"Finished evaluating move: row={row}, col={col}, score={score}");//DEBUGGING

                            // Update the best score
                            bestScore = Math.Max(bestScore, score);
                        }
                    }
                }
                return bestScore;
            }
            else //minimizing player
            {
                int bestScore = boardLength;//board.GetLength(0)^2;

                // Iterate over each possible move
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        // Check if the current cell is empty
                        if (board[row, col] == null)
                        {
                            //Console.WriteLine($"Evaluating move: row={row}, col={col}");//DEBUGGING

                            // Make a copy of the board
                            string[,] boardCopy = (string[,])board.Clone();

                            // Make the move on the copied board
                            boardCopy[row, col] = thisGame.Symbols[1].ToString(); // Assuming player 2 is minimizing player

                            // Recursively evaluate the current move for the maximizing player
                            int score = Minimax(boardCopy, depth + 1, true);

                            //Console.WriteLine($"Finished evaluating move: row={row}, col={col}, score={score}");//DEBUGGING

                            // Update the best score
                            bestScore = Math.Min(bestScore, score);
                        }
                    }
                }
                return bestScore;
            }
        }
    }
}
