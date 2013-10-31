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
            Vector2 colliderHitbox = new Vector2(collider.hitbox.X * (collider.hitbox.X - (collider.hitbox.X - 1)), collider.hitbox.Y*(collider.hitbox.Y - (collider.hitbox.Y - 1)));
            Vector2 collidingHitbox = new Vector2(colliding.hitbox.X * (colliding.hitbox.X - (colliding.hitbox.X - 1)), colliding.hitbox.Y * (colliding.hitbox.Y - (colliding.hitbox.Y - 1)));
            return new Rectangle((int)collider.coords.X, (int)collider.coords.Y, (int)colliderHitbox.X, (int)colliderHitbox.Y).Intersects(new Rectangle((int)colliding.coords.X, (int)colliding.coords.Y, (int)collidingHitbox.X, (int)collidingHitbox.Y)); // goedkope collision detection, niet prefereerbaar, maar wel werkbaar
		}
	}
}

