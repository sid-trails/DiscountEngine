using System;
using System.Collections.Generic;
using DiscountEngine.InterFaces;

namespace DiscountEngine
{
    public class ThreeSkuDiscountRule:IDiscountRule
    {
        
        public bool isApplicableOnCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public double CalculateDiscountAmount(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}