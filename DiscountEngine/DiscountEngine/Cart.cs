using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using DiscountEngine.InterFaces;

namespace DiscountEngine
{
    public class Cart
    {
        private SortedDictionary<char, int> _cartItems;
        private IInventory _inventory;

        public double CartValue { get; private set; }
        public double CostToConsumer { get; set; }

        public  Cart(IInventory inventory)
        {
            _inventory = inventory;
            _cartItems= new SortedDictionary<char, int>();
        }

        public void AddItem(char SKUId, int quantity)
        {
           _cartItems.Add(SKUId,quantity);
        }
        
        
    }
}