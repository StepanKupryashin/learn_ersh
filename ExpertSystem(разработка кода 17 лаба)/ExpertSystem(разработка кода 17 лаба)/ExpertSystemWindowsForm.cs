using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExpertSystem_разработка_кода_17_лаба_
{
    public class ExpertSystemWindowsForm : IExpertSystemForm
    {
        public ExpertSystemForm form { get; set; }
        /// <summary>
        /// Заголовок формы
        /// </summary>
        public string Caption
        {
            get
            {
                if (form != null) return form.Text; else return "NULL";
            }
            set
            {
                if (form != null) form.Text = value;
            }
        }
        /// <summary>
        /// Перерисовать утверждения
        /// </summary>
        /// <param name=«propositions»>Списокутверждений</param>
        public void draw_propositions(List<Proposition> propositions)

        {
            form.dgvPropositions.Rows.Clear();
            if (propositions.Count == 0) return;
            form.dgvPropositions.RowCount = propositions.Count;
            int j = 0;
            foreach (Proposition item in propositions)
            {
            redraw_row(j, item);
                   j++;
            }
        }
            /// <summary>
            /// Перерисовать строку
            /// </summary>
            /// <param name=«j»>Номер строки</param>
            /// <param name=«item»>Утверждение</param>
            private void redraw_row(int j, Proposition item)
            {
                if (j >= form.dgvPropositions.RowCount) return;
                if (j == -1) return;
                form.dgvPropositions.Rows[j].Cells[0].Value = item.caption;
                form.dgvPropositions.Rows[j].Cells[1].Value = item.itis;
            }

    }
}
