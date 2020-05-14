using System.Collections.Generic;

namespace DiscountEngine.InterFaces
{
    public interface IInventory
    {
        void AddSKU(char SKUId, double price);
        KeyValuePair<char, double> GetSKU(char SKUId);
        double GetPrice(char SKUId);
        bool HasSKU(char SKUId);
    }
}