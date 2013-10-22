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
        private Dictionary<string, SoundEffect> sounds;

        public SoundManager()
        {
            sounds = new Dictionary<string, SoundEffect>();
            base.Content.RootDirectory = "Content";
            LoadContent();
        }
       

        protected override void LoadContent()
        {
            //cloud = Content.Load<Texture2D>(@"Sprites\\Clouds");
            base.LoadContent();
            loadContent("powerup");
        }

        private void loadContent(string name) {
                sounds.Add(name, Content.Load<SoundEffect>(name));
        }

        public void playSound(string name) {
            sounds[name].Play();
        }
    }
}
