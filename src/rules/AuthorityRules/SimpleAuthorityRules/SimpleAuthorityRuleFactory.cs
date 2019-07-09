using System.Collections;
using System.Collections.Generic;
using model;

namespace rules.AuthorityRules
{
    public class SimpleAuthorityRuleFactory : ISimpleAuthorityRuleFactory
    {
        private readonly IModel model;
        private readonly IContext context;

        public SimpleAuthorityRuleFactory(IModel model, IContext context)
        {
            this.model = model;
            this.context = context;
        }

        public void ExecuteRule<T>(ISimpleAuthorityRule<T> rule)
        {
           var result = rule.Execute(model,context);
           rule.Update(result, model, context);
        }

        public List<Rule> Load()
        {
            //TODO: Alternatively use the Reflection to load dynamically
            var list = new List<Rule>() {
                 new DemoSimpleAuthorityRule()
            };

            return list;
        }

    }
}