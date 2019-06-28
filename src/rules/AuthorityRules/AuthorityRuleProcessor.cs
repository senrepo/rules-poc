using model;
using Newtonsoft.Json.Linq;

namespace rules.AuthorityRules
{
    public class AuthorityRuleProcessor : Processor<IAuthorityRule>
    {
        public AuthorityRuleProcessor(IModel model, IContext context) : base(model, context)
        {

        }

        public override JObject GetDependencyConfig()
        {
           //read the dependenchy config from file source or database
           return JObject.Parse("{}");
        }
    }
}