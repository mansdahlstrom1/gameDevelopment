using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    abstract class Ship
    {
        //private Point position;
        private float xPos = 100;
        private float yPos = 100;
        public float XPos { get { return xPos; } set { xPos = value; } }
        public float YPos { get { return yPos; } set { yPos = value; } }

        private Texture2D texture;
        public Texture2D Texture { get { return texture; } set { texture = value; } }

        private Texture2D missileTexture; // Should be Sprite?
        public Texture2D MissileTexture { get { return missileTexture; } set { missileTexture = value; } }

        private List<Missile> missiles = new List<Missile>();
        public List<Missile> Missiles { get { return missiles; } }

        private List<Missile> missilesToRemove = new List<Missile>();
        private Missile missileToRemove;

        //private Sprite sprite; //Replaces Texture2D
        //public Sprite Sprite { get { return sprite; } set { sprite = value; } }

        public void Move(float x, float y)
        {
            XPos += x;
            YPos += y;
        }

        public void ResetPosition()
        {
            XPos = 10;
            YPos = 10;
        }

        public void FireMain()
        {
            missiles.Add(new Missile(XPos - 5, YPos, missileTexture));
            missiles.Add(new Missile(XPos + 40, YPos, missileTexture));

            System.Console.WriteLine("Ships missile count: " + Missiles.Count);
        }
        
    }
}
