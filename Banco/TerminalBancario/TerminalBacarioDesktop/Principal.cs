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

namespace TerminalBacarioDesktop
{
    public partial class form_terminal : MetroFramework.Forms.MetroForm
    {
        public form_terminal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
                    String senha = Interaction.InputBox("Informe a senha para fechar a aplicação!", "Terminal Bancário");
                    if (senha.Equals("123"))
                    {
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Senha Inválida");
                    }
                    break;
                case Keys.F7:
                    Extrato extrato = new Extrato();
                    extrato.Show();
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
    }
}
