using System;
using System.Collections.Generic;
using DiscountEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountEngineTest
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void ShouldAddInveotryItemAndGetPrice()
        {
            Inventory inv = new Inventory();
            inv.AddSKU('A',50.00d);
            Assert.AreEqual(50.00d, inv.GetPrice('A'));
        }

        [TestMethod]
        public void shouldReturnZeroPriceIfSKUNotFound()
        {
            Inventory inv = new Inventory();
            inv.AddSKU('A',50.00d);
            Assert.AreEqual(0.00d, inv.GetPrice('B'));
        }
        
        [TestMethod]
        public void ShouldAddInveotryItemAndReturnIt()
        {
            Inventory inv = new Inventory();
            inv.AddSKU('A',50.00d);
            KeyValuePair<Char, double> sku = inv.GetSKU('A');
            Assert.AreEqual(sku.Value, 50.00d);

        }

        [TestMethod]
        public void ShouldReturnTrueIfInventoryHasKey()
        {
            Inventory inv = new Inventory();
            inv.AddSKU('A',50.00d);
            Assert.AreEqual(true ,inv.HasSKU('A'));
        }

        [TestMethod]
        public void ShouldReturnFalseIfInventoryDoesntHaveKey()
        {
            Inventory inv = new Inventory();
            inv.AddSKU('A',50.00d);
            Assert.AreEqual(false ,inv.HasSKU('B'));
        }

    }
}