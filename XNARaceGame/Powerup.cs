using System;

namespace XNARaceGame
{
	private class Powerup
	{
        bool isActive {get; set;} 
        string type {get; set;} 
        int timer {get; set;} 

		public Powerup()
		{
		}

        public Powerup(bool isActive, string type, int timer)
        {
            this.isActive = isActive;
            this.type = type;
            this.timer = timer;
        }




        public void resetDamage
        {
           Car.damage = 0.0;
        } 
        public void resetPetrol
        {
           Car.petrol = 100;
        }
        public void update
        {


        }
        public void render
        {

        }

        public void collision(Entity entity)
        {

            if (entity.Name() == "Car" && isActive)
            {
                if (type == "Damage")
                {

                    Powerup.resetDamage(entity);
                }
                else if (type == "Petrol")
                {
                    Powerup.resetPetrol(entity);
                }
                
            }
        }
	}
}

