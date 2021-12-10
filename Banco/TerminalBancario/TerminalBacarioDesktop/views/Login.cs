using BancoCore;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
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
            CorrentistaRepository repo = new CorrentistaRepository();

            List<Correntista> correntistas = repo.GetAll();
            if(correntistas.Count == 0)
            {
                Hashtable hash = new Hashtable();

                hash.Add("Geovane Araújo", "11111111111");
                hash.Add("Reinaldo", "22222222222");

                foreach (DictionaryEntry en in hash)
                {
                    repo.InsereCorrentista(en.Value.ToString(), en.Key.ToString());
                }
            }
            

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
            CorrentistaRepository repo = new CorrentistaRepository();

            List<Correntista> correntistas = repo.GetAll();
            Correntista conta = new Correntista();

            bool contem = false;
            correntistas.ForEach(delegate (Correntista co)
            {
                if (co.CPF.Replace(" ","").Equals(txt_cpf.Text))
                {
                    conta = co;
                    contem = true;
                }
            });
            if (conta.CPF != null)
            {
                form_terminal principal = new form_terminal(conta);
                principal.Show();
            }
            else
            {
                MessageBox.Show("Cpf ou senha incálidos");
            }
            
        }
    }
}
