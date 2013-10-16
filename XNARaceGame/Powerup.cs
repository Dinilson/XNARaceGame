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
	class Powerup : Entity
	{
        public bool isActive {get; set;} 
        public string type {get; set;} 
        public int timer {get; set;}

        public Powerup(bool isActive, string type, int timer, Vector2 coords, Vector2 hitbox) : base("Powerup", coords, 0, hitbox, true, true)
        {
            this.isActive = isActive;
            this.type = type;
            this.timer = timer;
        }

        public void resetDamage(Entity car)
        {
            ((Car)car).Damage = 0;
        }

        public void resetPetrol(Entity car)
        {
            ((Car)car).petrol = 100;
        }

        public void update()
        {
			// Nothing is updated here.
        }

        public void render()
        {
			// Nothing is rendered here.
        }

        public void collision(Entity entity)
        {

            if (entity.name == "Car" && isActive == true)
            {
                if (type == "Repair")
                {
                    resetDamage(entity);
                }
                else if (type == "Petrol")
                {
                    resetPetrol(entity);
                }
                
            }
        }
	}
}

