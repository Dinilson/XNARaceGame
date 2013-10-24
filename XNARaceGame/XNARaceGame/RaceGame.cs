﻿using System;
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
	public class RaceGame
	{
		//private readonly static int FPS = 60;

        public InputManager inputManager { get; set; }
        public GraphicsManager graphicsManager { get; set; }
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
			graphicsManager = new GraphicsManager(this, "appeltaart");
            soundManager = new SoundManager();
            entitiesInit();
		}

        private void entitiesInit() {
            entities = new List<Entity>();
            entities.Add(new Car(this, new Vector2(10, 10), 0));
        }

        public void render()
        {
           //GraphicsManager.Device.Clear(Color.Black);
            map.render(graphicsManager);
            foreach (Entity entity in entities)
            {
                if (entity.isVisible)
                {
                    entity.render(graphicsManager);
                }
            }
            ui.render(graphicsManager);
        }

		public void update(float dt)
		{
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
            graphicsManager.Run();
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
