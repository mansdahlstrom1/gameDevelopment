using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class GameObject
    {
        private int width;
        private int height;

        public int Width {
            get { return width; }
            set { this.width = value; }
        }

        public int Height {
            get { return height; }
            set { height = value; }
        }
    }
}
