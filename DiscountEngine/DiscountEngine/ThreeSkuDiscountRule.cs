using System;
using System.Collections.Generic;
using DiscountEngine.InterFaces;

namespace DiscountEngine
{
    public class ThreeSkuDiscountRule:IDiscountRule
    {
        
        public bool isApplicableOnCart(Cart cart)
        {
            return cart.CartItems.GetValueOrDefault('A') == 3;
        }

        public double CalculateDiscountAmount(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}