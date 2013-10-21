using System;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;

namespace XNARaceGame
{
	public class GraphicsManager
	{
        public readonly static int DEFAULT_SCREEN_WIDTH = 800;
        public readonly static int DEFAULT_SCREEN_HEIGHT = 600;
        
        public GraphicsDevice graphicsDevice { get; set; }
        public GraphicsAdapter graphicsAdapter { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public PresentationParameters graphicsDeviceSettings { get; set; }

        private RaceGame game;
        private Form form;
        private int screenWidth;
        private int screenHeight;

        public GraphicsManager(RaceGame game)
            : this(game, DEFAULT_SCREEN_WIDTH, DEFAULT_SCREEN_HEIGHT) {
        }

		public GraphicsManager(RaceGame game, int screenWidth, int screenHeight)
		{
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.game = game;
            form = new Form();
            //form.Size = new Size(screenWidth, screenHeight);
            graphicsAdapter = GraphicsAdapter.DefaultAdapter;
            graphicsDeviceSettings = setupGraphicsDeviceSettings(new PresentationParameters(), form.Handle, screenWidth, screenHeight);
            graphicsDevice = new GraphicsDevice(graphicsAdapter, GraphicsProfile.Reach, graphicsDeviceSettings); // Does not take three arguments. Needs a fix.
            spriteBatch = new SpriteBatch(graphicsDevice);
            form.Show();
		}

        private static PresentationParameters setupGraphicsDeviceSettings(PresentationParameters parameters, IntPtr handle, int screenWidth, int screenHeight) {
            parameters.BackBufferWidth = screenWidth;
            parameters.BackBufferHeight = screenHeight;
            parameters.IsFullScreen = false;
            parameters.DeviceWindowHandle = handle;
            return parameters;
        }
	}
}
