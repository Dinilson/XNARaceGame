using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNARaceGame
{
	public class RaceGame : Microsoft.Xna.Framework.Game
	{
		private readonly static String TITLE_NAME = "appeltaart";
        private readonly static int SCREEN_WIDTH = 800;
        private readonly static int SCREEN_HEIGHT = 600;

        public InputManager inputManager { get; set; }
        public GraphicsDeviceManager graphicsManager { get; set; }
        public ContentManager content { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public SoundManager soundManager { get; set; }
        public UI ui { get; set; }
        public Map map { get; set; }
        public List<Entity> entities { get; set; }
		public bool running { get; set; }
        public bool paused { get; set; }

		//private int nextTick;

		public RaceGame()
		{
			running = false;
			map = new Map();
			ui = new UI(this);
			inputManager = new InputManager(this);
            soundManager = new SoundManager();

            graphicsManager = new GraphicsDeviceManager(this);
            graphicsManager.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphicsManager.PreferredBackBufferHeight = SCREEN_HEIGHT;
            content = base.Content;
            base.Content.RootDirectory = "Content";

            this.Window.Title = TITLE_NAME;

            entitiesInit();
		}

        private void entitiesInit() {
            entities = new List<Entity>();
            entities.Add(new Car(this, new Vector2(10, 10), 0));
        }

        protected override void Initialize() {
            base.Initialize();
            spriteBatch = new SpriteBatch(graphicsManager.GraphicsDevice);
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

        protected override void Draw(GameTime gameTime)
        {
            graphicsManager.GraphicsDevice.Clear(Color.Black);
           //Device.Clear(Color.Black);
            spriteBatch.Begin();
            map.render(this);
            foreach (Entity entity in entities)
            {
                if (entity.isVisible)
                {
                    entity.render(this);  
                }
            }
            ui.render(this);
            spriteBatch.End();
        }

		protected override void Update(GameTime gameTime)
		{
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            inputManager.update();
            inputManager.handleGameInput();
            if (!paused) {
                

                CollisionManager.CheckMapCollisions(dt, map, entities);
                CollisionManager.CheckEntityCollisions(dt, entities);

                foreach (Entity entity in entities) {
                    if (!entity.update(dt, inputManager)) {
                        entities.Remove(entity);
                    }
                }
            }
		}

		public void run()
		{
            //graphicsManager.Run();
            /*
			nextTick = Environment.TickCount + 1000 / FPS;
			int currentTick = Environment.TickCount;
			int lastTick = currentTick;
			running = true;
			while (running)
			{
				do
				{
					update((currentTick - lastTick) / 1000);
					lastTick = currentTick;
				} while ((currentTick = Environment.TickCount) < nextTick);
				render();
				nextTick += 1000 / FPS;
			}*/
		}
	}
}
