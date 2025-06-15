using System;
using System.Collections.Generic;
using NUnit.Framework;
using Storage.Factories;

namespace Storage.Tests.Factories
{
    public class BoxFactoryTests
    {
        private IBoxFactory _boxFactory;

        [SetUp]
        public void Setup()
        {
            _boxFactory = new BoxFactory();
        }

        [Test]
        public void CreateRandomBox_ShouldCreateBoxWithinGivenSize()
        {
            double maxWidth = 50;
            double maxHeight = 20;
            double maxDepth = 50;

            var box = _boxFactory.CreateRandomBox(maxWidth, maxHeight, maxDepth);

            Assert.That(box.Width, Is.LessThanOrEqualTo(maxWidth));
            Assert.That(box.Height, Is.LessThanOrEqualTo(maxHeight));
            Assert.That(box.Depth, Is.LessThanOrEqualTo(maxDepth));
        }
    }
}
