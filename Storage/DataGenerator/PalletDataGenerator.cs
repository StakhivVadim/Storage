using Storage.Items;
using Storage.Factories;

namespace Storage.DataGenerator
{
    public class PalletDataGenerator : IPalletDataGenerator
    {
        private readonly Random _random = new();
        private readonly IBoxFactory _boxFactory;

        public PalletDataGenerator(IBoxFactory boxFactory)
        {
            _boxFactory = boxFactory ?? throw new ArgumentNullException(nameof(boxFactory));
        }

        public List<Pallet> GeneratePallets(int count)
        {
            var pallets = new List<Pallet>();

            for (int i = 0; i < count; i++)
            {
                double palletWidth = RandomDouble(50, 100);
                double palletHeight = RandomDouble(10, 30);
                double palletDepth = RandomDouble(50, 100);

                var pallet = new Pallet(
                    Guid.NewGuid(),
                    palletWidth,
                    palletHeight,
                    palletDepth
                );

                int boxCount = _random.Next(0, 6);
                for (int j = 0; j < boxCount; j++)
                {
                    try
                    {
                        var box = _boxFactory.CreateRandomBox(palletWidth, palletHeight, palletDepth);
                        pallet.AddBox(box);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Не удалось добавить коробку на паллету {pallet.Id}: {ex.Message}");
                    }
                }

                pallets.Add(pallet);
            }

            return pallets;
        }

        private double RandomDouble(double min, double max)
        {
            return _random.NextDouble() * (max - min) + min;
        }
    }
}
