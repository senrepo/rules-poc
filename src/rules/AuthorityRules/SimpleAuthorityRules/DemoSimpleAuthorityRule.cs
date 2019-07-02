using System;
using model;

namespace rules.AuthorityRules
{

    public class DemoSimpleAuthorityRule : Rule, ISimpleAuthorityRule<int>
    {

        private string jsonPath => "$.SimpleAuthorityRule";

        public DemoSimpleAuthorityRule()
        {
        }

        public int Execute(IModel model, IContext context)
        {
            //Rules logic
            return 10;
        }

        public void Update(int result, IModel model, IContext context)
        {
            //update the result to the model
            model.SetJson<int>(jsonPath, result);
        }

        public override string Name => this.GetType().Name;

    }
}