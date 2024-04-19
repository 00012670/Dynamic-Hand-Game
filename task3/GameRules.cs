using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class GameRules
    {
        public string DetermineWinner(int computerMove, int playerMove, int totalMoves)
        {
            int p = totalMoves / 2;
            int difference = (computerMove - playerMove + p + totalMoves) % totalMoves;

            if (difference == p) // Check if the difference is equal to half of the total moves
            {
                return "Draw";
            }
            else if (difference <= p)
            {
                return "Win";
            }
            else
            {
                return "Lose";
            }
        }
    }
}
