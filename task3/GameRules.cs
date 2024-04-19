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

            int halfTotalMoves = totalMoves / 2;
            if (computerMove > playerMove)
            {
                if (computerMove - playerMove <= halfTotalMoves)
                {
                    return "Computer wins";
                }
                else
                {
                    return "Player wins";
                }
            }
            else
            {
                if (playerMove - computerMove <= halfTotalMoves)
                {
                    return "Player wins";
                }
                else
                {
                    return "Computer wins";
                }
            }
        }
    }
}
