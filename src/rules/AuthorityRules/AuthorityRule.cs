using System.Collections.Generic;
using model;

namespace rules.AuthorityRules
{
    public class AuthorityRule<T>  where T : class,  IAuthorityRule<T> 
    {
       // public abstract T Execute(IModel model, IContext context, IDictionary<string, object> extraModels);

        public virtual T Execute(IModel model, IContext context, IDictionary<string, object> extraModels)
        {
            return null;
        }


        public virtual IDictionary<string, object> GetExtraModels(IModel model, IContext context)
        {
            //return the extra models if needed
            return null;
        }

        public virtual void UpdateModel(T result, IModel model, IContext context, IDictionary<string, object> extraModels)
        {
           //base implementation to update  the model
        }
    }
}