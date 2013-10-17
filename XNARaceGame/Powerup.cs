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
        #region Attributes
        public bool isActive {get; set;} 
        public string type {get; set;} 
        public int timer {get; set;}
        #endregion

        #region Constructor
        //constructor
        public Powerup(bool isActive, string type, int timer, Vector2 coords, Vector2 hitbox) : base("Powerup", coords, hitbox, 0, true, true, false)
        {
            this.isActive = isActive;
            this.type = type;
            this.timer = -1;
        }
        #endregion

        #region Healpowerup
        public void resetCarDamage(Entity car) //de heal methode
        {
            ((Car)car).Damage = 0;
        }
        #endregion

        #region Refuelpowerup 
        public void resetCarPetrol(Entity car) //de refuel functie
        {
            ((Car)car).Petrol = 100;
        }
        #endregion

        #region Update
        public override bool update(double dt, Controller controller) // update functie
        {
            return isAlive;
			// More to be updated I guess?
        }
        #endregion

        #region Render
        public override void render()
        {
			// Nothing is rendered here.
        }
        #endregion

        #region Entitycollision
        public override void entityCollision(Entity entity) // collision detectie voor andere entities
        {

            if (entity.name == "Car" && isActive == true)
            {
                if (type == "Repair")
                {
                    resetCarDamage(entity);
                }
                else if (type == "Petrol")
                {
                    resetCarPetrol(entity);
                }
                
            }
        }
        #endregion

        #region Mapcollision
        public override void mapCollision(Vector2 vector)
        {
            //wordt niet aangeroepen
        }
        #endregion
    }
}

