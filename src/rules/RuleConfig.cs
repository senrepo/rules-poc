using System.Collections.Generic;

namespace rules
{
    public interface IRuleConfig
    {
        string Name { get; set; }
        string DependentRule { get; set; }
    }

    public class RuleConfig : IRuleConfig
    {
        public string Name { get; set; }
        public string DependentRule { get; set; }

        public static List<RuleConfig> GetAll()
        {
            //TODO: use the typof or nameof for more typesafe
            var list = new List<RuleConfig> {
                new RuleConfig() { Name = "DemoDatabaseAuthorityRule", DependentRule = "DemoSimpleAuthorityRule" },
                new RuleConfig() { Name = "DemoComplexAuthorityRule", DependentRule = "DemoDatabaseAuthorityRule" },
            };

            return list;
        }
    }
}