using System;
using System.Collections.Generic;

namespace XNARaceGame
{
	class Collision
	{
		public static void CheckMapCollisions(int dt, Map map, List<Entity> entities)
		{

		}

		public static void CheckEntityCollisions(int dt, List<Entity> entities)
		{
			foreach (Entity entity in entities)
			{
				if (entity.isActor && entity.isCollidable)
				{
					foreach (Entity e in entities)
					{
						if (e.isCollidable && EntitiesCollides(entity, e))
						{
							e.entityCollide(entity);
						}
					}
				}
			}
		}

		public static bool EntitiesCollides(Entity collider, Entity colliding)
		{
			return false;
		}
	}
}

