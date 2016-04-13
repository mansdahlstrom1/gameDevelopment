using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Game1
{
    class PlayerShip : Ship
    {
        private bool hasController;
        public bool HasController { get { return hasController; } set { hasController = value; } }
        private bool hasKeyboard;
        public bool HasKeyboard { get { return hasKeyboard; } set { hasKeyboard = value; } }
        private int controllerIndex;
        public int ControllerIndex { get { return controllerIndex; } set { controllerIndex = value; } }
        private int missileCooldownMS = 500;
        public int MissileCooldownMS { get { return missileCooldownMS; } set { missileCooldownMS = value; } }
        private List<Missile> missilesToRemove = new List<Missile>();
        private Missile missileToRemove;
        private InputHelper inputHelper = new InputHelper();
        public PlayerShip(bool hasKeyboard, bool hasController, int controllerIndex)
        {
            HasKeyboard = hasKeyboard;
            HasController = hasController;
            ControllerIndex = controllerIndex;
        }

        private double oldTime;
        public void FireMain(GameTime newTime)
        {
            if ((newTime.TotalGameTime.TotalMilliseconds - missileCooldownMS) > oldTime)
            {
                if (this.Missiles.Count < 4)
                {
                    Missiles.Add(new Missile(XPos - 5, YPos, MissileTexture));
                    Missiles.Add(new Missile(XPos + 40, YPos, MissileTexture));
                    oldTime = newTime.TotalGameTime.TotalMilliseconds;
                }
            }
        }
        public void ResetPosition()
        {
            XPos = 10;
            YPos = 10;
        }
        public void ReMoveMissiles(float speed)
        {
            //Remove
            if (missileToRemove != null)
            {
                try
                {
                    Missiles.Remove(missileToRemove);
                    missilesToRemove.Remove(missileToRemove);
                    missileToRemove = null;
                }
                catch (Exception e)
                {
                    Console.WriteLine("RemoveMissile() failed");
                    //Console.WriteLine(e.Message);
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