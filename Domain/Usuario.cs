using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_best_minds
{
    class Usuario
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }

        public static string error = "Usuário ou senha não existem ou estão incorretos ";

        public static void MostrarErro()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }
        public static bool IsEqual(Usuario user1, Usuario user2)
        {
            if(user1==null || user2 == null) { return false ;}

            if (user1.Email != user2.Email)
            {
                error = "Email não existe!";
                return false;
            }

            else if (user1.Senha != user2.Senha)
            {
                error = "Senha não existe";
                return false;
            }

            return true;
        }
    }
}
