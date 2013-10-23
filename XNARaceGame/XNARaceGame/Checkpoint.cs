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

		public Checkpoint(RaceGame game, int num, Vector2 coords, Vector2 hitbox, double rot) : base("Checkpoint", game, coords, hitbox, rot, false, true, false)
		{
            this.game = game;
            this.num = num;
			// Because "Vector2 coords" is a parameter in "public Checkpoint()", it is forwarded to "coords" in base "base()".
			// The same applies to "hitbox" and "rot".
		}

        public override void render(GraphicsManager graphicsManager)
        {
        }

        public override bool update(float dt, InputManager inputManager) {
            return isAlive;
        }

        public override void entityCollision(Entity entity)
        {
        }

        public override void mapCollision(Vector2 vector)
        {
        }
	}
}
