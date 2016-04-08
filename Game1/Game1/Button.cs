using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Button
    {
        private Texture2D texture;
        private Vector2 position;
        private Microsoft.Xna.Framework.Rectangle rec;
        private String text;
        Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color(255, 255, 255, 255);
        Utils utils = new Utils();

        public Vector2 size;

        public Button (Texture2D newTexture, GraphicsDevice graphicsDevice, String newText)
        {
            text = newText;
            texture = newTexture;


            // Width 800    height = 460:
            // button 100   height = 23;
            size = new Vector2(graphicsDevice.Viewport.Width / 8, graphicsDevice.Viewport.Height / 20);
           

        }

        bool down;
        bool isClicked;
        // This is a tiny Square 1x1 pixel that checks where the mouse is currently pointing
        // Not sure if we this, turtorials man...
        public Boolean Update(MouseState mouse)
        {
            rec = new Microsoft.Xna.Framework.Rectangle((int)position.X, (int)position.Y,
                (int)size.X, (int)size.Y);

            Microsoft.Xna.Framework.Rectangle mouseRec = new Microsoft.Xna.Framework.Rectangle(mouse.X, mouse.Y, 1, 1);
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
            System.Drawing
            spriteBatch.Draw(texture, rec, color);
            spriteBatch.DrawString(font, text, new Vector2(position.X + 10, position.Y + 5), Microsoft.Xna.Framework.Color.White);
        }
    }
}
