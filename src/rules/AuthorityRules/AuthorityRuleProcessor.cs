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

        public AuthorityRuleProcessor(ISimpleAuthorityRuleFactory simpleAuthorityRuleFactory, IDatabaseAuthorityRuleFactory databaseAuthorityRuleFactory,
        IComplexAuthorityRuleFactory complexAuthorityRuleFactory)
        {
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

            //TODO: use the reflection to discover the category and result type automatically
            //TODO: strip off the namespace and use the class type in the switch statements

            foreach (var rule in rules)
            {
                if (rule.Category == "SimpleAuthorityRule")
                {
                    switch (rule.ResultType.ToString())
                    {
                        case "System.Int32":
                            simpleAuthorityRuleFactory.ExecuteRule((ISimpleAuthorityRule<int>)rule);
                            break;
                    }
                    continue;
                }

                if (rule.Category == "DatabaseAuthorityRule")
                {
                    switch (rule.ResultType.ToString())
                    {
                        case "System.Double":
                            databaseAuthorityRuleFactory.ExecuteRule((IDatabaseAuthorityRule<double>)rule);
                            break;
                    }
                    continue;
                }

                if (rule.Category == "ComplexAuthorityRule")
                {
                    switch (rule.ResultType.ToString())
                    {
                        case "model.IDiscount":
                            complexAuthorityRuleFactory.ExecuteRule((IComplexAuthorityRule<IDiscount>)rule);
                            break;
                    }
                    continue;
                }                
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

        }
    }

}