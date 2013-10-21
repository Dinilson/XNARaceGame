using System;
//using System.Windows.Forms;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework;

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
        //private Form form;
        private int screenWidth;
        private int screenHeight;

        public GraphicsManager(RaceGame game)
            : this(game, DEFAULT_SCREEN_WIDTH, DEFAULT_SCREEN_HEIGHT)
        {
        }

        public GraphicsManager(RaceGame game, int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.game = game;
            formInit(screenWidth, screenHeight);
            graphicsAdapter = GraphicsAdapter.DefaultAdapter;
            graphicsDeviceSettings = setupGraphicsDeviceSettings(new PresentationParameters(), this.form.Handle, screenWidth, screenHeight);
            graphicsDevice = new GraphicsDevice(graphicsAdapter, GraphicsProfile.Reach, graphicsDeviceSettings); // Does not take three arguments. Needs a fix. It does take three arguments
            spriteBatch = new SpriteBatch(graphicsDevice);
            graphicsDevice.Clear(Color.Red);
            Application.Run(form);
        }

        private static PresentationParameters setupGraphicsDeviceSettings(PresentationParameters parameters, IntPtr handle, int screenWidth, int screenHeight)
        {
            parameters.BackBufferWidth = screenWidth;
            parameters.BackBufferHeight = screenHeight;
            parameters.IsFullScreen = false;
            parameters.DeviceWindowHandle = handle;
            return parameters;
        }

        private void formInit(int width, int height)
        {
            form = new Form();
            form.Width = width + 10;
            form.Height = height + 10;
            form.Text = "Gamez";
            //Application.Run(form);
        }
    }
}

