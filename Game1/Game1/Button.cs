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

        Color color = new Color(255, 255, 255, 255);

        public Vector2 size;
        
        public Button (Texture2D newTexture, GraphicsDevice graphicsDevice)
        {
            texture = newTexture;

            // Width 800    height = 460:
            // button 100   height = 23;
            size = new Vector2(graphicsDevice.Viewport.Width / 8, graphicsDevice.Viewport.Height / 20);
           

        }

        bool down;
        bool isClicked;
        // This is a tiny Square 1x1 pixel that checks where the mouse is currently pointing
        // Not sure if we this, turtorials man...
        public void Update(MouseState mouse)
        {
            rec = new Rectangle((int)position.X, (int)position.Y,
                (int)size.X, (int)size.Y);
           
            Rectangle mouseRec = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRec.Intersects(rec))
            {
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
            } else
            {
                isClicked = false;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rec, color);
        }
    }
}
