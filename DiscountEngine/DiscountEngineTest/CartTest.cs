using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiscountEngine;

namespace DiscountEngineTest
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void shouldAddItemToCartOnlyWhenInventoryIsAvailable()
        {
            Inventory inv = new Inventory();
            inv.AddSKU('A',50.00d);
            inv.AddSKU('B',15.00d);
            Cart cart = new Cart(inv);
            cart.AddItem('A',10);
        }
    }
}