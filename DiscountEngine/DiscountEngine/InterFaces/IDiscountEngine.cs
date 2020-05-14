using System.Collections.Generic;

namespace DiscountEngine.InterFaces
{
    public interface IDiscountEngine
    {
       double  ApplyBestDiscount(Cart cart);

       double ApplyAllDiscounts(Cart cart);
    }
}