using model;
using rules.Repository;

namespace rules.AuthorityRules
{
    public interface IDiscountRuleEvaluator
    {
        IDiscount Evaluate(IModel mode, IContext context, IRepository respository);
    }

    public class DiscountRuleEvaluator : IDiscountRuleEvaluator
    {
        public IDiscount Evaluate(IModel mode, IContext context, IRepository respository)
        {
            //Add the all rules evaluation logic
            return new Discount() { Name = "PaidInFull" };
        }
    }
}