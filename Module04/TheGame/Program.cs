using System;
using TheGame.GameObject;
using TheGame.GameObject.Bonuses;
using TheGame.GameObject.Monsters;


namespace TheGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random rand = new Random();
            var area = new Area(100, 100);

            var apple = new Apple();
            apple.Appear(rand.Next(area.Side1), rand.Next(area.Side2));

            var banana = new Banana();
            banana.Appear(rand.Next(area.Side1), rand.Next(area.Side2));

            var cherries = new Cherries();
            cherries.Appear(rand.Next(area.Side1), rand.Next(area.Side2));

            var player = new Player("Ivan");
            player.Appear(rand.Next(area.Side1), rand.Next(area.Side2));

            var wolf = new Wolf();
            wolf.Appear(rand.Next(area.Side1), rand.Next(area.Side2));

            var bear = new Bear();
            bear.Appear(rand.Next(area.Side1), rand.Next(area.Side2));

            while (player.HealthPoints > 0)
            {

            }

            Console.ReadKey();
        }
    }
}
