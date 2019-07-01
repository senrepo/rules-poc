
using System.Collections;
using System.Collections.Generic;

namespace rules.AuthorityRules
{
    public interface ISimpleAuthorityRuleFactory : IRuleFactory
    {
        void ExecuteRule<T>(ISimpleAuthorityRule<T> rule);
    }
}