using model;

namespace rules.AuthorityRules
{
    public class SimpleTestAuthorityRule : ISimpleAuthorityRule<int>
    {
        public int Execute(IModel model, IContext context)
        {
            return 10;
        }

        public void Update(int result, IModel model, IContext context)
        {
            
        }
    }
}