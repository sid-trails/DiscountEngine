namespace DiscountEngine.InterFaces
{
    public interface IDiscountRule
    {
        bool isApplicableOnCart(Cart cart);
        double CalculateDiscountAmount(Cart cart);
    }
}