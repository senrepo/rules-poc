using model;

namespace rules.AuthorityRules
{
    public interface ISimpleAuthorityRule <T>
    {
        T Execute (IModel model, IContext context);
        void Update(T result, IModel model, IContext context);
    }
}