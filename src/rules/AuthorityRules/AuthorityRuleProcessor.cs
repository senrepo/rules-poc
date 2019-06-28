using model;
using Newtonsoft.Json.Linq;

namespace rules.AuthorityRules
{
    public class AuthorityRuleProcessor : Processor<IAuthorityRuleMarker>
    {
        public AuthorityRuleProcessor(IModel model, IContext context) : base(model, context)
        {

        }

        protected override void ExecuteRules()
        {
           foreach(var obj in this.Rules)
           {
               var rule = (IAuthorityRule<object>) obj;
               var extraModel = rule.GetExtraModels(this.model, this.context);
               var result = rule.Execute(this.model, this.context, extraModel);
               rule.UpdateModel(result, this.model, this.context, extraModel);
           }
        }

        protected override JObject GetDependencyConfig()
        {
           //read the dependenchy config from file source or database
           return JObject.Parse("{}");
        }
    }
}