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

namespace TerminalBacarioDesktop.views
{
    public partial class Saldos : MetroFramework.Forms.MetroForm
    {
        int idCOnta = 1;
        public Saldos()
        {
            InitializeComponent();
        }

        public Saldos(int id)
        {
            idCOnta = id;
            InitializeComponent();
        }

        private void Saldos_Load(object sender, EventArgs e)
        {
            CorrentistaRepository repo = new CorrentistaRepository();

            Correntista correntista = repo.GetByID(idCOnta);
            decimal limite = 0;
            decimal saldo = 0;

            foreach (Conta co in correntista.Conta)
            {
                saldo += co.Saldo;
                limite += co.LimiteCredito;
            }

            txt_limite.Text = "R$ " + limite.ToString("c2");
            txt_atual.Text = "R$ " + saldo.ToString("c2");

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
