using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    //abstract
    class Ship
    {
        private float xPos;
        private float yPos;
        private Texture2D texture;
        //private Sprite sprite;
        //private float width;
        //private float height;

        private Texture2D missileTexture;
        public Texture2D MissileTexture { get { return missileTexture; } set { missileTexture = value; } }
        private List<Missile> missiles = new List<Missile>();
        public List<Missile> Missiles { get { return missiles; } }

        public Texture2D Texture { get { return texture; } set { texture = value; } }
        public float XPos { get { return xPos; } set { xPos = value; } }
        public float YPos { get { return yPos; } set { yPos = value; } }
        //public Sprite Sprite { get { return sprite; } set { sprite = value; } }
        //public float width { get { return width; } set { width = value; } }
        //public float height { get { return height; } set { height = value; } }

        //Default constructor
        public Ship(float xPos, float yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }

        /*
        public Ship(Sprite sprite)
        {
            Sprite = sprite //Rätt?
            X = 10;
            Y = 10;
        }
        */

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

        public void RemoveMissile(Missile m)
        {
            try
            {
                missiles.Remove(m);
                System.Console.WriteLine("RemoveMissile() removed a missile from ship");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("RemoveMissile() failed");
                //System.Console.WriteLine(e.Message);
            }
        }

        public void FireSecondary()
        {
            System.Console.WriteLine("Whoooosh!");
        }

        public void Explode()
        {
            System.Console.WriteLine("i died :(");
        }
    }
}
