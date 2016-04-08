﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    //abstract
    class Ship
    {
        //private Point position;
        private float xPos;
        private float yPos;
        public float XPos { get { return xPos; } set { xPos = value; } }
        public float YPos { get { return yPos; } set { yPos = value; } }

        private Texture2D texture;
        public Texture2D Texture { get { return texture; } set { texture = value; } }

        //private Sprite sprite; //Replaces Texture2D
        //public Sprite Sprite { get { return sprite; } set { sprite = value; } }

        private Texture2D missileTexture; // Should be Sprite?
        public Texture2D MissileTexture { get { return missileTexture; } set { missileTexture = value; } }

        private List<Missile> missiles = new List<Missile>();
        public List<Missile> Missiles { get { return missiles; } }

        private bool hasController;
        public bool HasController { get { return hasController; } set { hasController = value; } }

        private bool hasKeyboard;
        public bool HasKeyboard { get { return hasKeyboard; } set { hasKeyboard = value; } }

        private int controllerIndex;
        public int ControllerIndex { get { return controllerIndex; } set { controllerIndex = value; } }

        private List<Missile> missilesToRemove = new List<Missile>();
        private Missile missileToRemove;

        private InputHelper inputHelper = new InputHelper();

        //Default constructor
        public Ship()
        {

        }

        public Ship(float xPos, float yPos, bool hasKeyboard, bool hasController)
        {
            XPos = xPos;
            YPos = yPos;
            HasKeyboard = hasKeyboard;
            HasController = hasController;
        }

        public Ship(float xPos, float yPos, bool hasKeyboard, bool hasController, int controllerIndex)
        {
            XPos = xPos;
            YPos = yPos;
            HasKeyboard = hasKeyboard;
            HasController = hasController;
            ControllerIndex = controllerIndex;
        }

        /*
        public Ship(Sprite sprite)
        {
            Sprite = sprite //Rätt?
            X = 10;
            Y = 10;
        }
        */

        public void Move(float x, float y)
        {
            XPos += x;
            YPos += y;
        }

        public void ResetPosition()
        {
            XPos = 10;
            YPos = 10;
        }

        public void FireMain()
        {
            if (this.Missiles.Count < 2)
            {
                missiles.Add(new Missile(XPos - 5, YPos, missileTexture));
                missiles.Add(new Missile(XPos + 40, YPos, missileTexture));
            }
        }

        public void ReMoveMissiles(float speed)
        {
            //Remove
            if (missilesToRemove.Count != 0)
            {
                missileToRemove = missilesToRemove[0];

                if (missileToRemove != null)
                {
                    try
                    {
                        missiles.Remove(missileToRemove);
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("RemoveMissile() failed");
                        //System.Console.WriteLine(e.Message);
                    }
                    missilesToRemove.Remove(missileToRemove);
                    missileToRemove = null;
                }
            }

            //Move
            foreach (Missile m in this.Missiles)
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
        }

        public void FireSecondary()
        {
            System.Console.WriteLine("Whoooosh!");
        }

        public void Explode()
        {
            System.Console.WriteLine("i died :(");
        }
    }
}
