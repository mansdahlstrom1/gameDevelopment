using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Utils
    {

        private int _fontMarginLeft;
        public int fontMarginLeft
        {
            get { return _fontMarginLeft; }
            set { _fontMarginLeft = value; }
        }
        private int _fontMarginTop;
        public int fontMarginTop
        {
            get { return _fontMarginTop; }
            set { _fontMarginTop = value; }
        }


        public int[] centerText(SpriteFont font, String text)
        {
            Vector2 fontDimensions = font.MeasureString(text);

            int[] margins = new int[2];
            // TOP
            // Static width for button is 100
            // TODO
            // Get a responsive width from button object.
            this.fontMarginLeft = (int)(160 - fontDimensions.X) / 2;

            //LEFT
            // Static width for button is 23
            // TODO
            // Get a responsive width from button object.
            this.fontMarginTop = (int)(46 - fontDimensions.Y) / 2;

            if (this.fontMarginLeft < 0)
            {
                this.fontMarginLeft = 0;
            }
            if (this.fontMarginTop < 0)
            {
                this.fontMarginTop = 0;
            }


            margins[0] = this.fontMarginLeft;
            margins[1] = this.fontMarginTop;
            return margins;
        }
    }
}
