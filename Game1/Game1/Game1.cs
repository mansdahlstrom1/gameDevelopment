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

        enum GameState
        {
            StartMenu,
            Loading,
            Playing,
            Paused
        }
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //private Spaceship spaceship;
        private Background gameBackground;
        private Background menuBackground;
        private Texture2D shuttle;
        private Texture2D missileTexture;
        private SpriteFont font;
        private Texture2D startButton;
        private Texture2D exitButton;
        private Texture2D pauseButton;
        private Texture2D resumeButton;
        private Texture2D loadingScreen;
        private int score = 0;
        private float speed = 3;
        private List<Player> players = new List<Player>();
        private float speed = 10;
        private FrameCounter frameCounter = new FrameCounter();
        private float speed = 10.0f;

        private GameState gameState;
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
            paused = false;
            CheckInput();
            //spaceship = new Spaceship();
            foreach (Player p in players)
            {
                p.X = 250;
                p.Y = 250;
                p.Shuttle = Content.Load<Texture2D>("images/DogpoolPortrait");
            }
            gameState = GameState.Playing;

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

            gameBackground = new Background();
            menuBackground = new Background();

            Texture2D gameBackgroundImage = Content.Load<Texture2D>("stars");
            Texture2D menuBackgroundImage = Content.Load<Texture2D>("images/whiteBG");

            gameBackground.Load(GraphicsDevice, gameBackgroundImage);
            menuBackground.Load(GraphicsDevice, menuBackgroundImage);

            shuttle = Content.Load<Texture2D>("images/DogpoolPortrait");

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
            CheckInput();

            if (gameState == GameState.Playing)
            {
            // The time since Update was called last.
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // TODO: Add your game logic here.
                gameBackground.Update(elapsed * 200);

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

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (gameState == GameState.Playing)
            {

                gameBackground.Draw(spriteBatch);
                spriteBatch.Draw(shuttle, new Vector2(heroShipX, heroShipY));
            spriteBatch.DrawString(font, "Score: " + score, new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(font, "Speed: " + speed, new Vector2(10, 30), Color.White);

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCounter.Update(deltaTime);
            var fps = string.Format("FPS: {0}", frameCounter.AverageFramesPerSecond);
            spriteBatch.DrawString(font, fps, new Vector2(10, 50), Color.White);
                spriteBatch.DrawString(font, "heroShip position X,Y: " + heroShipX + "," + heroShipY, new Vector2(10, 70), Color.White);

            } else if (gameState == GameState.StartMenu){
                // TODO
                // Main Menu

                
                
            } else if(gameState == GameState.Paused) {
                // TODO
                // Paused
                menuBackground.Draw(spriteBatch);

            //Pontus {
            foreach (Ship s in activeShips)
            {
                spriteBatch.DrawString(font, "Ship[" + s.ControllerIndex + "] position x,y: " + s.XPos + "," + s.YPos, new Vector2(10, 70), Color.White);
                spriteBatch.Draw(s.Texture, new Vector2(s.XPos, s.YPos), null, null, null, 0.0f, new Vector2(0.4f));
            }
            else if (gameState == GameState.Loading) {
                // TODO
                // Loading

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


            // TODO: Add your drawing code here
            
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
