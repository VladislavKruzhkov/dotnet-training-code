using System;

namespace FigureFactory
{
    public class Triangle : IFigure
    {
        private void CheckParameters(int[] sides)
        {
            foreach (var side in sides)
            {
                if (side <=0) 
                    throw new ArgumentException("Incorrect Parameters");
            }

            Array.Sort(sides);

            if (sides[0] + sides[1] < sides[2])
                throw new ArgumentException("Triangle with this sides does not exist");
        }

        public Triangle(int side1, int side2, int side3)
        {
            int[] sides = { side1, side2, side3 };
            CheckParameters(sides);
            Perimeter = side1 + side2 + side3;
            HalfPerimeter = Perimeter * 0.5;
            Square = Math.Sqrt(HalfPerimeter * (HalfPerimeter - side1) * (HalfPerimeter - side2) * (HalfPerimeter - side3));
        }
        public double HalfPerimeter { get; }

        public double Perimeter { get; }

        public double Square { get; }
    }
}
