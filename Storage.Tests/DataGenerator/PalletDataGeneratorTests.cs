using NUnit.Framework;
using Storage.DataGenerator;
using Storage.Factories;

namespace Storage.Tests.DataGenerator
{
    public class PalletDataGeneratorTests
    {
        private IPalletDataGenerator _palletDataGenerator;

        [SetUp]
        public void Setup()
        {
            _palletDataGenerator = new PalletDataGenerator(new BoxFactory());
        }

        [Test]
        public void GeneratePallets_ShouldCreateRequestedNumber()
        {
            int count = 5;
            var pallets = _palletDataGenerator.GeneratePallets(count);

            Assert.AreEqual(count, pallets.Count);
        }

        [Test]
        public void GeneratePallets_BoxesShouldFitOnPallet()
        {
            var pallets = _palletDataGenerator.GeneratePallets(10);

            foreach (var pallet in pallets)
            {
                foreach (var box in pallet.Boxes)
                {
                    Assert.LessOrEqual(box.Width, pallet.Width);
                    Assert.LessOrEqual(box.Height, pallet.Height);
                }
            }
        }
    }
}
