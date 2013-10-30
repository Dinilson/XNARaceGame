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
    // keybinding
	public class InputManager
	{
        public KeyboardState currentKeyState { get; set; }

		public InputManager()
		{
            currentKeyState = Keyboard.GetState(); 
		}
       
        public void handleGameInput(RaceGame game) {

            /*if (currentKeyState.IsKeyDown(Keys.W)) 
            {
                game.graphicsManager.graphicsDeviceManager.GraphicsDevice.Clear(Color.Red);
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
            }*/

            if (currentKeyState.IsKeyDown(Keys.P))
            {
                game.paused = !game.paused;
            }

            if (currentKeyState.IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }
        }

        public void update()
        {
            currentKeyState = Keyboard.GetState();
        }
	}
}

