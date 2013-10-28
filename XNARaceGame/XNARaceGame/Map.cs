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
	public class Map
	{
         
		public Map()
		{
        }
        
        public void render(RaceGame game)
        {
           
           //game.spriteBatch.Begin();
           game.spriteBatch.Draw(game.content.Load<Texture2D>("racetrackv2"), new Rectangle(0, 0, 1280, 720),Color.White);
           //game.spriteBatch.End();
            
        }

	}
}

