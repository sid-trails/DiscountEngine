using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiscountEngine;

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
          // Cart cart = new Cart(GetTestInventory());

        }
        
    }
}