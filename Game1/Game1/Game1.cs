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
        private Background myBackground;
        private Texture2D shipTexture; //Remove
        private Texture2D ship2Texture; //Remove
        private Texture2D missileTexture;
        private SpriteFont font;
        private int score = 0;
        private float speed = 10;
        private FrameCounter frameCounter = new FrameCounter();

        private InputHelper inputHelper = new InputHelper();
        private CheckCollisions checkCollisions = new CheckCollisions();

        private Ship ship, ship2; //List<Ship> activeShips = new List<Ship>();
        private List<Missile> missilesToRemove = new List<Missile>();
        private Missile missileToRemove;


        //Test
        bool ship2IsHit = false;

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

            //activeShips.Add(new Ship(50, 50);
            //activeShips.Add(new Ship(300, 100);
            ship = new Ship(50, 50);
            ship2 = new Ship(300, 100);

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

            //activeShips ...
            shipTexture = Content.Load<Texture2D>("images/PontusSpacesaucerPinkPortrait");
            ship2Texture = Content.Load<Texture2D>("images/DogpoolPortrait");

            font = Content.Load<SpriteFont>("myFont"); // Use the name of your sprite font file here instead of 'Score'.

            //foreach ...
            missileTexture = Content.Load<Texture2D>("images/laser_small");
            ship.MissileTexture = missileTexture;
            ship.Texture = shipTexture;
            ship2.Texture = shipTexture;


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

            //Pontus {
            /*
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


            //foreach (Ship s in activeShips){
                foreach (Missile m in ship.Missiles) //{
                    m.Move(speed * 2);
                //}
                
                //missileToRemove = missilesToRemove.First
                //
                //
            //}

            

            inputHelper.CheckController(GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular), ship, speed);
            inputHelper.CheckKeyboard(Keyboard.GetState(), ship, speed);
            inputHelper.CheckKeyboard(Keyboard.GetState(), ship2, speed / 2);
            //Pontus }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {


            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }


            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();



            myBackground.Draw(spriteBatch);

            spriteBatch.DrawString(font, "Score: " + score, new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(font, "Speed: " + speed, new Vector2(10, 30), Color.White);

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCounter.Update(deltaTime);
            var fps = string.Format("FPS: {0}", frameCounter.AverageFramesPerSecond);
            spriteBatch.DrawString(font, fps, new Vector2(10, 50), Color.White);
            spriteBatch.DrawString(font, "Ship position x,y: " + ship.XPos + "," + ship.YPos, new Vector2(10, 70), Color.White);

            //Pontus {
            spriteBatch.Draw(ship.Texture, new Vector2(ship.XPos, ship.YPos), null, null, null, 0.0f, new Vector2(0.4f));

            if (!ship2IsHit)
                spriteBatch.Draw(ship2.Texture, new Vector2(300, 100), null, null, null, 0.0f, new Vector2(0.4f));


            foreach (Missile m in ship.Missiles)
            {
                spriteBatch.Draw(m.Texture, new Vector2(m.XPos, m.YPos), null, null, null, 0, new Vector2(0.6f));
            }
            //Pontus }

            spriteBatch.End();

            base.Draw(gameTime);
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
