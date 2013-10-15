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
		private string name { get; set; }
		private Vector2 coords { get; set; }
		private double rot = 0; // In radian. Max rot = 6.283185307179586
		private double accel = 0;
		private Vector2 vector = new Vector2(0, 0); // Direction, speed
		private Vector2 hitbox { get; set; }
		private bool isVisible = false;
		private bool isCollidable = false;
		#endregion

		#region Constructor class
		public Entity(string name, Vector2 coords, Vector2 hitbox, bool isVisible, bool isCollidable, double rot)
		{
			this.name = name;
			this.coords = coords;
			this.hitbox = hitbox;
			this.isVisible = isVisible;
			this.isCollidable = isCollidable;
			this.rot = rot;
		}
		#endregion

		#region update
		public void update()
		{
		}
		#endregion

		#region render
		public void render()
		{
			// Nothing is rendered here.
		}
		#endregion

		#region Properties
		public double Rot
		{
			get { return rot; }
			set { rot = value; }
		}

		public double Accel
		{
			get { return accel; }
			set { accel = value; }
		}

		public Vector2 Vector
		{
			get { return vector; }
			set { vector = value; }
		}

		public bool IsVisible
		{
			get { return isVisible; }
			set { isVisible = value; }
		}

		public bool IsCollidable
		{
			get { return isCollidable; }
			set { isCollidable = value; }
		}

		#endregion

	}
}

