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
	public class Entity
	{
		#region Entity variables
		Vector2 coords;
		double rot = 0; // In radian.
		double accel = 0;
		Vector2 vector = new Vector2(0, 0); // Direction, speed
		Vector2 hitbox;
		bool isVisible = false;
		bool isCollidable = false;
		#endregion

		#region Constructor class
		public Entity(Vector2 coordsIn, Vector2 hitboxIn, bool isVisibleIn, bool isCollidableIn, double rotIn)
		{
			coords = coordsIn;
			hitbox = hitboxIn;
			isVisible = isVisibleIn;
			isCollidable = isCollidableIn;
			rot = rotIn;
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
		}
		#endregion
	}
}

