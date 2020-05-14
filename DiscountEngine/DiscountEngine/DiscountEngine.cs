using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountEngine.InterFaces;

namespace DiscountEngine
{
    public class DiscountEngine:IDiscountEngine
    {
        private IList<IDiscountRule> _rules;
        
        public DiscountEngine(IList<IDiscountRule> rules)
        {
            _rules = rules;
        }
        public double ApplyBestDiscount( Cart cart)
        {
            var dictionaryValues = GetAllDicounts(cart);
            return dictionaryValues.FirstOrDefault(x => x.Value.Equals(dictionaryValues.Values.Max())).Value;
        }

        private SortedDictionary<string, double> GetAllDicounts(Cart cart)
        {
            var dictionaryValues = new SortedDictionary<string, double>();
            Parallel.ForEach(_rules, (rule) =>
            {
                var discAmount = rule.CalculateDiscountAmount(cart);
                if (discAmount != 0)
                    dictionaryValues.Add(_rules.IndexOf(rule).ToString(), discAmount);
            });
            return dictionaryValues;
        }

        public double ApplyAllDiscounts(Cart cart)
        {
           return GetAllDicounts(cart).Values.Sum();
        }
    }
}