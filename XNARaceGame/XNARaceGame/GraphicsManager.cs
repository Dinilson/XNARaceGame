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
        private Vector2 viewportCoords { get; set; }
        public Vector2 nextViewportCoords { get; set; }

        public GraphicsManager(RaceGame game) {
            this.game = game;
            viewportCoords = new Vector2(0, 0);
            graphicsDeviceManager = new GraphicsDeviceManager(game);
            graphicsDeviceManager.PreferredBackBufferWidth = SCREEN_WIDTH; // Schaalt screen width
            graphicsDeviceManager.PreferredBackBufferHeight = SCREEN_HEIGHT; // Schaalt screen height
            game.Window.Title = WINDOW_TITLE;

            sprites = new Dictionary<string, Texture2D>(); // 
        }

        public void initialize() {
            spriteBatch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
            updateViewport();
        }

        public void loadContent() {
            sprites["PetrolPowerup"] = game.content.Load<Texture2D>("petrolPowerup");
            sprites["RepairPowerup"] = game.content.Load<Texture2D>("healPowerup");
            sprites["Car"] = game.content.Load<Texture2D>("testau");
            sprites["Map_001"] = game.content.Load<Texture2D>("racetrackv2");
            sprites["CollisionMap_001"] = game.content.Load<Texture2D>("collisionmap");
        }

        public Texture2D getSprite(string name) {
            return sprites[name];
        }

        public void drawSprite(string name, int x, int y, int width, int height) {
            drawSprite(name, x, y, width, height, 0f);
        }

        public void drawSprite(string name, int x, int y, int width,  int height, float rotation) {
            spriteBatch.Draw(sprites[name], new Rectangle((int)(x * SCALE - viewportCoords.X), (int)(y * SCALE - viewportCoords.Y), (int)(width * SCALE), (int)(height * SCALE)), null, Color.White, rotation, new Vector2(width/2, height/2), SpriteEffects.None, 0f);
        }

        public void clearScreen(Color color) {
            graphicsDeviceManager.GraphicsDevice.Clear(color);
        }

        public void setViewportCoords (Vector2 coords) {
            nextViewportCoords = Vector2.Subtract(coords * SCALE, new Vector2(SCREEN_WIDTH / 2, SCREEN_HEIGHT / 2));
            nextViewportCoords = Vector2.Clamp(nextViewportCoords, new Vector2(-1920/2-SCREEN_WIDTH/2, -1080/2-SCREEN_HEIGHT/2), new Vector2(SCREEN_WIDTH/2, SCREEN_HEIGHT/2));
        }

        public void updateViewport() {
            Viewport vp = graphicsDeviceManager.GraphicsDevice.Viewport;
            vp.X = 0;
            vp.Y = 0;
            vp.Width = SCREEN_WIDTH;
            vp.Height = SCREEN_HEIGHT;
            graphicsDeviceManager.GraphicsDevice.Viewport = vp;
            viewportCoords = nextViewportCoords;
        }

        public void updateViewportCoords () {
            viewportCoords = nextViewportCoords;
        }
    }
}
