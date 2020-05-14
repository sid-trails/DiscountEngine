using System.Collections.Generic;
using DiscountEngine;
using DiscountEngine.InterFaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountEngineTest
{
    
[TestClass]
    public class DiscountEngineTest
    {
        private Inventory GetTestInventory()
        {
            Inventory inv = new Inventory();
            inv.AddSKU('A', 50.00d);
            inv.AddSKU('C', 50.00d);
            inv.AddSKU('D', 15.00d);
            return inv;
        }
        [TestMethod]
        public void ShouldApplyDiscountBasedOnWhichOffersBestValue()
        {
            var Rule1 = new SameSKUFixedPriceRule('A', 3, 130, GetTestInventory());
            var Rule2 = new CombinationDiscountRule('C', 'D', 40.00d, GetTestInventory());
            var engine = new DiscountEngine.DiscountEngine(new List<IDiscountRule>() { Rule1, Rule2});
            var cart = new Cart(GetTestInventory());
            cart.AddItem('A', 10);
            cart.AddItem('C', 1);
          
            Assert.AreEqual(60.00d ,engine.ApplyBestDiscount(cart));
            
        }
        
        [TestMethod]
        public void ShouldApplyDiscountBasedOnWhichOffersBestValueWith2ApplicableRules()
        {
            var Rule1 = new SameSKUFixedPriceRule('A', 3, 130, GetTestInventory());
            var Rule2 = new CombinationDiscountRule('C', 'D', 40.00d, GetTestInventory());
            var engine = new DiscountEngine.DiscountEngine(new List<IDiscountRule>() { Rule1, Rule2});
            var cart = new Cart(GetTestInventory());
            cart.AddItem('A', 10);
            cart.AddItem('C', 5);
            cart.AddItem('D', 5);
           
            Assert.AreEqual(125.00d ,engine.ApplyBestDiscount(cart));
            
        }
    }
}