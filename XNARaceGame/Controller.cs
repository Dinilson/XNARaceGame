using System;
using System.Collections.Generic;

namespace XNARaceGame
{
	public class Controller
	{
        public List<char> keyMap { get; set; }

        private RaceGame game;

		public Controller(RaceGame game)
		{
            this.game = game;
		}

        public void handleGameInput() {
            if(keyMap.Contains('p')) {
                game.paused = !game.paused;
            }
        }
	}
}

