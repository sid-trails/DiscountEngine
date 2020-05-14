using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiscountEngine;
using Moq;

namespace DiscountEngineTest
{
    [TestClass]
    public class ThreeSKUDiscountRule
    {
        private Inventory GetTestInventory()
        {
            Inventory inv = new Inventory();
            inv.AddSKU('A',50.00d);
            inv.AddSKU('C',15.00d);
            inv.AddSKU('D',11.00d);
            return inv;
        }
        
        [TestMethod]
        public void ShouldReturnTrueIfACartWithThreeSKUSOFTypePassedIsInCart()
        { 
            
            Cart cart = new Cart(GetTestInventory());
            cart.AddItem('A','5');
            ThreeSkuDiscountRule testObj = new ThreeSkuDiscountRule('A');
            Assert.IsTrue(testObj.isApplicableOnCart(cart));

        }
        
        [TestMethod]
        public void ShouldReturnFalseIfACartWithThreeSKUSOFTypePassedIsInCart()
        {
            Cart cart = new Cart(GetTestInventory());
            cart.AddItem('B','5');
            ThreeSkuDiscountRule testObj = new ThreeSkuDiscountRule('A');
            Assert.IsFalse(testObj.isApplicableOnCart(cart));
        }
        
    }
}