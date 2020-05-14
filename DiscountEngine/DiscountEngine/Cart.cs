using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace DiscountEngine
{
    public class Cart
    {
        private Dictionary<char, int> _itemsInCart;

        public Dictionary<char, int> CartItems { get; private set; }

        public double CartValue { get; private set; }
        public double CostToConsumer { get; set; }

        public  Cart()
        {
            _itemsInCart = new Dictionary<char, int>();
        }
        
        
    }
}