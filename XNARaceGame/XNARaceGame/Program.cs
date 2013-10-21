using System;
using System.Threading;

namespace XNARaceGame
{
    static class Program
    {
        static void Main(string[] args)
        {
            RaceGame game = new RaceGame();
            Thread t = new Thread(game.run);
            t.Start();
        }
    }
}
