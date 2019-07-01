using System.Collections.Generic;

namespace rules.Repository
{
    public interface IRepository
    {
       List<StateRateFactor> GetStateRateFactors();  
    } 
}