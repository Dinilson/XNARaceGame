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
        private Camera camera;
        private double damage; // Percentage. Preferably up to 100.
        private double petrol; // Percentage. Starts with full petrol.
        double TAU = (double)Math.PI * 2; // TAU = 2 * pi
		Keys[] keys;
		public bool[] checkpoints { get; set; } // Four checkpoins. Initialises as having reached none (all false).
        private Vector2 coordsoffset;
		#endregion

		#region Constructor
		public Car(RaceGame game, Camera camera, Vector2 coords, double rot, Keys[] keys) : base("Car", game, coords, new Vector2(50, 50), rot, true, true, true) // Yet to define hitbox. Dummy values 1337.
		{
            this.camera = camera;
			damage = 0;
			petrol = 100;
			checkpoints = new bool[4] { false, false, false, false };
			this.keys = keys;
            //accel = Vector2.Add(accel, new Vector2(0.1f, 0.1f));
		}
		#endregion
		
		#region Update
		public override bool update(float dt, InputManager inputManager)
        {
            if (inputManager.currentKeyState.IsKeyDown(keys[0]))
            {
                
                accel += (100 * dt);

                if (accel > 100)
                {
                    accel = 100.0f;
                }
                //accel = Vector2.Add(accel, new Vector2(400 * dt * (float)Math.Cos(rot), 400 * dt * (float)Math.Sin(rot)));
                //accel = Vector2.Add(accel, Vector2.Normalize(accel) * 400 * dt);
            }
            if (inputManager.currentKeyState.IsKeyDown(keys[1]))
            {
                if (accel > 0)
                {
                    accel -= (200 * dt);
                }
                if (accel <= 0)
                {
                    accel -= (10 * dt);
                }
                if (accel < -75)
                {
                    accel = -75.0f;
                }
            }
            if (inputManager.currentKeyState.IsKeyDown(keys[2]))
            {
                   rot -= 0.01*velocity*dt;
                
            }
            if (inputManager.currentKeyState.IsKeyDown(keys[3]))
            {
               
                    rot += 0.01*velocity*dt;
                
            }
            if (!inputManager.currentKeyState.IsKeyDown(keys[0]) && !inputManager.currentKeyState.IsKeyDown(keys[1]))
            {
                accel = 0.0f;
            }
            if (!inputManager.currentKeyState.IsKeyDown(keys[4])) {
                camera.scale += 0.5f * dt;
            } else if (!inputManager.currentKeyState.IsKeyDown(keys[5])) {
                camera.scale -= 0.5f * dt;
            }

            velocity = velocity + (accel * dt); // v = v + (a * dt). (a * dt = v)
            rot %= TAU;

            if (rot < 0)
            {
                rot += TAU;
            }
            coordsoffset.X = velocity * (float)Math.Cos(rot) * dt;
            coordsoffset.Y = velocity * (float)Math.Sin(rot) * dt;
            coords = Vector2.Add(coords, coordsoffset);

            if ((velocity < 5.0f && velocity > -5.0f) && (accel == 0.0f))
            {
                velocity = 0.0f;
            }
            else
            {
                velocity *= 0.99f;
            }

            /*Console.WriteLine("accel: " + accel);
            Console.WriteLine("velocity: " + velocity);
            Console.WriteLine("rot: " + rot);*/
            /*accel = Vector2.Add(accel, new Vector2(-velocity.X * 0.25f, -velocity.Y * 0.25f));

            velocity = Vector2.Add(velocity, Vector2.Multiply(accel, dt)); // v = v + (a * dt). (a * dt = v)

            coords = Vector2.Add(Vector2.Multiply(velocity, dt), coords); // s = (v * dt) + s. (v * dt = s)*/
            camera.setCoords(coords);
			return isAlive;
		}

		#endregion

		#region Render
		public override void render(GraphicsManager graphicsManager) {
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
            velocity -= accel - 1;
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

