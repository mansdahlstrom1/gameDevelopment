using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Player {
        private float x;
        private float y;
        private Texture2D shuttle;


        public float X
        {
            set { x = value; }
            get { return x; }
        }

        public float Y
        {
            set {y = value; }
            get { return y; }
        }

        public Texture2D Shuttle
        {
            get { return shuttle; }
            set { shuttle = value; }
        }


    }
}
