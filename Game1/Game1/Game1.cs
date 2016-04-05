using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
    /// TEST :)
    /// 
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Background myBackground;
        private Texture2D shuttle;
        private SpriteFont font;
        private int score = 0;



        private float speed = 3;
        private FrameCounter frameCounter = new FrameCounter();
        private Texture2D spriteFont;

        private Ship ship;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            ship = new Ship();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            myBackground = new Background();
            Texture2D background = Content.Load<Texture2D>("stars");
            myBackground.Load(GraphicsDevice, background);

            shuttle = Content.Load<Texture2D>("images/DogpoolPortrait");
            
            font = Content.Load<SpriteFont>("myFont"); // Use the name of your sprite font file here instead of 'Score'.


            ship.Texture = shuttle;


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // The time since Update was called last.
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // TODO: Add your game logic here.
            myBackground.Update(elapsed * 200);

            score++;

            if (score % 1000 == 1 && speed <= 12)
            {
                speed += 3;
            }
 
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
           
            spriteBatch.Begin();

     

            myBackground.Draw(spriteBatch);

            spriteBatch.DrawString(font, "Score: " + score, new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(font, "Speed: " + speed, new Vector2(10, 30), Color.White);
            // spriteBatch.DrawString(font, "FPS: " + (1000 / gameTime.ElapsedGameTime.Milliseconds), new Vector2(10, 50), Color.White);
            //FPS counter                     
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCounter.Update(deltaTime);
            var fps = string.Format("FPS: {0}", frameCounter.AverageFramesPerSecond);
            spriteBatch.DrawString(font, fps, new Vector2(10, 50), Color.White);
            spriteBatch.DrawString(font, "Ship position x,y: " + ship.X + "," + ship.Y, new Vector2(10, 70), Color.White);

            spriteBatch.Draw(ship.Texture, new Vector2(ship.X, ship.Y));

            spriteBatch.End();


            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
        }


        // Here we can send in each players specific value!
        private bool ShipIsWithinLimits(float playerX, float playerY)
        {
            if(playerX >= 0 && playerX < (800 - 40) && playerY >= 0 && playerY < (480 -40))
            {
                return true;
            } 


            return false;
        }
    }
}
