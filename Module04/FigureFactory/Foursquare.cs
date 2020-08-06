using System;

namespace FigureFactory
{
    public class Foursquare : IFigure
    {
        public Foursquare(int side)
        {
            if (side <= 0)
                throw new ArgumentException("Incorrect Parameters");
            Perimeter = side * 4;
            Square = side * side;
        }

        public double Perimeter { get; }

        public double Square { get; }
    }
}
