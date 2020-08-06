using System;
using System.Collections.Generic;
using System.Text;

namespace TheGame.GameObject.Bonuses
{
    public abstract class Bonus : GameObject
    {
        public virtual int BonusValue { get; set; }

        public virtual void Disappear(){}
    }
}