using System;
using System.Collections.Generic;
using System.Data;
using DiscountEngine.InterFaces;

namespace DiscountEngine
{
    public class Inventory:IInventory
    {
        private  SortedDictionary<char, double> _inventory = new SortedDictionary<char, double>();
        
        public void AddSKU(char SKUId, double price)
        {
            if (_inventory.ContainsKey(SKUId))
            {
                throw new ConstraintException("Product already exists in inventory");
            }
            _inventory.Add(SKUId, price);
        }

        public KeyValuePair<char, double> GetSKU(char SKUId)
        {
            return new KeyValuePair<char, double>(SKUId, _inventory[SKUId]);
        }

        public double GetPrice(char SKUId)
        {
            if (!_inventory.ContainsKey(SKUId))
            {
                return 0.0;
            }
            return _inventory[SKUId];
        }

        public bool HasSKU(char SKUId)
        {
            if (_inventory.ContainsKey(SKUId))
            {
                return true;
            }
            return false;
        }

    }
}