using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace TheGame.GameObject
{
    public class Player : GameObject
    {
        public Player(string nickname)
        {
            Nickname = nickname;
        }

        public int HealthPoints = 10;

        public int Score = 0;

        public void MoveRight() { XCoordinate++; }

        public void MoveLeft() { XCoordinate--; }

        public void MoveUp() { YCoordinate++; }

        public void MoveDown() { YCoordinate--; }

        public string Nickname { get; set; }
    }
}
