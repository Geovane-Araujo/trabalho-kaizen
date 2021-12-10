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

namespace TerminalBacarioDesktop.views
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void htmlLabel1_Click(object sender, EventArgs e)
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
                case Keys.F1:
                    form_terminal principal = new form_terminal("Edna");
                    principal.Show();
                    break;
                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, key);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            form_terminal principal = new form_terminal("Edna");
            principal.Show();
        }
    }
}
