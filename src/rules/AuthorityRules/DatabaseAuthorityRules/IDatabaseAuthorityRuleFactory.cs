using System.Collections.Generic;

namespace rules.AuthorityRules
{
    public interface IDatabaseAuthorityRuleFactory : IRuleFactory
    {
        void ExecuteRule<T>(IDatabaseAuthorityRule<T> rule);
    }
}