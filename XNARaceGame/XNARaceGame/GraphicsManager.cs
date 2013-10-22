using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace XNARaceGame {
    public class GraphicsManager : Microsoft.Xna.Framework.Game {

        public static GraphicsDeviceManager graphicsManager = null;
        public static SpriteBatch spriteBatch = null;
        public static ContentManager content = null;
        private static string remWindowsTitle = "";
        public static string WindowsTitle {
            get {
                return remWindowsTitle;
            }
        }
        

        public static GraphicsDevice Device {
            get {
                return graphicsManager.GraphicsDevice;
            }
        }

        protected static int width, height;

        public static int Width {
            get { return width; }
        }

        public static int Height {
            get { return height; }
        }

        public new static ContentManager Content {
            get {
                return content;
            }
        }

        public RaceGame game { get; set; }

        public GraphicsManager(RaceGame game, string setWindowsTitle) {
            this.game = game;
            graphicsManager = new GraphicsDeviceManager(this);

            graphicsManager.PreferredBackBufferHeight = 600;
            graphicsManager.PreferredBackBufferWidth = 800;

            GraphicsManager.content = base.Content;
            base.Content.RootDirectory = "Content";

            this.Window.Title = setWindowsTitle;
            remWindowsTitle = setWindowsTitle;
        }

        public GraphicsManager()
            : this(new RaceGame(), "Xna2DRacer") {
        }

        protected override void LoadContent() {
            //cloud = Content.Load<Texture2D>(@"Sprites\\Clouds");
            base.LoadContent();
          

        }

        void graphics_PrepareDevice(object sender, PreparingDeviceSettingsEventArgs e) {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT) {
                PresentationParameters presentParams =
                    e.GraphicsDeviceInformation.PresentationParameters;

                presentParams.RenderTargetUsage = RenderTargetUsage.PlatformContents;
                if (graphicsManager.PreferredBackBufferHeight == 720) {
                    presentParams.MultiSampleCount = 1;
                } else {
                    presentParams.MultiSampleCount = 1;
                }
            }
        }

        protected override void Initialize() {
            base.Initialize();
            spriteBatch = new SpriteBatch(Device);
        }

        protected override void Draw(GameTime gameTime) {
            game.render();
        }

        protected override void Update(GameTime gameTime) {
            game.update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}

