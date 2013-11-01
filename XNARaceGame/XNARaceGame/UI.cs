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
        private RaceGame game;

		public UI(RaceGame game)
		{
            this.game = game;
		}

        public void render(GraphicsManager graphicsManager) 
        {
            graphicsManager.drawText("font1", "dit is een text", new Vector(10, 10), Color.white, true);
        }
	}
}

