using Storage.Items;

namespace Storage.Factories
{
    public class BoxFactory : IBoxFactory
    {
        private readonly Random _random = new();

        public Box CreateRandomBox(double maxWidth, double maxHeight, double maxDepth)
        {
            double boxWidth = RandomDouble(10, maxWidth);
            double boxHeight = RandomDouble(5, maxHeight);
            double boxDepth = RandomDouble(10, maxDepth);
            double boxWeight = RandomDouble(5, 30);
            DateTime productionDate = DateTime.Today.AddDays(-_random.Next(0, 150));

            return new Box(
                Guid.NewGuid(), 
                boxWidth,
                boxHeight,
                boxDepth,
                boxWeight,
                productionDate);
        }

        private double RandomDouble(double min, double max)
        {
            return _random.NextDouble() * (max - min) + min;
        }
    }
}
