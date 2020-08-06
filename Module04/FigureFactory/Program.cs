using System;

namespace FigureFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var circleRadius3 = new Circle(3);
            var triangleSides3X4X5 = new Triangle(3, 4, 5);
            var foursquareSide2 = new Foursquare(2);
            var rectangleSides2X3 = new Rectangle(2, 3);

            Console.WriteLine($"{circleRadius3.Perimeter} {circleRadius3.Square}");
            Console.WriteLine($"{triangleSides3X4X5.Perimeter} {triangleSides3X4X5.Square}");
            Console.WriteLine($"{foursquareSide2.Perimeter} {foursquareSide2.Square}");
            Console.WriteLine($"{rectangleSides2X3.Perimeter} {rectangleSides2X3.Square}");

            Console.ReadKey();
            Console.ReadKey();
        }
    }
}