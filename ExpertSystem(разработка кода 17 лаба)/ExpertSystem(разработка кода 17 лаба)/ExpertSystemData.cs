using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem_разработка_кода_17_лаба_
{
    [Serializable]
    public class ExpertSystemData
    {
        public List<Proposition> propositions;
        public ExpertSystemData()
        {
            propositions = new List<Proposition>();
            
        }
    }

}
