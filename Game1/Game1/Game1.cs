﻿using Microsoft.Xna.Framework;
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

        public enum GameState
        {
            StartMenu,
            Loading,
            Playing,
            Paused
        }
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //private SpacePlayerShip spacePlayerShip;
        private Background gameBackground;
        private Background menuBackground;
        private Texture2D shuttle;
        private SpriteFont font;

        private Button btnPauseResume;
        private Button btnPauseMainMenu;
        private Button btnStartMenuPlay;
        private Button btnStartMenuOptions;
        private Button btnStartMenuExit;

        private int score = 0;
        private float speed = 10;
        private FrameCounter frameCounter = new FrameCounter();

        

        private GameState gameState;
        private GameTime gameTime;

        private InputHelper inputHelper = new InputHelper();
        private CheckCollisions checkCollisions = new CheckCollisions();

        private List<PlayerShip> activePlayerShips = new List<PlayerShip>();
        private List<GamePadState> activeControllerStates = new List<GamePadState>();

        private Connect con;
        private Player p1;
        

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

            gameState = GameState.Playing;
            gameTime = new GameTime();

            //Check how many players are active and what controllers are connected and stuff
            activePlayerShips.Add(new PlayerShip(true, true, 0));
            activePlayerShips.Add(new PlayerShip(false, true, 1));
            //activePlayerShips.Add(new PlayerShip(false, true, 2));
            //activePlayerShips.Add(new PlayerShip(false, true, 3));
            con = new Connect();
            Player p1 = con.getPlayerByUsername("dahlan1337");
            System.Console.WriteLine(p1.Username);
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

            Texture2D gameBackgroundImage = Content.Load<Texture2D>("images/stars");
            Texture2D menuBackgroundImage = Content.Load<Texture2D>("images/whiteBG");

            gameBackground.Load(GraphicsDevice, gameBackgroundImage);
            menuBackground.Load(GraphicsDevice, menuBackgroundImage);

            shuttle = Content.Load<Texture2D>("images/DogpoolPortrait");
            font = Content.Load<SpriteFont>("myFont");
            activePlayerShips[0].Texture = Content.Load<Texture2D>("images/PontusSpacesaucerPinkPortrait");
            activePlayerShips[1].Texture = Content.Load<Texture2D>("images/DogpoolPortrait");


            //Buttons
            Texture2D TextureBtn = Content.Load<Texture2D>("images/button");
            btnPauseResume = new Button(TextureBtn, GraphicsDevice, "Resume", font);
            btnPauseResume.setPosition(new Vector2(320, 200));

            btnPauseMainMenu = new Button(TextureBtn, GraphicsDevice, "Main Menu", font);
            btnPauseMainMenu.setPosition(new Vector2(320, 260));

            btnStartMenuPlay = new Button(TextureBtn, GraphicsDevice, "Play", font);
            btnStartMenuPlay.setPosition(new Vector2(320, 140));

            btnStartMenuOptions = new Button(TextureBtn, GraphicsDevice, "Options", font);
            btnStartMenuOptions.setPosition(new Vector2(320, 200));

            btnStartMenuExit = new Button(TextureBtn, GraphicsDevice, "Exit", font);
            btnStartMenuExit.setPosition(new Vector2(320, 260));


            foreach (PlayerShip s in activePlayerShips)
            {
                s.MissileTexture = Content.Load<Texture2D>("images/laser_small");
            }


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
            // TODO: Add your game logic here.
            MouseState mouseState = Mouse.GetState();
            if (gameState == GameState.Playing)
            {

                CollisionCheck();

                // The time since Update was called last.
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                //This makes the background scroll
                gameBackground.Update(elapsed * 200);
                IsMouseVisible = false;

                score += ((int)speed / 2);
            }
            else if (gameState == GameState.Paused)
            {
                IsMouseVisible = true;

                if (btnPauseResume.Update(mouseState))
                {
                    if (gameState == GameState.Paused)
                    {
                        gameState = GameState.Playing;
                    
                    }
                }
               else  if (btnPauseMainMenu.Update(mouseState))
                {
                    if (gameState == GameState.Paused)
                    {
                        gameState = GameState.StartMenu;
                    }
                }
            }
            else if(gameState == GameState.StartMenu)
            {
                IsMouseVisible = true;
                if (btnStartMenuPlay.Update(mouseState))
                {
                    // What happend is Play is pressed
                    if (gameState == GameState.StartMenu)
                    {
                        gameState = GameState.Playing;
                    }

                }
                else if (btnStartMenuOptions.Update(mouseState))
                {
                    // What happend is Options is pressed

                }
                else if (btnStartMenuExit.Update(mouseState))
                {
                    // What happend is Exit is pressed
                    if (gameState == GameState.StartMenu)
                    {
                        //System.Environment.Exit(1);
                    }
                }
            }
            //CheckInput(activeShips);

            if (gameState == GameState.Playing)
                {
                foreach (PlayerShip s in activePlayerShips)
                {
                    //Add the state of active controllers to a list to be sent to input helper
                    activeControllerStates.Add(GamePad.GetState(s.ControllerIndex, GamePadDeadZone.Circular));
                    //Move and remove missiles
                    s.ReMoveMissiles(speed);
            }

                inputHelper.CheckGameInput(activePlayerShips, activeControllerStates, Keyboard.GetState(), speed, gameTime);
                activeControllerStates.Clear();
            }

            inputHelper.CheckMenuKeyboard(Keyboard.GetState(), ref gameState);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            //if (gameState == GameState.Playing)
            //{
                gameBackground.Draw(spriteBatch);
                spriteBatch.DrawString(font, "Score: " + score, new Vector2(10, 10), Color.White);
                spriteBatch.DrawString(font, "Speed: " + speed, new Vector2(10, 30), Color.White);

                var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                frameCounter.Update(deltaTime);
                var fps = string.Format("FPS: {0}", frameCounter.AverageFramesPerSecond);
                spriteBatch.DrawString(font, fps, new Vector2(10, 50), Color.White);

                foreach (PlayerShip s in activePlayerShips)
                {
                    spriteBatch.DrawString(font, "PlayerShip[" + s.ControllerIndex + "] position x,y: " + s.XPos + "," + s.YPos, new Vector2(10, (70 + s.ControllerIndex * 20)), Color.White);
                    spriteBatch.Draw(s.Texture, new Vector2(s.XPos, s.YPos), null, null, null, 0.0f, new Vector2(0.4f));
                    foreach (Missile m in s.Missiles)
                    {
                        //if (CollisionCheck())
                        //{
                        spriteBatch.Draw(m.Texture, new Vector2(m.XPos, m.YPos), null, null, null, 0, new Vector2(0.6f));
                        //}
                    }
                }
            //}
            //else
            if (gameState == GameState.StartMenu)
            {
                // TODO
                // Main Menu
                menuBackground.Draw(spriteBatch);
                btnStartMenuPlay.Draw(spriteBatch, font);
                btnStartMenuOptions.Draw(spriteBatch, font);
                btnStartMenuExit.Draw(spriteBatch, font);



            }
            else if (gameState == GameState.Paused)
            {
                // TODO
                // Paused
                //menuBackground.Draw(spriteBatch);
                btnPauseResume.Draw(spriteBatch, font);
                btnPauseMainMenu.Draw(spriteBatch, font);

            }
            else if (gameState == GameState.Loading)
            {
                // TODO
                // Loading


            }


            spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        //Test
        private void CollisionCheck()
        {


            Rectangle rect1 = new Rectangle(new Point((int)activePlayerShips[0].XPos, (int)activePlayerShips[0].YPos), new Point(50));
            Rectangle rect2 = new Rectangle(new Point((int)activePlayerShips[1].XPos, (int)activePlayerShips[1].YPos), new Point(50));
            if (rect1.Intersects(rect2))
                {
                //Collision
                //System.Console.WriteLine("Crash!");
            }
        }

        // Here we can send in each players specific value!
        // Not done, don't use
        private bool PlayerShipIsWithinLimits(float playerX, float playerY)
        {
            if (playerX >= 0 && playerX < (800 - 40) && playerY >= 0 && playerY < (480 - 40))
            {
                return true;
            }
            return false;
        }
    }
}
