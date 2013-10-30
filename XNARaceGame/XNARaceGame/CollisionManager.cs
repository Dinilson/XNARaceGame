using System;
using System.Collections.Generic;

namespace XNARaceGame
{
	class CollisionManager
	{
        // controleert voor de map of entity aan het collide is met map
		public static void CheckMapCollisions(Entity entity, Map map, double dt)
		{

		}

		public static void CheckEntityCollisions(Entity entity, List<Entity> entities, double dt)
		{
			if (entity.isActor && entity.isCollidable)
			{
				foreach (Entity e in entities)
				{
					if (e.isCollidable && EntitiesCollides(entity, e))
					{
                        e.entityCollision(entity);
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

