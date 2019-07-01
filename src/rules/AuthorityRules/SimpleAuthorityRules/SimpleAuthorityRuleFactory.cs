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
           rule.Execute(model,context);
        }

        public ArrayList Load()
        {
            var arrayList = new ArrayList() {
                new SimpleTestAuthorityRule()
            };

            return arrayList;
        }

    }
}