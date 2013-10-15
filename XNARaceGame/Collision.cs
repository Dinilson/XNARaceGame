using System;
using System.Collections.Generic;

namespace XNARaceGame
{
	public class Collision
	{
		public static void CheckMapCollisions(int dt, Map map, List<Entity> entities)
		{

		}

		public static void CheckEntityCollisions(int dt, List<Entity> entities)
		{
			foreach (Entity entity in entities)
			{
				if (entity.Actor)
				{
					foreach (Entity e in entities)
					{
						if (collides(entity, e))
						{
							EntitiesCollide(entity, e);
						}
					}
				}
			}
		}

		public static void EntitiesCollide(Entity collider, Entity colliding)
		{

		}
	}
}

