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
        private float x;
        private float y;
        private Texture2D texture;
        //private Sprite sprite;
        //private float width;
        //private float height;

        public Texture2D Texture { get { return texture; } set { texture = value; } }
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }
        //public Sprite Sprite { get { return sprite; } set { sprite = value; } }
        //public float width { get { return width; } set { width = value; } }
        //public float height { get { return height; } set { height = value; } }

        //Default constructor
        public Ship()
        {
            X = 10;
            Y = 10;
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

        }
        
        public void FireMain()
        {
            System.Console.WriteLine("Pew pew");
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
