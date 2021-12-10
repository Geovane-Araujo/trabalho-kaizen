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
    public partial class Saques : MetroFramework.Forms.MetroForm
    {
        int idcorrentista = 0;
        public Saques()
        {
            InitializeComponent();
        }

        public Saques(int id)
        {
            idcorrentista = id;
            InitializeComponent();
        }
        private void Saques_Load(object sender, EventArgs e)
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

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            ContaRepository contaRepo = new ContaRepository();

            MessageBox.Show(contaRepo.Saque(int.Parse(txt_numeroConta.Text), decimal.Parse(txt_valor.Text)));

        }
    }
}
