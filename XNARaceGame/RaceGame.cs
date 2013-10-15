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
	class RaceGame : Microsoft.Xna.Framework.Game
	{
		private static int FPS = 60;

		public  Map map { get; set; }
		public UI ui { get; set; }
		public Controller controller { get; }
		public View view { get; }
		public List<Entity> entities { get; }
		private bool running;
		private int nextTick;

		public RaceGame()
		{
			running = false;
			map = new Map();
			ui = new UI(this);
			controller = new Controller(this);
			view = new View(this);
		}

		public void render()
		{
			map.render(view);
			foreach (Entity entity in entities)
			{
				entity.render(view);
			}
		}

		public void update(int dt)
		{
			Collision.CheckMapCollisions(dt, map, entities);
			Collision.CheckEntityCollisions(dt, entities);

			foreach (Entity entity in entities)
			{
				if (!entity.update(dt, controller))
				{
					entities.Remove(entity);
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
					update(currentTick - lastTick);
					lastTick = currentTick;
				} while ((currentTick = Environment.TickCount) < nextTick);
				render();
				nextTick += 1000 / FPS;
			}
		}
	}
}
