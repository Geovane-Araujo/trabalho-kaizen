using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BancoCore;

namespace TerminalBacarioDesktop.views
{
    public partial class Transferencias : MetroFramework.Forms.MetroForm
    {
        private readonly LancamentoRepository _repo;
        public Transferencias()
        {
            InitializeComponent();
            _repo = new LancamentoRepository();
        }

        private void Transferencias_Load(object sender, EventArgs e)
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
            try
            {
                var retorno = _repo.EfetuaTransferencia(int.Parse(contaOrigemTxt.Text), int.Parse(contaDestinoTxt.Text),
                    decimal.Parse(valorDestinoTxt.Text));

                MessageBox.Show(retorno);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
