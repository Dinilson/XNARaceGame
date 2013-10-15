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
	class Entity
	{
		#region Entity variables
		public string name;
		public Vector2 coords { get; set; }
		public double rot { get; set; }
		public double accel { get; set; }
		public Vector2 vector { get; set; }
		public Vector2 hitbox { get; set; }
		public bool isVisible { get; set; }
		public bool isCollidable { get; set; }
		#endregion

		#region Constructor class
		public Entity(string name, Vector2 coords, double rot, Vector2 hitbox, bool isVisible, bool isCollidable)
		{
			this.name = name;
			this.coords = coords;
			this.rot = rot;
			this.accel = 0;
			this.vector = new Vector2(0, 0);
			this.hitbox = hitbox;
			this.isVisible = isVisible;
			this.isCollidable = isCollidable;
		}
		#endregion

		#region update
		public virtual bool update(int dt, Controller controller)
		{
			return false;
		}
		#endregion

		#region render
		public virtual void render(View view)
		{
			// Nothing is rendered here.
		}
		#endregion
		
		#region entityCollision
		public virtual void entityCollision(Entity entity)
		{
			//Do nothing on collision with entity
		}
		#endregion
		
		#region entityCollision
		public virtual void mapCollision(Vector2 vector)
		{
			//Do nothing on collision with map
		}
		#endregion
	}
}

