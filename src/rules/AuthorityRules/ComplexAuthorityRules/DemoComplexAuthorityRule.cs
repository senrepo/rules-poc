using System;
using model;
using rules.Repository;

namespace rules.AuthorityRules
{
    public class DemoComplexAuthorityRule : Rule, IComplexAuthorityRule<IDiscount>
    {
        private string jsonPath => "$.ComplexAuthorityRule";
        private readonly IDiscountRuleEvaluator discountRuleEvaluator;

        public DemoComplexAuthorityRule(IDiscountRuleEvaluator discountRuleEvaluator)
        {
            this.discountRuleEvaluator = discountRuleEvaluator;
        }

        public IDiscount Execute(IModel model, IContext context, IRepository repository)
        {
            //rule logic
            return discountRuleEvaluator.Evaluate(model, context, repository);
        }

        public void Update(IDiscount result, IModel model, IContext context)
        {
            //update the result to model
            model.SetJson<IDiscount>(jsonPath, result);
        }

        public override string Name => this.GetType().Name;
    }
}