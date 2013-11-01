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
        private List<Keys> keyPresslist { get; set; }

		public InputManager()
		{
            currentKeyState = Keyboard.GetState();
            keyPresslist = new List<Keys>();
		}

        private bool isSingleKeyPress(Keys key) {
            return currentKeyState.IsKeyDown(key) && !keyPresslist.Contains(key);
        }
       
        public void handleGameInput(RaceGame game, float dt) {
            if (isSingleKeyPress(Keys.P))
            {
                game.paused = !game.paused;
                keyPresslist.Add(Keys.P); // voeg toe aan single key press list
            }
            if (currentKeyState.IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }
            if(currentKeyState.IsKeyDown(Keys.O)) {
                game.graphicsManager.scale += 0.5f * dt;
            }
            if(currentKeyState.IsKeyDown(Keys.I)) {
                game.graphicsManager.scale -= 0.5f * dt;
            }

            foreach (Keys key in keyPresslist) {
                if(currentKeyState.IsKeyUp(key)) {
                    keyPresslist.Remove(key);
                }
            }
        }

        public void update()
        {
            currentKeyState = Keyboard.GetState();
        }
	}
}

