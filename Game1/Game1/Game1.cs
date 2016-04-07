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

        private GameState gameState;
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

            gameBackground = new Background();
            menuBackground = new Background();

            Texture2D gameBackgroundImage = Content.Load<Texture2D>("stars");
            Texture2D menuBackgroundImage = Content.Load<Texture2D>("images/whiteBG");

            gameBackground.Load(GraphicsDevice, gameBackgroundImage);
            menuBackground.Load(GraphicsDevice, menuBackgroundImage);

            shuttle = Content.Load<Texture2D>("images/DogpoolPortrait");
            
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
            CheckInput();

            if (gameState == GameState.Playing)
            {
            // The time since Update was called last.
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // TODO: Add your game logic here.
                gameBackground.Update(elapsed * 200);

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

            }
            else if (gameState == GameState.Loading) {
                // TODO
                // Loading

            if (!ship2IsHit)
                spriteBatch.Draw(ship2.Texture, new Vector2(300, 100), null, null, null, 0.0f, new Vector2(0.4f));


            foreach (Missile m in ship.Missiles)
            {
                spriteBatch.Draw(m.Texture, new Vector2(m.XPos, m.YPos), null, null, null, 0, new Vector2(0.6f));
            }
            //Pontus }

            spriteBatch.End();


            // TODO: Add your drawing code here
            
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
