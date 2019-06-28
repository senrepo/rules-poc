using System.Collections.Generic;
using model;
using Newtonsoft.Json.Linq;

namespace rules
{
    public abstract class Processor<T> : IProcessor
    {
        public abstract JObject GetDependencyConfig();

        protected List<T> rules = new List<T>();
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
            Load();
            Sort();

            
        }

        protected virtual void Load()
        {
            //load all objects with Marker interface T and add them rules list
        }

        protected virtual void Sort()
        {
            //sort the derivations with dependency json
            
        }
    }
}