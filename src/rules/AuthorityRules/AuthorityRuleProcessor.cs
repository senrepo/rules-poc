using System.Collections;
using System.Collections.Generic;
using model;
using Newtonsoft.Json.Linq;

namespace rules.AuthorityRules
{
    public class AuthorityRuleProcessor : IRuleProcessor
    {
        private  Dictionary<string, ArrayList> rulesDictionary = new Dictionary<string, ArrayList>();

       // private List<?> rules = new List<?>();

        private readonly ISimpleAuthorityRuleFactory simpleAuthorityRuleFactory;

        public AuthorityRuleProcessor(ISimpleAuthorityRuleFactory simpleAuthorityRuleFactory)
        {
            this.simpleAuthorityRuleFactory = simpleAuthorityRuleFactory;
          
        }

        public void Execute()
        {
            if (rulesDictionary.Values.Count == 0 ) 
            {
                Load();
                Sort();
            }

            foreach (var key in rulesDictionary.Keys)
            {
                foreach (var rule in rulesDictionary[key])
                {
                    switch (key)
                    {
                        case "SimpleRules":
                            simpleAuthorityRuleFactory.ExecuteRule(new SimpleTestAuthorityRule());
                            break;
                    }
                }
            }
        }

        public void Load()
        {
            rulesDictionary.Add("SimpleRules", simpleAuthorityRuleFactory.Load());
        }

        public void Sort()
        {
           
        }
    }

}