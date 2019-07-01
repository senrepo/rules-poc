using model;
using rules.Repository;

namespace rules.AuthorityRules
{
    public interface IDatabaseAuthorityRule<T>
    {
        T Execute(IModel model, IContext context, IRepository repository);
        void Update(T result, IModel model, IContext context);
    }
}