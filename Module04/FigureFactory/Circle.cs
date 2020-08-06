using System;

namespace FigureFactory
{
    public class Circle : IFigure
    {
        public Circle (int radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Incorrect Parameters");
            Perimeter = Math.PI * radius * 2;
            Square = Math.PI * radius * radius;
        }

        public double Perimeter { get; }

        public double Square { get; }
    }
}
