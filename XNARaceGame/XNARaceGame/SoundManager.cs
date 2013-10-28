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
    public class SoundManager
    {
        private RaceGame game;
        private Dictionary<string, SoundEffect> sounds;// een dictionairy voor de geluidseffecten
        private Dictionary<string, Song> songs; // dictionary voor muziek

        public SoundManager(RaceGame game)// constructor
        {
            this.game = game;
            sounds = new Dictionary<string, SoundEffect>();
            songs = new Dictionary<string, Song>();
        }


        protected void loadContent()// methode om geluiden te maken
        {
            loadSoundContent("powerup");
            loadMusicContent("menumuz");
        }

        private void loadSoundContent(string name)
        {
            sounds.Add(name, game.content.Load<SoundEffect>(name));

        }

        private void loadMusicContent(string name)
        {
            songs.Add(name, game.content.Load<Song>(name));

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
