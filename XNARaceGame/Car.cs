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
	public class Car : Entity
	{
		#region Variables
		//image = imagefile (needs work later)
		double damage = 0; // Percentage. Preferably up to 100.
		double petrol = 100; // Percentage. Starts with full petrol.
		bool[] checkpoints = new bool[4]{ false, false, false, false }; // Four checkpoins. Initialises as having reached none (all false).
		#endregion

		#region Constructor
		public Car(Vector2 coords, double rot) : base("Car", coords, new Vector2(1337, 1337), true, true, rot) // Yet to define hitbox. Dummy values 1337.
		{
			base.coords = coords;
			base.Rot = rot;
		}
		#endregion
	}
}

