using System.Collections.Generic;

namespace ShoppingCartKata.UnitTests
{
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