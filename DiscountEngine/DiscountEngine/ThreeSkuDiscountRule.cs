using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using DiscountEngine.InterFaces;

namespace DiscountEngine
{
    public class ThreeSkuDiscountRule:IDiscountRule
    {

        private char _skuId;

        public ThreeSkuDiscountRule(char skuId)
        {
            _skuId = skuId;
        }
        public bool isApplicableOnCart(Cart cart)
        {
            return cart.CartItems.ContainsKey(_skuId) && cart.CartItems.GetValueOrDefault(_skuId) >= 3;
        }

        public double CalculateDiscountAmount(Cart cart)
        {
            int noOfItems = cart.CartItems.GetValueOrDefault(_skuId);
            if (isApplicableOnCart(cart))
            {
                return (noOfItems / 3) * 20;
                
            }

            return 0.00;
        }
    }
}