using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmeb2.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o Nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Email!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é invalido!")]
        public string Email{get;set;}
        [Required(ErrorMessage = "Informe o Senha!")]
        public string Senha { get; set; }

        public bool ValidarLogin()
        {

            string sql = $"SELECT IdUsuario,nome FROM usuario WHERE email='{Email}' and senha='{Senha}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    Id = int.Parse(dt.Rows[0]["IdUsuario"].ToString());
                    Nome = dt.Rows[0]["nome"].ToString();
                    return true;
                }

            }

            return false;
        }

        public void RegistrarUsuario()
        {

            string sql = $"INSERT INTO USUARIO (nome, email, senha) VALUES('{Nome}','{Email}','{Senha}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
