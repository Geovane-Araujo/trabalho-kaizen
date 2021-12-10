using BancoCore;
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
        Correntista correntista = new Correntista();
        public Extrato()
        {
            InitializeComponent();
        }

        public Extrato(Correntista correntista)
        {
            this.correntista = correntista;
            InitializeComponent();

        }

        private void Extrato_Load(object sender, EventArgs e)
        {

            foreach(Conta co in correntista.Conta)
            {
                foreach(Lancamentos la in co.Lancamentos)
                {
                    table_lancamentos.Rows.Add(la.Data,la.Historico,la.Valor,la.Operacao);
                }
            }
            
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

        private void htmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
