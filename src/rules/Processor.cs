using System.Collections.Generic;
using model;
using Newtonsoft.Json.Linq;

namespace rules
{
    public abstract class Processor<T> : IProcessor
    {
        protected abstract JObject GetDependencyConfig();
        protected abstract void ExecuteRules();

        public virtual List<T> Rules {get; set;} = new List<T>();
        protected readonly IModel model;
        protected readonly IContext context;
        protected readonly JObject dependencyConfig;

        public Processor(IModel model, IContext context)
        {
            this.model = model;
            this.context = context;
            this.dependencyConfig = GetDependencyConfig();
        }

        public virtual void Execute()
        {
            LoadRules();
            SortRules();
            ExecuteRules();
        }

        public virtual void LoadRules()
        {
            //load all objects with Marker interface T and add them rules list
        }

        public virtual void SortRules()
        {
            //sort the derivations with dependency json
            
        }
    }
}