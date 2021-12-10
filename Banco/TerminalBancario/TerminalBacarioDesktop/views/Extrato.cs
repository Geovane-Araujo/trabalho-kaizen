using BancoCore;
using System;
using System.Windows.Forms;
using BancoCore;

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
            listagemextrato();
        }

        public void listagemextrato()
        {
            LancamentoRepository lr = new LancamentoRepository();


            foreach (Lancamentos la in lr.Extrato(Convert.ToInt32(txt_conta.Text)))
            {
                table_lancamentos.Rows.Add(la.Data, la.Historico, la.Valor, la.Operacao);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys key)
        {
            switch (key)
            {
                case Keys.F5:
                    this.Close();
                    break;
                case Keys.F6:
                    listagemextrato();
                    break;
                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, key);
        }

        private void htmlLabel1_Click(object sender, EventArgs e)
        {
            listagemextrato();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_conta_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
