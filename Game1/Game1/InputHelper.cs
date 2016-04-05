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
        public void CheckInput(KeyboardState keyboardState, GamePadState gpStateOne)
        {

            //System.Console.WriteLine(Keyboard.GetState().GetPressedKeys());
            //
            //System.Console.WriteLine("Keyboard.GetState().GetPressedKeys() Loop");
            //foreach (var key in Keyboard.GetState().GetPressedKeys())
            //{
            //    System.Console.WriteLine(key.GetType() + " <Type - key>" + key);
            //}

            //W, A, S, D
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) )
            {
              
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
            if (GamePad.GetState(PlayerIndex.One).Triggers.Right > 0)
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
              
            }

            //Left Stick
            if (GamePad.GetState(PlayerIndex.One).Buttons.LeftStick == ButtonState.Pressed)
            {
            }
            //Right
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0)
            {
                
            }
            //Left
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0 )
            {
               
            }
            //Up
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0 )
            {
               
            }
            //Down
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0 )
            {
               
            }

            //Right Stick
            if (GamePad.GetState(PlayerIndex.One).Buttons.RightStick == ButtonState.Pressed)
            {
                System.Console.WriteLine("Right Stick pressed!");
            }
            //Right
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X > 0 )
            {
                
            }
            //Left
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X < 0 )
            {
               
            }
            //Up
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0 )
            {
              
            }
            //Down
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < 0 )
            {
               
            }

        }
    }
}
