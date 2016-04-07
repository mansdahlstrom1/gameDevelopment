using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Missile
    {
        private float xPos;
        private float yPos;
        public float XPos { get { return xPos; } set { xPos = value; } }
        public float YPos { get { return yPos; } set { yPos = value; } }

        private Texture2D texture;
        public Texture2D Texture { get { return texture; } set { texture = value; } }

        private bool isAlive;
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
        
        //Default
        public Missile()
        {

        }

        public Missile(float xPos, float yPos, Texture2D texture)
        {
            IsAlive = true;
            Texture = texture;
            XPos = xPos;
            YPos = yPos;
        }

        public void Move()
        {
            YPos -= 20;
        }
    }
}
