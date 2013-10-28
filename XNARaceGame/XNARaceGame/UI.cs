using System;

namespace XNARaceGame
{
	public class UI
	{
        private RaceGame game;

		public UI(RaceGame game)
		{
            this.game = game;
		}

        public bool render(RaceGame game) {
            return false;
        }
	}
}

