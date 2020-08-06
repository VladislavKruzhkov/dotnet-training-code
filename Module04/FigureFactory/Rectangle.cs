using System;

namespace FigureFactory
{
    public class Rectangle : IFigure
    {
        private void CheckParameters(int[] sides)
        {
            foreach (var side in sides)
            {
                if (side <= 0)
                    throw new ArgumentException("Incorrect Parameters");
            }
        }

        public int Side1, Side2;

        public Rectangle(int side1, int side2)
        {
            int[] sides = { side1, side2 };
            CheckParameters(sides);
            Square = side1 * side2;
            Perimeter = (side1 + side2) * 2;
            Side1 = side1;
            Side2 = side2;
        }

        public double Perimeter { get; }

        public double Square { get; }
    }
}
