using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Xml;
using DiscountEngine.InterFaces;

namespace DiscountEngine
{
    public class SameSKUFixedPriceRule:IDiscountRule
    {

        private char _SKUId;
        private int _qty;
        private double _price;
        private IInventory _inventory;

        public SameSKUFixedPriceRule(char skuId, int qty, double price, IInventory inventory)
        {
            _SKUId = skuId;
            _qty = qty;
            _price = price;
            _inventory = inventory;
        }
        public bool isApplicableOnCart(Cart cart)
        {
            return cart.CartItems.ContainsKey(_SKUId) && cart.CartItems.GetValueOrDefault(_SKUId) >= _qty;
        }

        public double CalculateDiscountAmount(Cart cart)
        {
            int noOfItems = cart.CartItems.GetValueOrDefault(_SKUId);
            if (isApplicableOnCart(cart))
            {
                var actualPricePerItem = _inventory.GetPrice(_SKUId);
                var priceForQty = cart.CartItems.GetValueOrDefault(_SKUId) / _qty  * _price ;
                var ActualPrice = actualPricePerItem * cart.CartItems.GetValueOrDefault(_SKUId);
                var PriceForNonDiscountedItems = cart.CartItems.GetValueOrDefault(_SKUId) % _qty *
                                                 actualPricePerItem;
                return ActualPrice - (priceForQty + PriceForNonDiscountedItems);
                
            }

            return 0.00;
        }
    }
}