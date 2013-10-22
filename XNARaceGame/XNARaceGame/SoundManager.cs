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
using Microsoft.Xna.Framework.Storage;

namespace XNARaceGame {
    public class SoundManager : Microsoft.Xna.Framework.Game
    {
        public SoundEffect pow { get; set; }

        public SoundManager()
        {
            base.Content.RootDirectory = "Content";
            LoadContent();
        }
       

        protected override void LoadContent()
        {
           
            //cloud = Content.Load<Texture2D>(@"Sprites\\Clouds");
            base.LoadContent();
            pow = Content.Load<SoundEffect>("powerup");

        }

       
    }
}
