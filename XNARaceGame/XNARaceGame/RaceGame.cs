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

namespace XNARaceGame
{
    // hoofd gameklasse
	public class RaceGame : Microsoft.Xna.Framework.Game
	{
        public InputManager inputManager { get; set; }
        public ContentManager content { get; set; }
        public GraphicsManager graphicsManager { get; set; }
        public SoundManager soundManager { get; set; }
        public UI ui { get; set; }
        public Map map { get; set; }
        public List<Entity> entities { get; set; }
		public bool running { get; set; }
        public bool paused { get; set; }

		public RaceGame()
		{
			running = false;
			inputManager = new InputManager();
            graphicsManager = new GraphicsManager(this);
            soundManager = new SoundManager(this);
            ui = new UI(this);
            map = new Map();

            content = base.Content;
            content.RootDirectory = "Content";
		}

        private void entitiesInit() {
            entities = new List<Entity>();
            entities.Add(new Car(this, new Vector2(10, 10), 0));
            entities.Add(new Powerup(this, "Repair", true, true, new Vector2(200, 200)));
            entities.Add(new Powerup(this, "Petrol", true, true, new Vector2(-500, -150)));
            entities.Add(new Powerup(this, "Petrol", true, false, new Vector2(500, -175)));
            entities.Add(new Powerup(this, "Repair", true, false, new Vector2(495, -180)));
        }

        protected override void Initialize() {
            base.Initialize();
            graphicsManager.initialize();
        }

        protected override void LoadContent() {
            graphicsManager.loadContent();
            soundManager.loadContent(); //waarom deze verwijderen?
            entitiesInit();
        }

        protected override void Draw(GameTime gameTime)
        {
            graphicsManager.updateViewportCoords();
            graphicsManager.clearScreen(Color.Black);
            graphicsManager.spriteBatch.Begin();
            map.render(graphicsManager);
            foreach (Entity entity in entities)
            {
                if (entity.isVisible)
                {
                    entity.render(graphicsManager);  
                }
            }
            ui.render(graphicsManager);
            graphicsManager.spriteBatch.End();
        }

		protected override void Update(GameTime gameTime)
		{
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            inputManager.update();
            inputManager.handleGameInput(this);
            if (!paused) {
                foreach (Entity entity in entities) {
                    CollisionManager.CheckMapCollisions(entity, map, dt);
                    CollisionManager.CheckEntityCollisions(entity, entities, dt);
                    if (!entity.update(dt, inputManager)) {
                        entities.Remove(entity);
                    }
                }
            }
		}

		public void run()
		{
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
