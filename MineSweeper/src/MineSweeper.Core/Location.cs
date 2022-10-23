using MineSweeper.Core.Helpers;

namespace MineSweeper.Core
{
    public class Location
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public void MoveUp()
        {
            Y++;
        }

        public void MoveDown()
        {
            Y--;
        }

        public void MoveLeft()
        {
            X++;
        }

        public void MoveRight()
        {
            X--;
        }
        
        public override string ToString()
        {
            return ChessBoardNotationHelper.ToChessBoardNotation(X, Y);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var p = (Location)obj;
            return X == p.X && Y == p.Y;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}