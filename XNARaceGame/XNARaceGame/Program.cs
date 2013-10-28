using System;
using System.Threading;

namespace XNARaceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            RaceGame game = new RaceGame();
            //Thread gameLoop = new Thread(game.run);
            //gameLoop.Start();
            
            game.Run();
        }
    }
}
