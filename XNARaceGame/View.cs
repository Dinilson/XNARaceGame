using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;

namespace XNARaceGame
{
	public class View
	{
        public GraphicsDevice graphicsDevice { get; set; }
        public SpriteBatch spriteBatch { get; set; }

        private RaceGame game;

		public View(RaceGame game)
		{
            graphicsDevice = new GraphicsDevice();
            spriteBatch = new SpriteBatch(graphicsDevice);
            this.game = game;
		}
	}
}

