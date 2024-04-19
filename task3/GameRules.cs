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
            if (computerMove == playerMove)
            {
                return "Draw";
            }

            int difference = (totalMoves + computerMove - playerMove) % totalMoves;

            if (difference % 2 == 1)
            {
                return "Computer wins";
            }
            else
            {
                return "Player wins";
            }
        }
    }
}
