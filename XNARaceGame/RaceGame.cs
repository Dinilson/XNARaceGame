﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNARaceGame
{
    class RaceGame : Microsoft.Xna.Framework.Game
    {
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

        public RaceGame()
        {
			graphics = new GraphicsDeviceManager(this);

        }

        public void run()
        {
        }
    }
}
