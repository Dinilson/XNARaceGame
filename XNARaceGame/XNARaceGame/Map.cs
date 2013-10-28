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
            GraphicsManager.spriteBatch = new SpriteBatch(GraphicsManager.Device);
        }
        

      
        public void render()
        {
           
           GraphicsManager.spriteBatch.Begin();
           GraphicsManager.spriteBatch.Draw(GraphicsManager.Content.Load<Texture2D>("testmap"),
               new Rectangle(0, 0, 800, 600),
               Color.White);
      
           GraphicsManager.spriteBatch.End();
            
        }

	}
}

