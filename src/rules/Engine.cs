using System.Collections.Generic;

namespace rules
{
    public class RuleEngine : IRuleEngine
    {
        private readonly List<IRuleProcessor> processors;

        public RuleEngine(List<IRuleProcessor> processors)
        {
            this.processors = processors;
        }

        public void Run()
        {
            foreach(var processor in processors)
            {
                 processor.Execute();
            }
        }
    }
}