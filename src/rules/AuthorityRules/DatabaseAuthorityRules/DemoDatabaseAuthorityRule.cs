using System;
using System.Linq;
using model;
using rules.Repository;

namespace rules.AuthorityRules
{
    public class DemoDatabaseAuthorityRule : Rule, IDatabaseAuthorityRule<double>
    {
        private string jsonPath => "$.DatabaseAuthorityRule";

        public double Execute(IModel model, IContext context, IRepository repository)
        {
            //rule logic
            var rate = repository.GetStateRateFactors().Where(f => f.State == "CT")?.First();
            return rate.Factor;
        }

        public void Update(double result, IModel model, IContext context)
        {
            //update the result to the model
            model.SetJson<double>(jsonPath,result);
        }

        public override string Name => this.GetType().Name;

    }
}