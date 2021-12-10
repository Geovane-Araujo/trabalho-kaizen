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
            LancamentoRepository repo = new LancamentoRepository();

            Lancamentos lancamentos = new Lancamentos();


            Conta conta = new Conta();
            conta = repo.GetByID(Convert.ToInt32(txt_numeroConta.Text));

            
            decimal valor = Convert.ToDecimal(txt_valor.Text);

            if(valor < conta.Saldo)
            {
                conta.Saldo -= valor;
            }
            else if(valor > conta.Saldo && valor < conta.LimiteCredito)
            {
                decimal aux = 0;
                aux = (valor - conta.Saldo);
                conta.Saldo = 0;
                conta.LimiteCredito -= aux;
            } else
            {
                MessageBox.Show("Saldo Insulficiente");
                return;
            }


            lancamentos.Data = DateTime.Now;
            lancamentos.Valor = valor;
            lancamentos.Operacao = 1;
            lancamentos.Historico = " Saque no Auto atendimento dia " + DateTime.Now.ToString("dd/MM/yyyy");

            conta.Lancamentos.Add(lancamentos);

            repo.Saque(conta);

        }
    }
}
