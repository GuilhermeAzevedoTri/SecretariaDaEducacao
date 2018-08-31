using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace ProjetoEmeb2.Models
{
    public class ContaModel
    {
        public int idGasto { get; set; }

        [Required(ErrorMessage = "Informe o Tipo da Conta!")]
        public string tipo { set; get; }

        [Required(ErrorMessage = "Selecione a Data!")]
        public string data { get; set; }


        private string valor;
        [Required(ErrorMessage = "Informe o Valor da Conta!")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Selecione a Descrição!")]
        public string descricao { get; set; }

        public int Escola_idEscola { get; set; }

        public string Escola_Nome { get; set;}
        public string nome { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public ContaModel()
        {

        }
              
        public ContaModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<ContaModel> ListaConta()
        {
            List<ContaModel> lista = new List<ContaModel>();
            ContaModel item;

            string sql = $"select e.nome as escola, g.* from escola e inner join gastos g on g.escola_idEscola = e.idEscola";




            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i=0; i<dt.Rows.Count; i++)
            {

                item = new ContaModel();
                item.idGasto = int.Parse(dt.Rows[i]["idGastos"].ToString());
                item.data = DateTime.Parse(dt.Rows[i]["data"].ToString()).ToString("dd/MM/yyyy");
                item.tipo = dt.Rows[i]["tipo"].ToString();
                item.Valor = double.Parse(dt.Rows[i]["valor"].ToString());
                item.descricao = dt.Rows[i]["descricao"].ToString();
                item.Escola_idEscola = int.Parse(dt.Rows[i]["escola_idEscola"].ToString());
                item.nome = dt.Rows[i]["escola"].ToString();
               

                lista.Add(item);


            }
            return lista;
        }

        public ContaModel CarregarRegistro(int? id_gastos)
        {
            ContaModel item = new ContaModel();

            string sql = $"select e.nome as escola, g.* from escola e inner join gastos g on g.escola_idEscola = e.idEscola Where g.idGastos = {id_gastos}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            item.idGasto = int.Parse(dt.Rows[0]["idGastos"].ToString());
            item.data = DateTime.Parse(dt.Rows[0]["data"].ToString()).ToString("dd/MM/yyyy");
            item.tipo = dt.Rows[0]["tipo"].ToString();
            item.Valor = double.Parse(dt.Rows[0]["valor"].ToString());
            item.descricao = dt.Rows[0]["descricao"].ToString();
            item.Escola_idEscola = int.Parse(dt.Rows[0]["escola_idEscola"].ToString());
            item.nome = dt.Rows[0]["escola"].ToString();


            return item;
        }

        
        public void Insert()
        {
          
            string sql = "";
            ConverterValor();

            if (idGasto == 0)
            {
               
                sql = $"Insert into GASTOS (data, tipo, valor, descricao, escola_idEscola) VALUES ('{data}','{tipo}','{valor}','{descricao}',{Escola_idEscola})";
                // sqp = $"Insert INTO contatoescola(telefone, email_Escola, ip, Escola_idEscola) values('{Telefone}','{Email}','{IP}',{idEscola})";
            }
            else
            {
                sql = $"UPDATE GASTOS SET data ='{data}', tipo ='{tipo}', valor ='{valor}', descricao ='{descricao}', escola_idEscola ='{Escola_idEscola}' WHERE idGastos = '{idGasto}'";
                //sql = $"Insert INTO contatoescola(telefone, email_Escola, ip, Escola_idEscola) values('{Telefone}','{Email}','{IP}',{idEscola})";
            }
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir(int id_gastos)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM gastos WHERE idGastos = " + id_gastos);
        }

        public void ConverterValor()
        {
            this.valor = this.Valor.ToString().Replace(',', '.');
        }
    }
}
