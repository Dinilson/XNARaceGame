using System;
using System.Collections.Generic;

namespace XNARaceGame
{
    public class InputManager
    {
        public List<char> keyMap { get; set; }

        private RaceGame game;

        public InputManager(RaceGame game)
        {
            this.game = game;
            keyMap = new List<char>();
        }

        public void handleGameInput()
        {
            if (keyMap.Contains('p'))
            {
                game.paused = !game.paused;
            }
        }
    }
}

