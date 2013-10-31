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
		public Car(RaceGame game, Vector2 coords, double rot) : base("Car", game, coords, new Vector2(50, 50), rot, true, true, true) // Yet to define hitbox. Dummy values 1337.
		{
			damage = 0;
			petrol = 100;
			checkpoints = new bool[4] { false, false, false, false };
            //accel = Vector2.Add(accel, new Vector2(0.1f, 0.1f));
		}
		#endregion
		
		#region Update
		public override bool update(float dt, InputManager inputManager)
        {
            double tau = (double)Math.PI * 2; // tau = 2 * pi

            if (inputManager.currentKeyState.IsKeyDown(Keys.W))
            {
                if (accel < 100)
                {
                    accel += (800 * dt);
                }
                //accel = Vector2.Add(accel, new Vector2(400 * dt * (float)Math.Cos(rot), 400 * dt * (float)Math.Sin(rot)));
                //accel = Vector2.Add(accel, Vector2.Normalize(accel) * 400 * dt);
            }
            if (inputManager.currentKeyState.IsKeyDown(Keys.S))
            {
                if (accel > 0)
                {
                    accel -= (1000 * dt);
                }
                if (accel <= 0)
                {
                    accel -= (300 * dt);
                }
            }
            if (inputManager.currentKeyState.IsKeyDown(Keys.A))
            {
                   rot -= 0.01*velocity*dt;
                
            }
            if (inputManager.currentKeyState.IsKeyDown(Keys.D))
            {
               
                    rot += 0.01*velocity*dt;
                
            }
            if (!inputManager.currentKeyState.IsKeyDown(Keys.W) && !inputManager.currentKeyState.IsKeyDown(Keys.S))
            {
                //accel = new Vector2(0, 0);
            }

            velocity = velocity + (accel * dt); // v = v + (a * dt). (a * dt = v)
            rot %= tau;

            if (rot < 0)
            {
                rot += tau;
            }

            coords = Vector2.Add(coords, new Vector2(velocity * (float)Math.Cos(rot) * dt, velocity * (float)Math.Sin(rot) * dt));
            accel *= 0.9f;

            if ((velocity < 5.0f && velocity >= 0.0f) && (accel < 0.0001f && accel > -0.0001f))
            {
                velocity = 0.0f;
                accel = 0.0f;
            }
            else if ((velocity > -5.0f && velocity < 0.0f) && (accel < 0.0001f && accel > -0.0001f))
            {
                velocity = 0.0f;
                accel = 0.0f;
            }
            else
            {
                velocity *= 0.99f;
            }
            Console.WriteLine("accel: " + accel);
            Console.WriteLine("velocity: " + velocity);
            Console.WriteLine("rot: " + rot);
            /*accel = Vector2.Add(accel, new Vector2(-velocity.X * 0.25f, -velocity.Y * 0.25f));

            velocity = Vector2.Add(velocity, Vector2.Multiply(accel, dt)); // v = v + (a * dt). (a * dt = v)

            coords = Vector2.Add(Vector2.Multiply(velocity, dt), coords); // s = (v * dt) + s. (v * dt = s)*/
			return isAlive;
		}

		#endregion

		#region Render
		public override void render(GraphicsManager graphicsManager) {
            graphicsManager.setViewportCoords(coords);
            graphicsManager.drawSprite(name, (int)coords.X, (int)coords.Y, 50, 50, (float)rot);
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
            coords = vector;
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

