using System;

namespace XNARaceGame
{
	private class Checkpoint : Entity
	{
        int num;

		public Checkpoint(int num, Vector2 coords, Vector2 hitbox, rot) : base("Checkpoint", coords, hitbox, false, true, rot)
		{
            this.num = num;
            //base.coords = coords;
            //base.hitbox = hitbox;
            //base.rot = rot;
		}

        

	}
}

