using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class TableGenerator
    {
        private GameRules gameRules;

        public TableGenerator(GameRules gameRules)
        {
            this.gameRules = gameRules;
        }

        public void GenerateTable(string[] moves)
        {
            Console.WriteLine();
            Console.WriteLine("The table below shows the result of each possible move combination. " +
                              "\nThe results are from the user's point of view. " +
                              "\n\"Win\" means the user's move wins against the computer's move.");
            Console.WriteLine();
            var table = new ConsoleTable("V PC\\User >".PadRight(10));
            table.AddColumn(moves);
            for (int i = 0; i < moves.Length; i++)
            {
                var row = new List<string> { moves[i] };
                for (int j = 0; j < moves.Length; j++)
                {
                    var result = gameRules.DetermineWinner(i, j, moves.Length);
                    row.Add(result);
                }
                table.AddRow(row.ToArray());
            }
            table.Write();
        }
    }
}
