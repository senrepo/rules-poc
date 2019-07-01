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
            model.SetJson<int>(jsonPath,result);
        }

        //TODO: Discover the type and return type with reflection and after following properties will go away
        public override Type ResultType => typeof(int);

        public override string Category => "SimpleAuthorityRule";

  
    }
}