using System;
using System.Reflection.Metadata.Ecma335;
using NUnit.Framework;
using ShoppingCartKata.UnitTests;

namespace ShoppingCartKata
{
    public class Tests
    {
        private Checkout _checkout;

        [SetUp]
        public void Setup()
        {
            _checkout = new Checkout();
        }

        [Test]
        public void GivenOneItem_ReturnPrice()
        {
            var item = "A99";
            var expectedPrice = 0.50M;
            var output = _checkout.Scan(item);

            Assert.AreEqual(expectedPrice, output);
        }

        [Test]
        public void GivenTwoIdenticalItems_ReturnPrice()
        {
            var item = "A99";
            var expectedPrice = 1.00M;
            _checkout.Scan(item);
            var output = _checkout.Scan(item);
            Assert.AreEqual(expectedPrice, output);

        }
        [Test]
        public void GivenThreeIdenticalItems_ReturnDiscountedPrice()
        {
            var item = "A99";
            var expectedPrice = 1.30M;
            _checkout.Scan(item);
            _checkout.Scan(item);
            var output = _checkout.Scan(item);
            Assert.AreEqual(expectedPrice, output);

        }
        [Test]
        public void GivenTwoDifferentItems_ReturnPrice()
        {
            var item = "A99";
            var expectedPrice = 0.80M;
            _checkout.Scan("B15");
            var output = _checkout.Scan(item);
            Assert.AreEqual(expectedPrice, output);
        }
    }
}
