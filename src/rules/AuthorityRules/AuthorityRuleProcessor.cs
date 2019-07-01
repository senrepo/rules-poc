using System;
using System.Collections;
using System.Collections.Generic;
using model;
using Newtonsoft.Json.Linq;

namespace rules.AuthorityRules
{
    public class AuthorityRuleProcessor : IRuleProcessor
    {
        private List<Rule> rules = new List<Rule>();

        private readonly ISimpleAuthorityRuleFactory simpleAuthorityRuleFactory;
        private readonly IDatabaseAuthorityRuleFactory databaseAuthorityRuleFactory;
        private readonly IComplexAuthorityRuleFactory complexAuthorityRuleFactory;
        private readonly IRuleConfig ruleConfig;

        public AuthorityRuleProcessor(IRuleConfig ruleConfig, ISimpleAuthorityRuleFactory simpleAuthorityRuleFactory, IDatabaseAuthorityRuleFactory databaseAuthorityRuleFactory,
        IComplexAuthorityRuleFactory complexAuthorityRuleFactory)
        {
            this.ruleConfig = ruleConfig;
            this.complexAuthorityRuleFactory = complexAuthorityRuleFactory;
            this.simpleAuthorityRuleFactory = simpleAuthorityRuleFactory;
            this.databaseAuthorityRuleFactory = databaseAuthorityRuleFactory;
        }

        public void Execute()
        {
            if (rules.Count == 0)
            {
                Load();
                Sort();
            }

            foreach (var rule in rules)
            {
                if (rule is ISimpleAuthorityRule<int>) simpleAuthorityRuleFactory.ExecuteRule((ISimpleAuthorityRule<int>)rule);
                else if (rule is IDatabaseAuthorityRule<double>) databaseAuthorityRuleFactory.ExecuteRule((IDatabaseAuthorityRule<double>)rule);
                else if (rule is IComplexAuthorityRule<IDiscount>) complexAuthorityRuleFactory.ExecuteRule((IComplexAuthorityRule<IDiscount>)rule);
            }

        }

        public void Load()
        {
            rules.AddRange(simpleAuthorityRuleFactory.Load());
            rules.AddRange(databaseAuthorityRuleFactory.Load());
            rules.AddRange(complexAuthorityRuleFactory.Load());
        }

        public void Sort()
        {
            //TODO: sort the rules based on the Rule Config
        }
    }

}