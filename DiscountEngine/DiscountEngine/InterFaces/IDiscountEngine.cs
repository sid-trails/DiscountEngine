using System.Collections.Generic;

namespace DiscountEngine.InterFaces
{
    public interface IDiscountEngine
    {
        void ApplyBestDiscount(IList<IDiscountRule> rules, Cart cart);
    }
}