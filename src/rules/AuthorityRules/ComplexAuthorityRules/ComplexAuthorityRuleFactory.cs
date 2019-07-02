using System.Collections.Generic;
using model;
using rules.Repository;

namespace rules.AuthorityRules
{
    public class ComplexAuthorityRuleFactory : IComplexAuthorityRuleFactory
    {
        private readonly IModel model;
        private readonly IContext context;
        private readonly IRepository repository;

        private IDiscountRuleEvaluator discountRuleEvaluator = new DiscountRuleEvaluator();

        public ComplexAuthorityRuleFactory(IModel model, IContext context, IRepository repository)
        {
            this.repository = repository;
            this.context = context;
            this.model = model;
        }

        public void ExecuteRule<T>(IComplexAuthorityRule<T> rule)
        {
            var result = rule.Execute(model, context, repository);
            rule.Update(result, model, context);
        }

        public List<Rule> Load()
        {
            var list = new List<Rule>()
            {
                new DemoComplexAuthorityRule(discountRuleEvaluator)
            };

            return list;
        }
    }
}