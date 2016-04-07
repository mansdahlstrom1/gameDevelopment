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

        KeyboardState oldKeyboardState;
        GamePadState oldGamePadState;

        public void CheckController(GamePadState newGamePadState, Ship ship, float speed)
        {
            //A, B, X, Y
            if (newGamePadState.Buttons.A == ButtonState.Pressed && oldGamePadState.Buttons.A == ButtonState.Released)
            {
                System.Console.WriteLine("A");
            }
            if (newGamePadState.Buttons.B == ButtonState.Pressed && oldGamePadState.Buttons.B == ButtonState.Released)
            {
                System.Console.WriteLine("B");
            }
            if (newGamePadState.Buttons.X == ButtonState.Pressed && oldGamePadState.Buttons.X == ButtonState.Released)
            {
                System.Console.WriteLine("X");
            }
            if (newGamePadState.Buttons.Y == ButtonState.Pressed && oldGamePadState.Buttons.Y == ButtonState.Released)
            {
                System.Console.WriteLine("Y");
            }


            //Shoulders
            if (newGamePadState.Buttons.RightShoulder == ButtonState.Pressed && oldGamePadState.Buttons.RightShoulder == ButtonState.Released)
            {
                System.Console.WriteLine("Right Shoulder");
            }
            if (newGamePadState.Buttons.LeftShoulder == ButtonState.Pressed && oldGamePadState.Buttons.LeftShoulder == ButtonState.Released)
            {
                System.Console.WriteLine("Left Shoulder");
            }


            //Triggers
            //if (newGamePadState.Triggers.Right != 0 && oldGamePadState.Triggers.Right == 0)
            if (newGamePadState.Triggers.Right == 1 && oldGamePadState.Triggers.Right != 1)
            {
                ship.FireMain();
            }
            if (newGamePadState.Triggers.Left == 1 && oldGamePadState.Triggers.Left != 1)
            {
                ship.FireSecondary();
            }


            //Start, back and big button
            if (newGamePadState.Buttons.Start == ButtonState.Pressed && oldGamePadState.Buttons.Start == ButtonState.Released)
            {
                System.Console.WriteLine("Start");
                ship.ResetPosition();
            }
            if (newGamePadState.Buttons.BigButton == ButtonState.Pressed && oldGamePadState.Buttons.BigButton == ButtonState.Released)
            {
                //Funkar inte :(
                System.Console.WriteLine("Big Button!");
            }
            if (newGamePadState.Buttons.Back == ButtonState.Pressed && oldGamePadState.Buttons.Back == ButtonState.Released)
            {
                System.Console.WriteLine("Back");
                //Exit();
            }


            //Left Stick
            //Press
            if (newGamePadState.Buttons.LeftStick == ButtonState.Pressed && oldGamePadState.Buttons.LeftStick == ButtonState.Released)
            {
                System.Console.WriteLine("Left Stick pressed!");
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
                ship.Move(newGamePadState.ThumbSticks.Left.X * speed, 0);
            }
            //Right
            if (newGamePadState.ThumbSticks.Left.X > 0)
            {
                ship.Move(newGamePadState.ThumbSticks.Left.X * speed, 0);
            }


            //Right Stick
            if (newGamePadState.Buttons.RightStick == ButtonState.Pressed)
            {
                System.Console.WriteLine("Right Stick pressed!");
            }
            //Up
            if (newGamePadState.ThumbSticks.Right.Y > 0)
            {
                //Does nothing
            }
            //Down
            if (newGamePadState.ThumbSticks.Right.Y < 0)
            {
                //Does nothing
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
                System.Console.WriteLine("Speed: " + ++speed);
            }
            //Down
            if (newGamePadState.DPad.Down == ButtonState.Pressed && oldGamePadState.DPad.Down == ButtonState.Released)
            {
                if (speed > 0)
                {
                    System.Console.WriteLine("Speed: " + --speed);
                }
            }
            //Left
            if (newGamePadState.DPad.Left == ButtonState.Pressed && oldGamePadState.DPad.Left == ButtonState.Released)
            {

            }
            //Right
            if (newGamePadState.DPad.Right == ButtonState.Pressed && oldGamePadState.DPad.Right == ButtonState.Released)
            {

            }

            oldGamePadState = newGamePadState;
        }

        public void CheckKeyboard(KeyboardState newKeyboardState, Ship ship, float speed)
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
            if (newKeyboardState.IsKeyDown(Keys.Escape) && !oldKeyboardState.IsKeyDown(Keys.Escape))
            {
                //Exit(); // Eller paus eller ngt, vi får se
            }

            oldKeyboardState = newKeyboardState;
        }
    }
}
