using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerminalBacarioDesktop.views
{
    public partial class Saldos : MetroFramework.Forms.MetroForm
    {
        public Saldos()
        {
            InitializeComponent();
        }

        private void Saldos_Load(object sender, EventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys key)
        {
            switch (key)
            {
                case Keys.F5:
                    this.Close();
                    break;
                case Keys.F1:
                    break;
                case Keys.F2:
                    Transferencias transferencias = new Transferencias();
                    transferencias.Show();
                    break;
                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, key);
        }

        private void htmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
