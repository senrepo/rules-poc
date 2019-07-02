using System.Collections.Generic;
using model;
using rules.Repository;

namespace rules.AuthorityRules
{
    public class DatabaseAuthorityRuleFactory : IDatabaseAuthorityRuleFactory
    {
        private readonly IModel model;
        private readonly IContext context;
        private readonly IRepository repository;

        public DatabaseAuthorityRuleFactory(IModel model, IContext context, IRepository repository)
        {
            this.repository = repository;
            this.context = context;
            this.model = model;
        }


        public void ExecuteRule<T>(IDatabaseAuthorityRule<T> rule)
        {
            var result = rule.Execute(model, context, repository);
            rule.Update(result, model, context);
        }

        public List<Rule> Load()
        {
            var list = new List<Rule>() {
                 new DemoDatabaseAuthorityRule()
            };

            return list;
        }
    }
}