using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Net.Http.Headers;
using DiscountEngine.InterFaces;

namespace DiscountEngine
{
    public class Cart
    {
        private SortedDictionary<char, int> _cartItems;
        public ImmutableSortedDictionary<char, int>  CartItems
        {
            get { return _cartItems.ToImmutableSortedDictionary(); }
        }

        private IInventory _inventory;
        private IDiscountEngine _discountEngine;
        private IList<IDiscountRule> _rules;

        public double CartValue
        {
            get
            {
                double toRet = 0.00d;
                foreach (var item in _cartItems.Keys)
                {
                   toRet += _inventory.GetPrice(item) * _cartItems.GetValueOrDefault(item);

                }

                return toRet;
            }
        }


        public  Cart(IInventory inventory)
        {
            _inventory = inventory;
            _cartItems= new SortedDictionary<char, int>();
        }


        public void AddItem(char SKUId, int quantity)
        {
            if (_inventory.HasSKU(SKUId))
            {
                _cartItems.Add(SKUId,quantity);
            }
        }
        
        
    }
}