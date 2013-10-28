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
    class GraphicsManager {

        private readonly static string WINDOW_TITLE = "appeltaart";
        private readonly static int SCREEN_WIDTH = 800;
        private readonly static int SCREEN_HEIGHT = 600;
        private readonly static float SCALE = 2.0f;

        private RaceGame game;
        public GraphicsDeviceManager graphicsDeviceManager { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Dictionary<string, Texture2D> sprites { get; set; }

        public GraphicsManager(RaceGame game) {
            this.game = game;
            graphicsDeviceManager = new GraphicsDeviceManager(game);
            graphicsDeviceManager.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphicsDeviceManager.PreferredBackBufferHeight = SCREEN_HEIGHT;
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

        /*void graphics_PrepareDevice(object sender, PreparingDeviceSettingsEventArgs e) {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT) {
                PresentationParameters presentParams = e.GraphicsDeviceInformation.PresentationParameters;

                presentParams.RenderTargetUsage = RenderTargetUsage.PlatformContents;
                if (graphicsDeviceManager.PreferredBackBufferHeight == 720) {
                    presentParams.MultiSampleCount = 1;
                } else {
                    presentParams.MultiSampleCount = 1;
                }
            }
        }*/

        public void drawSprite(string name, int x, int y, int dx, int dy) {
            spriteBatch.Draw(sprites[name], new Rectangle(x, y, (int)(dx * SCALE), (int)(dy * SCALE)), Color.White);
        }

        public void clearScreen(Color color) {
            graphicsDeviceManager.GraphicsDevice.Clear(color);
        }
    }
}
