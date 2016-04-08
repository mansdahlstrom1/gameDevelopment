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
    class Button
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rec;
        private String text;
        private int[] margins;
        Color color = new Color(255, 255, 255, 255);
        Utils utils = new Utils();

        public Vector2 size;

        public Button (Texture2D newTexture, GraphicsDevice graphicsDevice, String newText, SpriteFont font)
        {
            text = newText;
            texture = newTexture;


            // Width 800    height = 460:
            // button 100   height = 23;
            size = new Vector2(graphicsDevice.Viewport.Width / 5, graphicsDevice.Viewport.Height / 10);
           
            margins = utils.centerText(font, text);

        }

        bool down;
        bool isClicked;
        // This is a tiny Square 1x1 pixel that checks where the mouse is currently pointing
        // Not sure if we this, turtorials man...
        public Boolean Update(MouseState mouse)
        {
            rec = new Rectangle((int)position.X, (int)position.Y,
                (int)size.X, (int)size.Y);

            Rectangle mouseRec = new Rectangle(mouse.X, mouse.Y, 1, 1);
            isClicked = false;
            if (mouseRec.Intersects(rec))
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isClicked = true;
                    Console.WriteLine("Pressed button");
                }
            } else
            {
                isClicked = false;
            }

            return isClicked;
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {   
            // System.Drawing
            spriteBatch.Draw(texture, rec, color);
            spriteBatch.DrawString(font, text, new Vector2(position.X + margins[0], position.Y + margins[1]), Color.White);
        }
    }
}
