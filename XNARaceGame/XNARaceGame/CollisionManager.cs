using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace XNARaceGame
{
	class CollisionManager
	{
        // controleert voor de map of entity aan het collide is met map
		public static void CheckMapCollisions(Entity entity, Map map, double dt)
		{
		}

		public static void CheckEntityCollisions(Entity entity, List<Entity> entities, float dt)
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
            return new Rectangle((int)collider.coords.X, (int)collider.coords.Y, (int)collider.hitbox.X, (int)collider.hitbox.Y).Intersects(new Rectangle((int)colliding.coords.X, (int)colliding.coords.Y, (int)colliding.hitbox.X, (int)colliding.hitbox.Y)); // goedkope collision detection, niet prefereerbaar, maar wel werkbaar
		}
	}
}

