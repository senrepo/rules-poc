using System.Collections.Generic;
using model;

namespace rules.AuthorityRules
{
    public interface IAuthorityRule<out T> where T : class
    {
        T Execute(IModel model, IContext context, IDictionary<string, object> extraModels);
        IDictionary<string, object> GetExtraModels(IModel model, IContext context);
        void UpdateModel(object result, IModel model, IContext context, IDictionary<string, object> extraModels);
    }
}