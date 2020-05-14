using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Moq;
using DiscountEngine;
using DiscountEngine.InterFaces;

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
            Cart cart = new Cart(inv);
            cart.AddItem('A',10);
            cart.AddItem('B',2);
            Assert.IsTrue(cart.CartItems.ContainsKey('A'));
            Assert.IsFalse(cart.CartItems.ContainsKey('B'));
        }
        
        [TestMethod]
        public void shouldAddItemToCartValueBasedOnPrices()
        {
            Inventory inv = new Inventory();
            inv.AddSKU('A',50.00d);
            inv.AddSKU('B',15.00d);
            Cart cart = new Cart(inv);
            cart.AddItem('A',10);
            cart.AddItem('B',2);
            Assert.AreEqual(cart.CartValue, 530.00d);
        }
        
    }
}