using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmeb2.Models
{
    public class FuncionarioModel
    {
        public int idFunc { get; set; }

        [Required(ErrorMessage = "Informe o Nome da Pessoa!")]
        public string Nome { get; set; }


        public string Ip { get; set; }

        [Required(ErrorMessage = "Informe o Email!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é invalido!")]
        public string Email { get; set; }

        public string Mac { get; set; }

        public string Ramal { get; set; }

        public string Setor { get; set; }
        public string Andar { get; set; }

        public FuncionarioModel()
        {

        }

        public List<FuncionarioModel> ListaFuncionario()
        {
            List<FuncionarioModel> lista = new List<FuncionarioModel>();
            FuncionarioModel item;

            //string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"select * from Funcionario";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new FuncionarioModel();

                item.idFunc = int.Parse(dt.Rows[i]["idFunc"].ToString());
                item.Nome = dt.Rows[i]["nome"].ToString();
                item.Ip = dt.Rows[i]["ip"].ToString();
                item.Mac = dt.Rows[i]["mac"].ToString();
                item.Email = dt.Rows[i]["email"].ToString();
                item.Ramal = dt.Rows[i]["ramal"].ToString();
                item.Setor = dt.Rows[i]["setor"].ToString();
                item.Andar = dt.Rows[i]["andar"].ToString();
                lista.Add(item);
            }
            return lista;

        }

        public void CriarFuncionario()

        {
            string sql = "";

            if (idFunc == 0)
            {
                sql = $"INSERT INTO funcionario(nome, ip, mac, email, ramal, setor, andar) values('{Nome}','{Ip}','{Mac}','{Email}','{Ramal}','{Setor}','{Andar}')";

            }
            else
            {
                sql = $"UPDATE funcionario SET nome ='{Nome}', ip ='{Ip}', mac ='{Mac}', email ='{Email}', ramal ='{Ramal}', setor ='{Setor}', andar='{Andar}' WHERE idFunc = '{idFunc}'";

            }
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir(int id_funcionario)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM funcionario WHERE idFunc = " + id_funcionario);
        }

        public FuncionarioModel CarregarRegistro(int? id_funcionario)
        {
            FuncionarioModel item = new FuncionarioModel();

            string sql = $"SELECT idFunc, nome, ip, mac, email, ramal, setor, andar from funcionario Where idFunc = {id_funcionario}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);


            item.idFunc = int.Parse(dt.Rows[0]["idFunc"].ToString());
            item.Nome = dt.Rows[0]["nome"].ToString();
            item.Ip = dt.Rows[0]["ip"].ToString();
            item.Mac = dt.Rows[0]["mac"].ToString();
            item.Email = dt.Rows[0]["email"].ToString();
            item.Ramal = dt.Rows[0]["ramal"].ToString();
            item.Setor = dt.Rows[0]["setor"].ToString();
            item.Andar = dt.Rows[0]["andar"].ToString();

            return item;
        }

    }
}