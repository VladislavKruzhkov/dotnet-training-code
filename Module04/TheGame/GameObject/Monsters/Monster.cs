using System;
using System.Collections.Generic;
using System.Text;

namespace TheGame.GameObject.Monsters
{
    public abstract class Monster : GameObject
    {
        public virtual int DamageValue { get; set; }

        public virtual void FollowPlayer(){}
    }
}