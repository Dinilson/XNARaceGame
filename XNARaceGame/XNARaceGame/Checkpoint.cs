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
	class Checkpoint : Entity
	{
        int num;

        #region constructor
        public Checkpoint(RaceGame game, int num, Vector2 coords, Vector2 hitbox, double rot) : base("Checkpoint", game, coords, hitbox, rot, false, true, false)
		{
            this.game = game;
            this.num = num;
			// Because "Vector2 coords" is a parameter in "public Checkpoint()", it is forwarded to "coords" in base "base()".
			// The same applies to "hitbox" and "rot".
		}
        #endregion

        #region render
        public override void render()
        {
        }
        #endregion

        #region update
        public override bool update(float dt, InputManager inputManager) {
            return isAlive;
        }
        #endregion

        #region entityCollision
        public override void entityCollision(Entity entity)
        {
            if (entity.name == "Car") 
            {
                setCheckpoint((Car)entity);
            }
        }
        #endregion

        #region mapCollision
        public override void mapCollision(Vector2 vector)
        {
        }
        #endregion

        #region setCheckpoint
        private void setCheckpoint(Car car) 
        {
            if (num > 0 && car.checkpoints[num - 1])
            {
                car.checkpoints[num] = true;
            }
            else if (num == car.checkpoints.Length - 1 && car.checkpoints[num - 1])
            {
                //ronde is klaar
            }

            else if (num == 0)
            {
                car.checkpoints[num] = true;
            }
        #endregion







        }
	}
}
