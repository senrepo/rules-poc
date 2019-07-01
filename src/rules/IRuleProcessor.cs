using model;

namespace rules
{
    public interface IRuleProcessor
    {
        void Load();
        void Sort();
        void Execute();
    }
}