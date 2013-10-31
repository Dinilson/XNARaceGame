using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace XNARaceGame
{
    //tekent de map
	public class Map
	{
        private RaceGame game;
        public string currentMap {get;set;}

		public Map(RaceGame game, string currentMap)
		{
            this.game = game;
            this.currentMap = currentMap;
        }

        public Texture2D getCurrentMapTexture() {
            return game.graphicsManager.getSprite(currentMap);
        }

        public void render(GraphicsManager graphicsManager)
        {
            graphicsManager.drawSprite(currentMap, 0, 0, 1920, 1080);
        }

	}
}

