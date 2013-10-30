using System;
using System.Threading;

namespace XNARaceGame
{
    class Program
    {
        // hoofdprogramma start game object
        static void Main(string[] args)
        {
            RaceGame game = new RaceGame();
            game.Run();
        }
    }
}
