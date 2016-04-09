using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{

    abstract class Ship
    {
        //private Point position;
        private float xPos;
        private float yPos;
        public float XPos { get { return xPos; } set { xPos = value; } }
        public float YPos { get { return yPos; } set { yPos = value; } }

        private Texture2D texture;
        public Texture2D Texture { get { return texture; } set { texture = value; } }

        private Texture2D missileTexture; // Should be Sprite?
        public Texture2D MissileTexture { get { return missileTexture; } set { missileTexture = value; } }

        private List<Missile> missiles = new List<Missile>();
        public List<Missile> Missiles { get { return missiles; } }

        private List<Missile> missilesToRemove = new List<Missile>();
        private Missile missileToRemove;

        //private Sprite sprite; //Replaces Texture2D
        //public Sprite Sprite { get { return sprite; } set { sprite = value; } }


        //Default constructor
        public Ship()
        {

        }

        public void Move(float x, float y)
        {
            XPos += x;
            YPos += y;
        }

        private int missileCooldownMS = 500;
        private GameTime oldTime;

        public void FireMain(GameTime newTime)
        {
            if ((newTime.ElapsedGameTime.Milliseconds - oldTime.ElapsedGameTime.Milliseconds) > missileCooldownMS)
            {
                if (this.Missiles.Count < 4)
                {
                    Missiles.Add(new Missile(XPos - 5, YPos, MissileTexture));
                    Missiles.Add(new Missile(XPos + 40, YPos, MissileTexture));
                }
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
    }
}
