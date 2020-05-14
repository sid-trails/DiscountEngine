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
            Mock ruleEngine = new Mock<IDiscountEngine>();
            Mock rules = new Mock<IList<IDiscountRule>>();
            inv.AddSKU('A',50.00d);
            Cart cart = new Cart(inv, (IDiscountEngine)ruleEngine.Object, (IList<IDiscountRule>)rules.Object);
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
            Mock ruleEngine = new Mock<IDiscountEngine>();
            Mock rules = new Mock<IList<IDiscountRule>>();
            Cart cart = new Cart(inv, (IDiscountEngine)ruleEngine.Object, (IList<IDiscountRule>)rules.Object);
            cart.AddItem('A',10);
            cart.AddItem('B',2);
            Assert.AreEqual(cart.CartValue, 530.00d);
        }
        
        [TestMethod]
        public void shouldAddItemToCartFinaleBasedOnPrices()
        {
            Inventory inv = new Inventory();
            inv.AddSKU('A',50.00d);
            inv.AddSKU('B',15.00d);
            var ruleEngine = new Mock<IDiscountEngine>(MockBehavior.Loose);
            var rules = new Mock<IList<IDiscountRule>>(MockBehavior.Loose);
            ruleEngine.Setup(x => x.ApplyBestDiscount(It.IsAny<IList<IDiscountRule>>(), 
                    It.IsAny<Cart>())).Returns(50.00d);
            Cart cart = new Cart(inv, (IDiscountEngine)ruleEngine.Object, (IList<IDiscountRule>)rules.Object);
            
            Assert.AreEqual(cart.CostToConsumer, 50.00d);
        }
    }
}