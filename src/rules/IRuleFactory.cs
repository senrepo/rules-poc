using System.Collections;
using System.Collections.Generic;

namespace rules
{
    public interface IRuleFactory 
    {
        List<Rule> Load();
    }
}