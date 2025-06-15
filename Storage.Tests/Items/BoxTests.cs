using NUnit.Framework;
using Storage.Items;

namespace Storage.Tests.Items
{
    public class BoxTests
    {
        [Test]
        public void Box_Creation_WithValidDates_ShouldSetExpirationDateCorrectly()
        {
            var productionDate = new DateTime(2025, 1, 1);
            var box = new Box(Guid.NewGuid(), 10, 10, 10, 5, productionDate);

            Assert.AreEqual(productionDate.AddDays(100), box.ExpirationDate);
        }

        [Test]
        public void Box_Creation_WithExpirationOverride_ShouldUseOverride()
        {
            var expirationOverride = new DateTime(2025, 12, 31);
            var box = new Box(Guid.NewGuid(), 10, 10, 10, 5, expirationOverride: expirationOverride);

            Assert.AreEqual(expirationOverride, box.ExpirationDate);
        }

        [Test]
        public void Box_Creation_WithoutProductionOrExpiration_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => new Box(Guid.NewGuid(), 10, 10, 10, 5));
        }
    }
}
