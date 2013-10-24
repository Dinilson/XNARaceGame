using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNARaceGame
{
	public class InputManager
	{
        /*
        public List<char> keyMap { get; set; }
        */
        private RaceGame game;
        public KeyboardState currentKeyState;

		public InputManager(RaceGame game)
		{
            this.game = game;
		}
       

        public void handleGameInput() {

            if (currentKeyState.IsKeyDown(Keys.W)) 
            {
                GraphicsManager.Device.Clear(Color.AliceBlue); // test
            }

            if (currentKeyState.IsKeyDown(Keys.A))
            {
                // Left
            }

            if (currentKeyState.IsKeyDown(Keys.S))
            {
                // Backward
            }

            if (currentKeyState.IsKeyDown(Keys.D))
            {
                // Right
            }

            if (currentKeyState.IsKeyDown(Keys.P))
            {
                game.paused = !game.paused;
            }

           
        }
        public void update()
        {
            currentKeyState = new KeyboardState();
        }
	}
}

