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
            var expectedPrice = 0.50m;
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
           var sum = itemList.Count;
           return sum;
        }
        
    }
}
