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
		#region Attributes
        private double damage; // Percentage. Preferably up to 100.
        private double petrol; // Percentage. Starts with full petrol.
		public bool[] checkpoints { get; set; } // Four checkpoins. Initialises as having reached none (all false).
		#endregion

		#region Constructor
		public Car(RaceGame game, Vector2 coords, double rot) : base("Car", game, coords, new Vector2(1337, 1337), rot, true, true, true) // Yet to define hitbox. Dummy values 1337.
		{
			damage = 0;
			petrol = 100;
			checkpoints = new bool[4] { false, false, false, false };
		}
		#endregion
		
		#region Update
		public override bool update(float dt, InputManager inputManager)
        {
            /*double tau = (double)Math.PI * 2; // tau = 2 * pi

            rot %= tau;

            if (rot < 0) 
            {
                rot += tau;
            }*/ // Maybe useless code who knows?

            // Define accel with inputManager here

            velocity = Vector2.Add(velocity, Vector2.Multiply(accel, dt)); // v = v + (a * dt). (a * dt = v)

            coords = Vector2.Add(Vector2.Multiply(velocity, dt), coords); // s = (v * dt) + s. (v * dt = s)
			return isAlive;
		}

		#endregion

		#region Render
		public override void render(GraphicsManager graphicsManager) {
            graphicsManager.drawSprite(name, (int)coords.X, (int)coords.Y, 50, 50);
		}
		#endregion
		
		#region EntityCollision
		public override void entityCollision(Entity entity)
		{
		}
		#endregion
		
		#region MapCollision
		public override void mapCollision(Vector2 vector)
		{
		}
		#endregion

		#region Getters and setters
        public double Damage {
            get {
                return damage;
            }
            set {
                if (value >= 0 && value <= 100) {
                    damage = value;
                }
            }
        }

        public double Petrol {
            get {
                return petrol;
            }
            set {
                if (value >= 0 && value <= 100) {
                    petrol = value;
                }
            }
        }
		#endregion
	}
}

