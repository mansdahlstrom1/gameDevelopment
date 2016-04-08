using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class InputHelper
    {
        GamePadState[] oldGamePadStates = { new GamePadState(), new GamePadState(), new GamePadState(), new GamePadState() };
        KeyboardState oldGameKeyboardState;

        public void CheckGameInput(List<Ship> activeShips, List<GamePadState> newGamePadStates, KeyboardState newGameKeyBoardState, float speed)
        {
            foreach (Ship s in activeShips)
            {
                if (s.HasController)
                {
                    CheckController(newGamePadStates[s.ControllerIndex], oldGamePadStates[s.ControllerIndex],  s, speed);
                    oldGamePadStates[s.ControllerIndex] = newGamePadStates[s.ControllerIndex];
                }
                //If ship has keyboard then check controller input
                if (s.HasKeyboard)
                {
                    CheckKeyboard(newGameKeyBoardState, oldGameKeyboardState, s, speed);
                    oldGameKeyboardState = newGameKeyBoardState;
                }
            }
        }

        private void CheckController(GamePadState newGamePadState, GamePadState oldGamePadState, Ship ship, float speed)
        {
            //A, B, X, Y
            if (newGamePadState.Buttons.A == ButtonState.Pressed && oldGamePadState.Buttons.A == ButtonState.Released)
            {
                System.Console.WriteLine("A test");
            }
            if (newGamePadState.Buttons.B == ButtonState.Pressed && oldGamePadState.Buttons.B == ButtonState.Released)
            {
                
            }
            if (newGamePadState.Buttons.X == ButtonState.Pressed && oldGamePadState.Buttons.X == ButtonState.Released)
            {
                
            }
            if (newGamePadState.Buttons.Y == ButtonState.Pressed && oldGamePadState.Buttons.Y == ButtonState.Released)
            {
                
            }


            //Shoulders
            if (newGamePadState.Buttons.RightShoulder == ButtonState.Pressed && oldGamePadState.Buttons.RightShoulder == ButtonState.Released)
            {
                ship.FireMain();
            }
            if (newGamePadState.Buttons.LeftShoulder == ButtonState.Pressed && oldGamePadState.Buttons.LeftShoulder == ButtonState.Released)
            {

            }


            //Triggers
            //if (newGamePadState.Triggers.Right != 0 && oldGamePadState.Triggers.Right == 0)
            if (newGamePadState.Triggers.Right == 1 && oldGamePadState.Triggers.Right != 1)
            {

            }
            if (newGamePadState.Triggers.Left == 1 && oldGamePadState.Triggers.Left != 1)
            {
                ship.FireSecondary();
            }


            //Start, back and big button
            if (newGamePadState.Buttons.Start == ButtonState.Pressed && oldGamePadState.Buttons.Start == ButtonState.Released)
            {
                ship.ResetPosition();
            }
            if (newGamePadState.Buttons.BigButton == ButtonState.Pressed && oldGamePadState.Buttons.BigButton == ButtonState.Released)
            {
                //Funkar inte :(
            }
            if (newGamePadState.Buttons.Back == ButtonState.Pressed && oldGamePadState.Buttons.Back == ButtonState.Released)
            {

            }


            //Left Stick
            //Press
            if (newGamePadState.Buttons.LeftStick == ButtonState.Pressed && oldGamePadState.Buttons.LeftStick == ButtonState.Released)
            {

            }
            //Up
            if (newGamePadState.ThumbSticks.Left.Y > 0)
            {
                ship.Move(0, (newGamePadState.ThumbSticks.Left.Y * speed) * -1);
            }
            //Down
            if (newGamePadState.ThumbSticks.Left.Y < 0)
            {
                ship.Move(0, (newGamePadState.ThumbSticks.Left.Y * speed) * -1);
            }
            //Left
            if (newGamePadState.ThumbSticks.Left.X < 0)
            {
                ship.Move((newGamePadState.ThumbSticks.Left.X * speed), 0);
            }
            //Right
            if (newGamePadState.ThumbSticks.Left.X > 0)
            {
                ship.Move(newGamePadState.ThumbSticks.Left.X * speed, 0);
            }


            //Right Stick
            if (newGamePadState.Buttons.RightStick == ButtonState.Pressed)
            {

            }
            //Up
            if (newGamePadState.ThumbSticks.Right.Y > 0)
            {

            }
            //Down
            if (newGamePadState.ThumbSticks.Right.Y < 0)
            {
                
            }
            //Left
            if (newGamePadState.ThumbSticks.Right.X < 0)
            {

            }
            //Right
            if (newGamePadState.ThumbSticks.Right.X > 0)
            {

            }

            //D-Pad
            //Up
            if (newGamePadState.DPad.Up == ButtonState.Pressed && oldGamePadState.DPad.Up == ButtonState.Released)
            {

            }
            //Down
            if (newGamePadState.DPad.Down == ButtonState.Pressed && oldGamePadState.DPad.Down == ButtonState.Released)
            {

            }
            //Left
            if (newGamePadState.DPad.Left == ButtonState.Pressed && oldGamePadState.DPad.Left == ButtonState.Released)
            {

            }
            //Right
            if (newGamePadState.DPad.Right == ButtonState.Pressed && oldGamePadState.DPad.Right == ButtonState.Released)
            {

            }
        }

        KeyboardState oldKeyboardState;
        public void CheckMenuKeyboard(KeyboardState newKeyboardState, ref Game1.GameState gameState)
        {
            if (newKeyboardState.IsKeyDown(Keys.Escape) && !oldKeyboardState.IsKeyDown(Keys.Escape))
            {
                System.Console.WriteLine("Escape!");
                if (gameState == Game1.GameState.Playing)
                {
                    System.Console.WriteLine("Paus!");
                    gameState = Game1.GameState.Paused;
                }
                else if (gameState == Game1.GameState.Paused)
                {
                    System.Console.WriteLine("Play!");
                    gameState = Game1.GameState.Playing;
                }
            }

        }

        KeyboardState oldKeyboardState;
        public void CheckMenuKeyboard(KeyboardState newKeyboardState, ref Game1.GameState gameState)
        {
            if (newKeyboardState.IsKeyDown(Keys.Escape) && !oldKeyboardState.IsKeyDown(Keys.Escape))
            {
                System.Console.WriteLine("Escape!");
                if (gameState == Game1.GameState.Playing)
                {
                    System.Console.WriteLine("Paus!");
                    gameState = Game1.GameState.Paused;
                }
                else if (gameState == Game1.GameState.Paused)
                {
                    System.Console.WriteLine("Play!");
                    gameState = Game1.GameState.Playing;
                }
            }

            oldKeyboardState = newKeyboardState;
        }


        private void CheckKeyboard(KeyboardState newKeyboardState, KeyboardState oldKeyboardState, Ship ship, float speed)
        {
            //W, A, S, D
            //if (Keyboard.GetState().IsKeyDown(Keys.W))
            if (newKeyboardState.IsKeyDown(Keys.W))//&& !oldState.IsKeyDown(Keys.W))
            {
                ship.Move(0, speed * -1);
            }
            if (newKeyboardState.IsKeyDown(Keys.S))//&& !oldState.IsKeyDown(Keys.S))
            {
                ship.Move(0, speed);
            }
            if (newKeyboardState.IsKeyDown(Keys.A))//&& !oldState.IsKeyDown(Keys.A))
            {
                ship.Move(speed * -1, 0);
            }
            if (newKeyboardState.IsKeyDown(Keys.D))//&& !oldState.IsKeyDown(Keys.D))
            {
                ship.Move(speed, 0);
            }

            //Arrow keys
            if (newKeyboardState.IsKeyDown(Keys.Up))//&& !oldState.IsKeyDown(Keys.W))
            {
                ship.Move(0, speed * -1);
            }
            if (newKeyboardState.IsKeyDown(Keys.Down))//&& !oldState.IsKeyDown(Keys.S))
            {
                ship.Move(0, speed);
            }
            if (newKeyboardState.IsKeyDown(Keys.Left))//&& !oldState.IsKeyDown(Keys.A))
            {
                ship.Move(speed * -1, 0);
            }
            if (newKeyboardState.IsKeyDown(Keys.Right))//&& !oldState.IsKeyDown(Keys.D))
            {
                ship.Move(speed, 0);
            }

            //Space, Escape

            if (newKeyboardState.IsKeyDown(Keys.Space) && !oldKeyboardState.IsKeyDown(Keys.Space))
            {
                ship.FireMain();
            }
            oldKeyboardState = newKeyboardState;
        }
    }
}
