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

namespace XNARaceGame
{
    public class SoundManager : Microsoft.Xna.Framework.Game
    {

        private Dictionary<string, SoundEffect> sounds;// een dictionairy voor de geluidseffecten
        private Dictionary<string, Song> songs; // dictionary voor muziek

        public SoundManager()// constructor
        {
            sounds = new Dictionary<string, SoundEffect>();
            songs = new Dictionary<string, Song>();
            base.Content.RootDirectory = "Content";
            LoadContent();
        }


        protected override void LoadContent()// methode om geluiden te maken
        {
            //cloud = Content.Load<Texture2D>(@"Sprites\\Clouds");
            base.LoadContent();
            loadsoundContent("powerup");
            loadmuzContent("menumuz");
        }

        private void loadsoundContent(string name)
        {
            sounds.Add(name, Content.Load<SoundEffect>(name));

        }

        private void loadmuzContent(string name)
        {
            songs.Add(name, Content.Load<Song>(name));

        }
        public void playSound(string name)
        {
            sounds[name].Play();

        }
        public void playSong(string name)
        {
            MediaPlayer.Play(songs[name]);
        }
    }
}
