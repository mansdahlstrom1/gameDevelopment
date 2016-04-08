using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class CheckCollisions
    {
        public bool CheckCollision(Rectangle r1, Rectangle r2)
        {
            if (r1.Intersects(r2))
            {
                return false;
            }
            return true;
        }
    }
}
