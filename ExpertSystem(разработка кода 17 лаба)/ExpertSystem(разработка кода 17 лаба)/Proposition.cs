using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem_разработка_кода_17_лаба_
{
    /// <summary>
    /// Утверждение. Например «Это летает»,
    /// »Это ползает», «Имеет хвост», «Имеет перья»
    /// </summary>
    [Serializable]
    public class Proposition
    {
        /// <summary>
        /// Текст утверждения
        /// </summary>
        public string caption;
        /// <summary>
        /// Имеет ли место данное утверждение
        /// </summary>
        public bool itis;
    }
}
