using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiscountEngine;
using Moq;

namespace DiscountEngineTest
{
    [TestClass]
    public class SameSKUFixedPriceRuleTest
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
            SameSKUFixedPriceRule testObj = new SameSKUFixedPriceRule('A',3,130,GetTestInventory());
            Assert.IsTrue(testObj.isApplicableOnCart(cart));

        }
        
        [TestMethod]
        public void ShouldReturnFalseIfACartWithThreeSKUSOFTypePassedIsInCart()
        {
            Cart cart = new Cart(GetTestInventory());
            cart.AddItem('B','5');
            SameSKUFixedPriceRule testObj = new SameSKUFixedPriceRule('A',3,130,GetTestInventory());
            Assert.IsFalse(testObj.isApplicableOnCart(cart));
        }
        
        
        [TestMethod]
        public void ShouldReturnDiscountAmountBasedOnItemsAdded()
        {
            Cart cart = new Cart(GetTestInventory());
            cart.AddItem('A',5);
            SameSKUFixedPriceRule testObj = new SameSKUFixedPriceRule('A',3,130,GetTestInventory());
            Assert.AreEqual(20.00d,testObj.CalculateDiscountAmount(cart));
        }
        
        [TestMethod]
        public void ShouldReturnDiscountAmountBasedOnIfMultipleSetsAdded()
        {
            Cart cart = new Cart(GetTestInventory());
            cart.AddItem('A',10);
            SameSKUFixedPriceRule testObj = new SameSKUFixedPriceRule('A',3,130,GetTestInventory());
            Assert.AreEqual(60.00d,testObj.CalculateDiscountAmount(cart));
        }
    }
}