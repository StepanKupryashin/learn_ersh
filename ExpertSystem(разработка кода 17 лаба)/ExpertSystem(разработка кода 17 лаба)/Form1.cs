using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpertSystem_разработка_кода_17_лаба_
{
    public partial class ExpertSystemForm : Form
    {
       
            /// <summary>
            /// Ядро экспертной системы
            /// </summary>
            private ExpertSystemCore core;


        public ExpertSystemForm()
            {
                InitializeComponent();
                core = new ExpertSystemCore(this);
            }
            private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                core.Save();
            }
            
            

        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            core.Open();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            core.SaveAs();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            core.AddProposition();
        }
    }
}
