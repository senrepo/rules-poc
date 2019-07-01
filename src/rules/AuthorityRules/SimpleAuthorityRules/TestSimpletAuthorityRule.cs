using System;
using model;

namespace rules.AuthorityRules
{

    public class TestSimpleAuthorityRule : Rule, ISimpleAuthorityRule<int>
    {

        private string jsonPath => "$.TestSimpleAuthorityRule";

        public TestSimpleAuthorityRule()
        {
        }

        public int Execute(IModel model, IContext context)
        {
            return 10;
        }

        /*
            TODO: Move it to base class for common implementation
         */
        public void Update(int result, IModel model, IContext context)
        {
            //update the result to the model
            model.SetJson<int>(jsonPath, result);
        }

        public override string Name => this.GetType().Name;

    }
}