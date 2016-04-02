using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        private Texture2D background;
        private Texture2D shuttle;
        private SpriteFont font;
        private int score = 0;
        private int heroShipY = 250;
        private int heroShipX = 250;
        private int speed = 3;

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

            background = Content.Load<Texture2D>("stars");

            shuttle = Content.Load<Texture2D>("shuttle");

            font = Content.Load<SpriteFont>("myFont"); // Use the name of your sprite font file here instead of 'Score'.


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
            score++;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                System.Console.WriteLine("test :)");
                //} else if (GamePad.GetState(PlayerIndex.One).Buttons.LeftStick == ButtonState.Pressed)
                //{

            }

            if (score % 1000 == 0 && speed < 10)
            {
                speed++;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && heroShipY > 0)
            {
                heroShipY = heroShipY - 1 * speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) &&  heroShipY < 480 - 40)
            {
                heroShipY = heroShipY + (1 * speed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && heroShipX > 0)
            {
                heroShipX = heroShipX - 1 * speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) && heroShipX < 800 - 40)
            {
                heroShipX = heroShipX + 1 * speed;
            }
            System.Console.WriteLine(Keyboard.GetState().GetPressedKeys());
 
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

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.Draw(shuttle, new Vector2(heroShipX, heroShipY), Color.White);
            spriteBatch.DrawString(font, "Score: " + score, new Vector2(100, 100), Color.White);

            spriteBatch.End();


            // TODO: Add your drawing code here

            Rectangle r = new Rectangle();
            
            base.Draw(gameTime);
        }
    }
}
