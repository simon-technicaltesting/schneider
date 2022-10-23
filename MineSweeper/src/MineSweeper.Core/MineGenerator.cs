using MineSweeper.Core.Abstractions;

namespace MineSweeper.Core
{
    public class MineGenerator : IMineGenerator
    {
        public List<Location> GenerateMines(int noOfMines)
        {
            var mines = new List<Location>();

            for (var i = 0; i < noOfMines; i++)
            {
                Location location;
                do
                {
                    location = GenerateMineBoardPosition();
                } while (mines.Contains(location));

                mines.Add(location);
            }

            return mines;
        }

        private static Location GenerateMineBoardPosition()
        {
            var random = new Random();
            var xPosition = random.Next(8);
            var yPosition = random.Next(8);
            return new Location(xPosition + 1, yPosition + 1); //Zero based Random
        }
    }
}