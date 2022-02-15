using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using NUnit.Framework;

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
    }

    public class Checkout
    {
        List<string> itemList = new List<string>();

        public decimal Scan(string item)
        {
            itemList.Add(item);
            var discount = 0M;
            var sum = itemList.Count * 0.5;
            if (itemList.Count == 3)
            {
                discount = (decimal )sum * 0.13M;

            }
            return (decimal) sum - discount;
        }
    }
}
