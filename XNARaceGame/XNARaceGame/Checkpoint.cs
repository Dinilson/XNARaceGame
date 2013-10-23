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
        int startFinish, checkpoint1, checkpoint2, checkpoint3;

		public Checkpoint(RaceGame game, int num, Vector2 coords, Vector2 hitbox, double rot) : base("Checkpoint", game, coords, hitbox, rot, false, true, false)
		{
            this.game = game;
            this.num = num;
			// Because "Vector2 coords" is a parameter in "public Checkpoint()", it is forwarded to "coords" in base "base()".
			// The same applies to "hitbox" and "rot".
		}

        public int CheckpointCount()
        {
            startFinish = 0;
            checkpoint1 = startFinish + 1;
            checkpoint2 = checkpoint1 + 1;
            checkpoint3 = checkpoint2 + 1;

            return startFinish;

        }

        public void 

        public override void render(GraphicsManager graphicsManager)
        {
        }

        public override bool update(float dt, InputManager inputManager) {
            return isAlive;
        }

        public override void entityCollision(Entity entity)
        {
            if (entity.name == "Car") 
            {
                setCheckpoint((Car)entity);
            }
        }

        public override void mapCollision(Vector2 vector)
        {
        }
        private void setCheckpoint(Car car) {
            car.checkpoints[num] = true;

        }
	}
}
