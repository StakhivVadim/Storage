using NUnit.Framework;
using Storage.Items;


namespace Storage.Tests.Items
{
    public class PalletTests
    {
        [Test]
        public void Pallet_AddBox_ThrowsIfBoxTooBig()
        {
            var pallet = new Pallet(Guid.NewGuid(), 20, 10, 20);
            var box = new Box(Guid.NewGuid(), 30, 5, 10, 2, DateTime.Today);

            Assert.Throws<ArgumentException>(() => pallet.AddBox(box));
        }

        [Test]
        public void Pallet_Weight_IsSumOfBoxesPlusOwnWeight()
        {
            var pallet = new Pallet(Guid.NewGuid(), 50, 20, 50);

            var box1 = new Box(Guid.NewGuid(), 10, 10, 10, 5, DateTime.Today);
            var box2 = new Box(Guid.NewGuid(), 15, 10, 10, 7, DateTime.Today);

            pallet.AddBox(box1);
            pallet.AddBox(box2);

            double expectedWeight = 30 + box1.Weight + box2.Weight;

            Assert.AreEqual(expectedWeight, pallet.Weight);
        }

        [Test]
        public void Pallet_ExpirationDate_IsMinimumOfBoxes()
        {
            var pallet = new Pallet(Guid.NewGuid(), 50, 20, 50);

            var box1 = new Box(Guid.NewGuid(), 10, 10, 10, 5, DateTime.Today.AddDays(10));
            var box2 = new Box(Guid.NewGuid(), 15, 10, 10, 7, DateTime.Today.AddDays(5));

            pallet.AddBox(box1);
            pallet.AddBox(box2);

            Assert.AreEqual(box2.ExpirationDate, pallet.ExpirationDate);
        }

        [Test]
        public void Pallet_ExpirationDate_WhenNoBoxes_IsMaxValue()
        {
            var pallet = new Pallet(Guid.NewGuid(), 50, 20, 50);
            Assert.AreEqual(DateTime.MaxValue, pallet.ExpirationDate);
        }
    }
}
