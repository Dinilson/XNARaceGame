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
<<<<<<< HEAD
            //lukas kijk hier ff na, ik weet niet wat ik verder moet.. of in moet laden
            fontPosition = new Vector2(0, 10);
            text = "lol?";
            color = Color.AntiqueWhite;
            
            //graphicsManager.spriteBatch.DrawString(font1, text, fontPosition, color);
=======
            graphicsManager.drawText("font1", "dit is een text", new Vector2(10, 10), Color.White, true);
>>>>>>> 9edc656de4fbd40d77ac5812c02257683a8bf8bc
        }
	}
}

