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

            /*
            Improvement ideas:
                -	Provide an option  to execute the rules in parallel in addition to sequential processing.
                -	Use the typed approach in the config class such as using typof, nameof.
                -	Option to provide the dependency config in the class itself rather than keeping it in a file.
                -	Add the exception handling in the POC.
                -	Provide an option in a rule object can access the return value of dependent rules results.
                -	Include/Exclude the rule dynamically for ex- rule expiration by date
            */
            foreach (var processor in processors)
            {
                processor.Execute();
            }
        }
    }
}