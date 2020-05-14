using System;
using System.Collections.Immutable;
using System.Net.Http.Headers;
using DiscountEngine.InterFaces;

namespace DiscountEngine
{
    public class CombinationDiscountRule:IDiscountRule
    {
        private char _SKUId1;
        private char _SKUId2;
        private IInventory _inventory;
        private double _price;
        public CombinationDiscountRule(char SKUId1, char SKUId2, double price, IInventory inventory)
        {
            _SKUId1 = SKUId1;
            _SKUId2 = SKUId2;
            _price = price;
            _inventory = inventory;
        }
        public bool isApplicableOnCart(Cart cart)
        {
            return _SKUId1 == _SKUId2 ? cart.CartItems.ContainsKey(_SKUId1) && cart.CartItems.GetValueOrDefault(_SKUId1) >2 :
                cart.CartItems.ContainsKey(_SKUId1) && cart.CartItems.ContainsKey(_SKUId2) ;
        }

        public double CalculateDiscountAmount(Cart cart)
        {
            if (isApplicableOnCart(cart))
            {
                double discountPerCombination =
                    _inventory.GetPrice(_SKUId1) + _inventory.GetPrice(_SKUId2) - _price;
                int noOfItems = cart.CartItems.GetValueOrDefault(_SKUId1);
                int noOFItems2 = cart.CartItems.GetValueOrDefault(_SKUId2);
                return Math.Min(noOfItems, noOFItems2) * discountPerCombination;

            }

            return 0.00d;
        }
    }
}