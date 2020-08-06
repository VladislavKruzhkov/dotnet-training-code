using System;

namespace RectangleHelper
{
    public class Rectangle
    {
        public Rectangle(int side1, int side2)
        {
            Perimeter = (side2 + side1) * 2;
            Square = side2 * side1;
        }
        
        public int Perimeter { get; }
        
        public int Square { get; }
    }
}
