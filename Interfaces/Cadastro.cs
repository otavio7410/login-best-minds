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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "mbcZVssNaYMqZyV9zsZUHLkObKDOecTWEW0pWgYl",
            BasePath = "https://teste-programa-best-minds-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void Cadastro_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fcon);
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao conectar com o Firebase" + error, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtSenha.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtCPF.Text) ||
                string.IsNullOrEmpty(txtEndereco.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
            }
            else
            {
                Usuario usuario = new Usuario()
                {
                    NomeCompleto = txtNome.Text,
                    Email = txtEmail.Text,
                    Senha = txtSenha.Text,
                    CPF = txtCPF.Text,
                    Endereco = txtEndereco.Text
                };

                var setter = client.Set("Usuario/" + txtEmail.Text, usuario);
                MessageBox.Show("O usuário foi cadastrado com sucesso");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
