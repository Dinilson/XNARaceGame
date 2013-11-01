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
        SpriteFont font1;
        Vector2 fontPosition;
        string text;
        Color color;
        
        private RaceGame game;

		public UI(RaceGame game)
		{
            this.game = game;
		}

        public void render(GraphicsManager graphicsManager) 
        {
            //lukas kijk hier ff na, ik weet niet wat ik verder moet.. of in moet laden
            fontPosition = new Vector2(0, 10);
            text = new string("lol?");
            color = new Color (Color.AntiqueWhite);
            
            graphicsManager.spriteBatch.DrawString(font1, text, fontPosition, color);
        }
	}
}

