using System;

namespace rules
{
    public abstract class Rule
    {
        public abstract string Name {get;}
        public abstract string Category {get; }
        public abstract Type ResultType { get; }
    }
}