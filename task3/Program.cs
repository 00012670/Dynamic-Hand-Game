using System.Security.Cryptography;
using System.Text;
using task3;

internal class Program
{
    static void Main(string[] args)
    {
        var game = new GameFlowManager(args);
        if (!game.AreMovesValid())
        {
            return;
        }
        while (true)
        {
            game.Play();
        }
    }
}






