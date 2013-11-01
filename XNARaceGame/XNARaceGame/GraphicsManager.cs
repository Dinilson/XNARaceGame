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
    // regelt alle grafische aspecten van de game
    public class GraphicsManager {

        private readonly static string WINDOW_TITLE = "appeltaart";
        private readonly static int SCREEN_WIDTH = 1280;
        private readonly static int SCREEN_HEIGHT = 720;
        private readonly static float SCALE = 2.0f; // verander dit om de scherm grote te veranderen

        private RaceGame game;
        public GraphicsDeviceManager graphicsDeviceManager { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Dictionary<string, Texture2D> sprites { get; set; }
        public Dictionary<string, SpriteFont> fonts { get; set; }
        public List<Camera> cameras { get; set; }
        public Camera currentCamera { get; set; }

        public float scale { get; set; }

        public GraphicsManager(RaceGame game) {
            this.game = game;
            scale = SCALE;
            currentCamera.coords = new Vector2(0, 0);
            graphicsDeviceManager = new GraphicsDeviceManager(game);
            graphicsDeviceManager.PreferredBackBufferWidth = SCREEN_WIDTH; // Schaalt screen width
            graphicsDeviceManager.PreferredBackBufferHeight = SCREEN_HEIGHT; // Schaalt screen height
            game.Window.Title = WINDOW_TITLE;

            sprites = new Dictionary<string, Texture2D>(); // 
            fonts = new Dictionary<string, SpriteFont>();
            cameras = new List<Camera>();
        }

        public void initialize() {
            spriteBatch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
        }

        public void loadContent() {
            sprites["PetrolPowerup"] = game.content.Load<Texture2D>("petrolPowerup");
            sprites["RepairPowerup"] = game.content.Load<Texture2D>("healPowerup");
            sprites["Car"] = game.content.Load<Texture2D>("testau");
            sprites["Map_001"] = game.content.Load<Texture2D>("racetrackv2");
            sprites["CollisionMap_001"] = game.content.Load<Texture2D>("racetrackcoll");
            
            fonts["font1"] = game.content.Load<SpriteFont>("Spritefont uI");
        }

        public Texture2D getSprite(string name) {
            return sprites[name];
        }

        public void drawSprite(string name, int x, int y, int width, int height) {
            drawSprite(name, x, y, width, height, 0f);
        }

        public void drawSprite(string name, int x, int y, int width,  int height, float rotation) {
            spriteBatch.Draw(sprites[name], new Rectangle((int)(x * scale - currentCamera.coords.X), (int)(y * scale - currentCamera.coords.Y), (int)(width * scale), (int)(height * scale)), null, Color.White, rotation, new Vector2(width/2, height/2), SpriteEffects.None, 0f);
        }
        
        public void drawText(string name, string text, Vector2 location, Color color, bool relative) {
            if (!relative) {
                location = Vector2.Subtract(location * scale, currentCamera.coords);
            }
            spriteBatch.DrawString(fonts[name], text, location, color);
        }

        public void clearScreen(Color color) {
            graphicsDeviceManager.GraphicsDevice.Clear(color);
        }

        public List<Camera> addCameras(int n) {
            if(n == 2) {
                cameras.Add(new Camera(graphicsDeviceManager.GraphicsDevice.Viewport, 0, 0, SCREEN_WIDTH/2, SCREEN_HEIGHT));
                cameras.Add(new Camera(graphicsDeviceManager.GraphicsDevice.Viewport, SCREEN_WIDTH/2, 0, SCREEN_WIDTH/2, SCREEN_HEIGHT));
            }
            return cameras;
        }
    }
}
