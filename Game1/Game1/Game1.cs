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
        private SpriteFont font;

        private int score = 0;
        private float speed = 10.0f;

        private FrameCounter frameCounter = new FrameCounter();
        private InputHelper inputHelper = new InputHelper();
        private CheckCollisions checkCollisions = new CheckCollisions();

        private List<Ship> activeShips = new List<Ship>();
        private List<Missile> missilesToRemove = new List<Missile>();
        private Missile missileToRemove;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            /* Changes window size
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();
            */
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

            //Check how many players are active and what controllers are connected and stuff
            activeShips.Add(new Ship(50, 50, true, true, 0));
            activeShips.Add(new Ship(300, 100, false, true, 1));
            //activeShips.Add(new Ship(300, 100, false, true, 2));
            //activeShips.Add(new Ship(300, 100, false, true, 3));

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
            Texture2D background = Content.Load<Texture2D>("images/stars");
            myBackground.Load(GraphicsDevice, background);

            font = Content.Load<SpriteFont>("myFont"); // Use the name of your sprite font file here instead of 'Score'.

            //Pontus {
            activeShips[0].Texture = Content.Load<Texture2D>("images/PontusSpacesaucerPinkPortrait");
            activeShips[1].Texture = Content.Load<Texture2D>("images/DogpoolPortrait");

            foreach (Ship s in activeShips)
            {
                s.MissileTexture = Content.Load<Texture2D>("images/laser_small");
            }
            //Pontus }


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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // The time since Update was called last.
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // TODO: Add your game logic here.
            myBackground.Update(elapsed * 200);

            score++;

            //Pontus {
            /* Collision detection, todo...
            foreach (Missile m in ship.Missiles)
            {
                if (m.Texture.Bounds.Intersects(ship2.Texture.Bounds))
                {
                    //ship2IsHit = true;
                    System.Console.WriteLine("Collision between missile and ship2");
                    missilesToRemove.Add(m);
                }
            }
            */
            foreach (Ship s in activeShips)
            {
                MoveShip(s);
            }

            //Pontus }

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

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCounter.Update(deltaTime);
            var fps = string.Format("FPS: {0}", frameCounter.AverageFramesPerSecond);
            spriteBatch.DrawString(font, fps, new Vector2(10, 50), Color.White);

            //Pontus {
            foreach (Ship s in activeShips)
            {
                spriteBatch.DrawString(font, "Ship[" + s.ControllerIndex + "] position x,y: " + s.XPos + "," + s.YPos, new Vector2(10, 70), Color.White);
                spriteBatch.Draw(s.Texture, new Vector2(s.XPos, s.YPos), null, null, null, 0.0f, new Vector2(0.4f));

                foreach (Missile m in s.Missiles)
                {
                    spriteBatch.Draw(m.Texture, new Vector2(m.XPos, m.YPos), null, null, null, 0, new Vector2(0.6f));
                }
            }

            //checkCollisions.CheckCollision();
            
            {
                System.Console.WriteLine("Collision!");
            }
            //Pontus }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void MoveShip(Ship s)
        {
            //If ship has controller then check controller input
            if (s.HasController)
            {
                s.Move(GamePad.GetState(s.ControllerIndex, GamePadDeadZone.Circular), speed);
            }
            //If ship has keyboard then check controller input
            if (s.HasKeyboard)
            {
                s.Move(Keyboard.GetState(), speed);
            }

            //Move missiles
            foreach (Missile m in s.Missiles)
            {
                if (m.YPos > 0)
                {
                    m.Move(speed * 2);
                }
                else
                {
                    missilesToRemove.Add(m);
                }
            }

            //Remove missiles
            if (missilesToRemove.Count != 0)
            {
                missileToRemove = missilesToRemove[0];

                if (missileToRemove != null)
                {
                    s.RemoveMissile(missileToRemove);
                    missilesToRemove.Remove(missileToRemove);
                    missileToRemove = null;
                }
            }
        }

        // Here we can send in each players specific value!
        // Not done, don't use
        private bool ShipIsWithinLimits(float playerX, float playerY)
        {
            if (playerX >= 0 && playerX < (800 - 40) && playerY >= 0 && playerY < (480 - 40))
            {
                return true;
            }
            return false;
        }
    }
}
