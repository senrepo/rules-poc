using System.Collections.Generic;

namespace rules
{
    public class Engine : IEngine
    {
        private readonly List<IProcessor> processors;

        public Engine(List<IProcessor> processors)
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