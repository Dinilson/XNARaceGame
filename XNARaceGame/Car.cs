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
	class Car : Entity
	{
		#region Variables
		//image = imagefile (needs work later)
		public double damage { get; set { if(value>=0 && value<=100) { damage = value;}} } // Percentage. Preferably up to 100.
		public double petrol { get; set { if(value>=0 && value<=100) { petrol = value;}} } // Percentage. Starts with full petrol.
		public bool[] checkpoints { get; set; } // Four checkpoins. Initialises as having reached none (all false).
		#endregion

		#region Constructor
		public Car(Vector2 coords, double rot) : base("Car", coords, rot, new Vector2(1337, 1337), true, true) // Yet to define hitbox. Dummy values 1337.
		{
			damage = 0;
			petrol = 100;
			checkpoints = new bool[4] { false, false, false, false };
		}
		#endregion
		
		#region update
		public override bool update(int dt, Controller controller)
		{
			return false;
		}
		#endregion
		
		#region render
		public override void render(View view)
		{
		}
		#endregion
		
		#region entityCollision
		public override void entityCollision(Entity entity)
		{
		}
		#endregion
		
		#region mapCollision
		public override void mapCollision(Vector2 vector)
		{
		}
		#endregion
	}
} 

