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
            if (currentKeyState.IsKeyDown(Keys.P))
            {
                game.paused = !game.paused;
            }
            if (currentKeyState.IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }
            if(currentKeyState.IsKeyDown(Keys.O)) {
                game.graphicsManager.scale += 0.01f;
            }
            if(currentKeyState.IsKeyDown(Keys.I)) {
                game.graphicsManager.scale -= 0.01f;
            }
        }

        public void update()
        {
            currentKeyState = Keyboard.GetState();
        }
	}
}

