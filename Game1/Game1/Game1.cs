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

        //private Spaceship spaceship;
        private Texture2D background;
        private Texture2D shuttle;
        private SpriteFont font;
        private int score = 0;
        private float heroShipY = 0, heroShipX = 0;
        private float speed = 3;
        private string FPS;
        private List<Player> players = new List<Player>();

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

            //spaceship = new Spaceship();
            foreach (Player p in players)
            {
                p.X = 250;
                p.Y = 250;
                p.Shuttle = Content.Load<Texture2D>("images/DogpoolPortrait");
            }
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

            shuttle = Content.Load<Texture2D>("images/DogpoolPortrait");
            
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

            CheckInput();

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

            spriteBatch.Begin();d

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.Draw(shuttle, new Vector2(heroShipX, heroShipY));
            spriteBatch.DrawString(font, "Score: " + score, new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(font, "Speed: " + speed, new Vector2(10, 30), Color.White);
            spriteBatch.DrawString(font, "FPS: " + "TODO", new Vector2(10, 50), Color.White);
            spriteBatch.DrawString(font, "heroShip position X,Y: " + heroShipX + "," + heroShipY, new Vector2(10, 70), Color.White);

            spriteBatch.End();


            // TODO: Add your drawing code here

            Rectangle r = new Rectangle();
            
            base.Draw(gameTime);
        }


        private void CheckInput()
        {

            //System.Console.WriteLine(Keyboard.GetState().GetPressedKeys());
            //
            //System.Console.WriteLine("Keyboard.GetState().GetPressedKeys() Loop");
            //foreach (var key in Keyboard.GetState().GetPressedKeys())
            //{
            //    System.Console.WriteLine(key.GetType() + " <Type - key>" + key);
            //}

            //W, A, S, D
            if (Keyboard.GetState().IsKeyDown(Keys.W) && heroShipY > 0)
            {
                heroShipY = heroShipY - 1 * speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && heroShipY < 480 - 40)
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

            //A, B, X, Y
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                System.Console.WriteLine("A");
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
            {
                System.Console.WriteLine("B");
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
            {
                System.Console.WriteLine("X");
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
            {
                System.Console.WriteLine("Y");
            }

            //Shoulders & Triggers
            if (GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed)
            {
                System.Console.WriteLine("Right Shoulder");
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder == ButtonState.Pressed)
            {
                System.Console.WriteLine("Left Shoulder");
            }
            if(GamePad.GetState(PlayerIndex.One).Triggers.Right > 0)
            {
                System.Console.WriteLine("Right Trigger: " + GamePad.GetState(PlayerIndex.One).Triggers.Right);
            }
            if (GamePad.GetState(PlayerIndex.One).Triggers.Left > 0)
            {
                System.Console.WriteLine("Left Trigger: " + GamePad.GetState(PlayerIndex.One).Triggers.Left);
            }
            //TODO Triggerz man!

            //Start, back and big button
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
            {
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed)
            {
                //Funkar inte :(
                System.Console.WriteLine("Big Button!");
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            //Left Stick
            if (GamePad.GetState(PlayerIndex.One).Buttons.LeftStick == ButtonState.Pressed)
            {
            }
            //Right
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0 && ShipIsWithinLimits(heroShipX, heroShipY))//heroShipX < 800 - 40)
            {
                heroShipX += (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X * speed);
            }
            //Left
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0 && ShipIsWithinLimits(heroShipX, heroShipY))
            {
                heroShipX += (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X * speed);
            }
            //Up
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0 && ShipIsWithinLimits(heroShipX, heroShipY))
            {
                heroShipY -= (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y * speed);
            }
            //Down
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0 && ShipIsWithinLimits(heroShipX, heroShipY))
            {
                heroShipY -= (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y * speed);
            }

            //Right Stick
            if (GamePad.GetState(PlayerIndex.One).Buttons.RightStick == ButtonState.Pressed)
            {
                System.Console.WriteLine("Right Stick pressed!");
            }
            //Right
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X > 0 && ShipIsWithinLimits(heroShipX, heroShipY))
            {
                heroShipX += (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X * speed);
            }
            //Left
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X < 0 && ShipIsWithinLimits(heroShipX, heroShipY))
            {
                heroShipX += (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X * speed);
            }
            //Up
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0 && ShipIsWithinLimits(heroShipX, heroShipY))
            {
                heroShipY -= (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y * speed);
            }
            //Down
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < 0 && ShipIsWithinLimits(heroShipX, heroShipY))
            {
                heroShipY -= (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y * speed);
            }

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
