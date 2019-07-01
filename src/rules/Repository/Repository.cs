using System.Collections.Generic;

namespace rules.Repository
{
    public class Repository : IRepository
    {
        public List<StateRateFactor> GetStateRateFactors()
        {
            return new List<StateRateFactor>() {
                new StateRateFactor {
                    State = "CT",
                    Factor = 1.1
                },
                new StateRateFactor {
                    State = "RI",
                    Factor = 1.2
                }                
            };
        }
    }
}