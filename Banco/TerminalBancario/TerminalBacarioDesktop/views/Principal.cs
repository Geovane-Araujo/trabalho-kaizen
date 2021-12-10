using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TerminalBacarioDesktop.views;

namespace TerminalBacarioDesktop
{
    public partial class form_terminal : MetroFramework.Forms.MetroForm
    {
        public string nome = "";
        public form_terminal()
        {
            InitializeComponent();
        }
        public form_terminal(string nome)
        {
            this.nome = nome;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_nome.Text = "Olá "+nome+" Seja bem Vindo";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys key)
        {
            switch (key)
            {
                case Keys.F5:
                    this.Close();
                    break;
                case Keys.F7:
                    Extrato extrato = new Extrato();
                    extrato.Show();
                    break;
                case Keys.F9:
                    Saques saques = new Saques();
                    saques.Show();
                    break;
                case Keys.F6:
                    Saldos saldos = new Saldos();
                    saldos.Show();
                    break;
                case Keys.F8:
                    Transferencias transferencias = new Transferencias();
                    transferencias.Show();
                    break;
                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, key);
        }

        private void btn_extratos_Click(object sender, EventArgs e)
        {
            Extrato extrato = new Extrato();
            extrato.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Saques saques = new Saques();
            saques.Show();
        }

        private void btn_saldos_Click(object sender, EventArgs e)
        {
            Saldos saldos = new Saldos();
            saldos.Show();
        }

        private void btn_transferencias_Click(object sender, EventArgs e)
        {
            Transferencias transferencias = new Transferencias();
            transferencias.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
