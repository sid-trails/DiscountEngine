using DiscountEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountEngineTest
{
    [TestClass]
    public class CombinationDiscountRuleTest
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
            cart.AddItem('C','1');
            CombinationDiscountRule testObj = new CombinationDiscountRule('A','C', 40.00d, GetTestInventory());
            Assert.IsTrue(testObj.isApplicableOnCart(cart));

        }
        
        [TestMethod]
        public void ShouldReturnFalseIfACartWithThreeSKUSOFTypePassedIsInCart()
        {
            Cart cart = new Cart(GetTestInventory());
            cart.AddItem('A','5');
            cart.AddItem('D','1');
            CombinationDiscountRule testObj = new CombinationDiscountRule('A','C', 40.00d, GetTestInventory());
            Assert.IsFalse(testObj.isApplicableOnCart(cart));
        }
        
        
        [TestMethod]
        public void ShouldReturnDiscountAmountBasedOnItemsAdded()
        {
            Cart cart = new Cart(GetTestInventory());
            cart.AddItem('A',5);
            cart.AddItem('C',1);
            CombinationDiscountRule testObj = new CombinationDiscountRule('A','C',40.00d, GetTestInventory());
            Assert.AreEqual(25.00d,testObj.CalculateDiscountAmount(cart));
        }
        
        [TestMethod]
        public void ShouldReturnDiscountAmountBasedOnIfMultipleSetsAdded()
        {
            Cart cart = new Cart(GetTestInventory());
            cart.AddItem('A',5);
            cart.AddItem('C',5);
            CombinationDiscountRule testObj = new CombinationDiscountRule('A', 'C', 40.00d,GetTestInventory() );
            Assert.AreEqual(125.00d,testObj.CalculateDiscountAmount(cart));
        }
    }
}