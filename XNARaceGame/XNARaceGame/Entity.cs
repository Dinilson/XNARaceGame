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
	public abstract class Entity
	{
		#region Entity variables
		public string name;
        public RaceGame game { get; set; }
		public Vector2 coords { get; set; }
		public Vector2 velocity { get; set; }
        public Vector2 accel { get; set; }
		public double rot { get; set; }
		public Vector2 hitbox { get; set; }
		public bool isVisible { get; set; }
		public bool isCollidable { get; set; }
        public bool isActor { get; set; }
        public bool isAlive { get; set; }
		#endregion

		#region Constructor class
		public Entity(string name, RaceGame game, Vector2 coords, Vector2 hitbox, double rot, bool isVisible, bool isCollidable, bool isActor)
		{
			this.name = name;
            this.game = game;
			this.coords = coords;
			this.velocity = new Vector2(0, 0);
            this.accel = new Vector2(0, 0);
			this.rot = rot;
			this.hitbox = hitbox;
			this.isVisible = isVisible;
			this.isCollidable = isCollidable;
            this.isActor = isActor;
            isAlive = true;
		}
		#endregion

		#region update
        public abstract bool update(float dt, InputManager inputManager);
		#endregion

		#region render
        public abstract void render(GraphicsManager graphicsManager);
		#endregion
		
		#region entityCollision
        public abstract void entityCollision(Entity entity);
		#endregion
		
		#region mapCollision
		public abstract void mapCollision(Vector2 vector);
		#endregion
	}
}

