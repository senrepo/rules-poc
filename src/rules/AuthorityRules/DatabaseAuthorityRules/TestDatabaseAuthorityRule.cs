using System;
using System.Linq;
using model;
using rules.Repository;

namespace rules.AuthorityRules
{
    public class TestDatabaseAuthorityRule : Rule, IDatabaseAuthorityRule<double>
    {
        private string jsonPath => "$.TestDatabaseAuthorityRule";

        public double Execute(IModel model, IContext context, IRepository repository)
        {
            //return the rate factor by context state
            var rate = repository.GetStateRateFactors().Where(f => f.State == "CT")?.First();
            return rate.Factor;
        }

        /*
            TODO: Move it to base class for common implementation
         */
        public void Update(double result, IModel model, IContext context)
        {
            //update the result to the model
            model.SetJson<double>(jsonPath,result);
        }

        public override string Name => this.GetType().Name;

    }
}