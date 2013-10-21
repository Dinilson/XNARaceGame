using System;
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
    public class SoundManager : Microsoft.Xna.Framework.Game
    {
        SoundEffect muz;
        public SoundManager()
        {

        }
        protected virtual void LoadContent()
        {
            muz = Content.Load<SoundEffect>("muziek1.wav");
        }

    }
}
