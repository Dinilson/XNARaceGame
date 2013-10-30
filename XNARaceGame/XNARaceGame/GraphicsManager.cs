using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNARaceGame {
    public class GraphicsManager {

        private readonly static string WINDOW_TITLE = "appeltaart";
        private readonly static int SCREEN_WIDTH = 800;
        private readonly static int SCREEN_HEIGHT = 600;
        private readonly static float SCALE = 1.0f; // verander dit om de scherm grote te veranderen

        private RaceGame game;
        public GraphicsDeviceManager graphicsDeviceManager { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Dictionary<string, Texture2D> sprites { get; set; }

        public GraphicsManager(RaceGame game) {
            this.game = game;
            graphicsDeviceManager = new GraphicsDeviceManager(game);
            graphicsDeviceManager.PreferredBackBufferWidth = (int)(SCREEN_WIDTH*SCALE);
            graphicsDeviceManager.PreferredBackBufferHeight = (int)(SCREEN_HEIGHT*SCALE);
            game.Window.Title = WINDOW_TITLE;

            sprites = new Dictionary<string, Texture2D>();
        }

        public void initialize() {
            spriteBatch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
        }

        public void loadContent() {
            sprites["PetrolPowerup"] = game.content.Load<Texture2D>("petrolPowerup");
            sprites["RepairPowerup"] = game.content.Load<Texture2D>("healPowerup");
            sprites["Car"] = game.content.Load<Texture2D>("testau");
            sprites["Map_001"] = game.content.Load<Texture2D>("racetrackv2");
        }

        public void drawSprite(string name, int x, int y, int width, int height) {
            spriteBatch.Draw(sprites[name], new Rectangle((int)(x * SCALE), (int)(y * SCALE), (int)(width * SCALE), (int)(height * SCALE)), Color.White);
        }

        public void clearScreen(Color color) {
            graphicsDeviceManager.GraphicsDevice.Clear(color);
        }
    }
}
