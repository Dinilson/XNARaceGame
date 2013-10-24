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
        public readonly static int TIMEOUT = 1000;
        public bool isActive {get; set;} 
        public string type {get; set;} 
        public int timer {get; set;}
        //SoundManager soundManager;
        #endregion

        #region Constructor
        //constructor
        public Powerup(RaceGame game, bool isActive, string type, int timer, Vector2 coords, Vector2 hitbox) : base("Powerup", game, coords, hitbox, 0, true, true, false)
        {
            this.isActive = isActive;
            this.type = type;
            this.timer = -1;
        }
        #endregion

        #region Healpowerup
        public void resetCarDamage(Car car) //de heal methode
        {
            car.Damage = 0;
            
        }
        #endregion

        #region Refuelpowerup 
        public void resetCarPetrol(Car car) //de refuel functie
        {
            car.Petrol = 100;
        }
        #endregion

        #region Update
        public override bool update(float dt, InputManager inputManager) // update functie
        {
            if (timer > -1 && Environment.TickCount >= timer)
            {
                isVisible = true;
                isActive = true;
            }

            return isAlive;
			// More to be updated I guess?
        }
        #endregion

        #region Render
        public override void render(GraphicsManager graphicsManager)
        {
			// Nothing is rendered here.
        }
        #endregion

        #region Entitycollision
        public override void entityCollision(Entity entity) // collision detectie voor andere entities
        {

            if (entity.name == "Car" && isActive)
            {
                if (type == "Repair")
                {
                    resetCarDamage((Car)entity);
                    game.soundManager.playSound("powerup");
                }
                else if (type == "Petrol")
                {
                    resetCarPetrol((Car)entity);
                    game.soundManager.playSound("powerup");
                }
                isActive = false;
                isVisible = false;
                timer = Environment.TickCount + TIMEOUT;

                
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

