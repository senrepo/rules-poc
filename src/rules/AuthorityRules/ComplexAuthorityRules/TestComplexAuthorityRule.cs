using System;
using model;
using rules.Repository;

namespace rules.AuthorityRules
{
    public class TestComplexAuthorityRule : Rule, IComplexAuthorityRule<IDiscount>
    {
         private string jsonPath => "$.TestComplexAuthorityRule";
        private readonly IDiscountRuleEvaluator discountRuleEvaluator;

        public TestComplexAuthorityRule(IDiscountRuleEvaluator discountRuleEvaluator)
        {
            this.discountRuleEvaluator = discountRuleEvaluator;
        }

        public IDiscount Execute(IModel model, IContext context, IRepository repository)
        {
            return discountRuleEvaluator.Evaluate(model, context, repository);
        }

        /*
            TODO: Move it to base class for common implementation
         */
        public void Update(IDiscount result, IModel model, IContext context)
        {
            //update the result to model
             model.SetJson<IDiscount>(jsonPath,result);
        }

        public override string Name => this.GetType().Name;

        //TODO: Discover the type and return type with reflection and after following properties will go away
        public override string Category => "ComplexAuthorityRule";

        public override Type ResultType => typeof(IDiscount);
    }
}