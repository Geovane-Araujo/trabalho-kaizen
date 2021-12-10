using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerminalBacarioDesktop
{
    public partial class Extrato : MetroFramework.Forms.MetroForm
    {
        public Extrato()
        {
            InitializeComponent();
        }

        private void Extrato_Load(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys key)
        {
            switch (key)
            {
                case Keys.F5:
                    this.Close();
                    break;
                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, key);
        }
    }
}
