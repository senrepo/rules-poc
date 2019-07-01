using System.Collections.Generic;

namespace rules.AuthorityRules
{
    public interface IComplexAuthorityRuleFactory : IRuleFactory
    {
        void ExecuteRule<T>(IComplexAuthorityRule<T> rule);         
    }
}