using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNARaceGame
{
    // tekent de userinterface
	public class UI
	{
        private string text;

		public UI(RaceGame game)
		{
            update(game);
		}

        public void update(RaceGame game) {
            text = "Staat de game op pauze? " + (game.running? "Ja.": "Nee");
        }

        public void render(GraphicsManager graphicsManager)
        {
            graphicsManager.drawText("font1", text, new Vector2(10, 10), Color.White, true);
        }
	}
}

