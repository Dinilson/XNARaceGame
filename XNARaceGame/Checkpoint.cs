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

		public Checkpoint(int num, Vector2 coords, Vector2 hitbox, double rot) : base("Checkpoint", coords, hitbox, false, true, rot)
		{
            this.num = num;
			// Because "Vector2 coords" is a parameter in "public Checkpoint()", it is forwarded to "coords" in base "base()".
			// The same applies to "hitbox" and "rot".
		}

        

	}
}

