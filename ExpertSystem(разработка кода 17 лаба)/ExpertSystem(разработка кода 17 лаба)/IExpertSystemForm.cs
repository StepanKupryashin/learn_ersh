using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem_разработка_кода_17_лаба_
{
    internal interface IExpertSystemForm
    {
        /// <summary>
        /// Заголовок формы
        /// </summary>
        string Caption { get; set; }
        /// <summary>
        /// Перерисовать утверждения
        /// </summary>
        /// <param name=«propositions»>Список утверждений</param>
 void draw_propositions(List<Proposition> propositions);
    }
}
