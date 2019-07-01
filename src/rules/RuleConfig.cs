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
            var list = new List<RuleConfig> {
                new RuleConfig() { Name = "TestDatabaseAuthorityRule", DependentRule = "TestSimpleAuthorityRule" },
                new RuleConfig() { Name = "TestComplexAuthorityRule", DependentRule = "TestDatabaseAuthorityRule" },
            };

            return list;
        }
    }
}