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
	public class RaceGame : Microsoft.Xna.Framework.Game
	{
		private readonly static int FPS = 60;

		public Map map { get; set; }
		public UI ui { get; set; }
        public InputManager inputManager { get; set; }
        public GraphicsManager graphicsManager { get; set; }
        public List<Entity> entities { get; set; }
		public bool running { get; set; }
        public bool paused { get; set; }

		private int nextTick;

		public RaceGame()
		{
			running = false;
			map = new Map();
			ui = new UI(this);
			inputManager = new InputManager(this);
			graphicsManager = new GraphicsManager(this);
            entities = new List<Entity>();
		}

		public void render()
		{
			map.render(graphicsManager);
			foreach (Entity entity in entities)
			{
                if (entity.isVisible) {
                    entity.render(graphicsManager);
                }
			}
            ui.render(graphicsManager);
		}

		public void update(double dt)
		{
            if (!paused) {
                inputManager.handleGameInput();

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
			}
		}
	}
}
