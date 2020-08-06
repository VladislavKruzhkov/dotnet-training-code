using System;
using System.Collections.Generic;
using System.Text;

namespace TheGame.GameObject
{
    public abstract class GameObject
    {
        public virtual int XCoordinate { get; set; }

        public virtual int YCoordinate { get; set; }

        public virtual void Appear(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}
