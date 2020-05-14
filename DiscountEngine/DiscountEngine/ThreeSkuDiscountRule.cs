using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public double CalculateDiscountAmount(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}