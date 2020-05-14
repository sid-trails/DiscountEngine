using System.Collections.Generic;

namespace DiscountEngine.InterFaces
{
    public interface IDiscountEngine
    {
        double ApplyBestDiscount(IList<IDiscountRule> Rules,Cart cart);
    }
}