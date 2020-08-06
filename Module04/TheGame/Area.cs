namespace TheGame
{
    public class Area
    {
        public Area(int side1, int side2)
        {
            Square = side1 * side2;
            Perimeter = (side1 + side2) * 2;
            Side1 = side1;
            Side2 = side2;
        }

        public double Perimeter { get; }

        public double Square { get; }

        public int Side1 { get; }

        public int Side2 { get; }
    }
}
