using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace login_best_minds
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "mbcZVssNaYMqZyV9zsZUHLkObKDOecTWEW0pWgYl",
            BasePath = "https://teste-programa-best-minds-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
            }

            else
            {
                FirebaseResponse res = client.Get("Usuario/" + txtEmail.Text);
                Usuario ResUser = res.ResultAs<Usuario>(); //resultado da query

                Usuario CurUser = new Usuario()
                {
                    Email = txtEmail.Text,
                    Senha = txtSenha.Text
                };

                if (Usuario.IsEqual(ResUser, CurUser))
                {
                    OpenChildForm(new Menu());
                    MessageBox.Show("Parabén! Você foi logado com sucesso");
                }

                else
                {
                    Usuario.MostrarErro();
                }

            }
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Cadastro());
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fcon);
            }

            catch
            {
                MessageBox.Show("Sem conexão com a internet ou problema de conexão.");
            }
        }
    }
}
