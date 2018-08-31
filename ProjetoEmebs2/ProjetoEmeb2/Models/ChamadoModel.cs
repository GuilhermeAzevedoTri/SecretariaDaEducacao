using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmeb2.Models
{
    public class ChamadoModel
    {

        public int idChamado { get; set; }

        [Required(ErrorMessage = "Informe a Data!")]
        public string data { get; set; }

        [Required(ErrorMessage = "Informe o Tipo!")]

        public string tipo { get; set; }
        public string descricao { get; set; }

        [Required(ErrorMessage = "Informe a Situação!")]

        public string situacao { get; set; }
        [Required(ErrorMessage = "Informe o Protocolo!")]
        public string protocolo { get; set; }
        [Required(ErrorMessage = "Informe o Atendente!")]
        public string atendente { get; set; }
        //public string descricao { get; set; }

        public int Escola_idEscola { get; set; }
        public string nome { get; set; }

        public string Data { get; set; }
        public string DataFinal { get; set; }
        public string Tipo { get; set; }
        public string INC { get; set; }


        public ChamadoModel()
        {

        }

        public List<ChamadoModel> ListaChamado()
        {
            List<ChamadoModel> lista = new List<ChamadoModel>();
            ChamadoModel item;

            string sql = $"select e.nome as escola, C.* from escola e inner join chamado c on c.escola_idEscola = e.idEscola order by c.data DESC";


            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                item = new ChamadoModel();  
                item.idChamado = int.Parse(dt.Rows[i]["idChamado"].ToString());
                item.data = DateTime.Parse(dt.Rows[i]["data"].ToString()).ToString("dd/MM/yyyy");

                item.tipo = dt.Rows[i]["tipo"].ToString();
                item.situacao = dt.Rows[i]["situacao"].ToString();
                item.protocolo = dt.Rows[i]["protocolo"].ToString();
                item.atendente = dt.Rows[i]["atendente"].ToString();
                item.descricao = dt.Rows[i]["descricao"].ToString();
                item.Escola_idEscola = int.Parse(dt.Rows[i]["escola_idEscola"].ToString());
                item.nome = dt.Rows[i]["escola"].ToString();

                lista.Add(item);


            }
            return lista;
        }

        public ChamadoModel CarregarRegistro(int? id_chamado)
        {
            ChamadoModel item = new ChamadoModel();

            string sql = $"select e.nome as escola, C.* from escola e inner join chamado c on c.escola_idEscola = e.idEscola Where c.idChamado = {id_chamado}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);


            item = new ChamadoModel();
            item.idChamado = int.Parse(dt.Rows[0]["idChamado"].ToString());
            item.data = DateTime.Parse(dt.Rows[0]["data"].ToString()).ToString("dd/MM/yyyy");
            item.tipo = dt.Rows[0]["tipo"].ToString();
            item.situacao = dt.Rows[0]["situacao"].ToString();
            item.protocolo = dt.Rows[0]["protocolo"].ToString();
            item.atendente = dt.Rows[0]["atendente"].ToString();
            item.descricao = dt.Rows[0]["descricao"].ToString();

            item.Escola_idEscola = int.Parse(dt.Rows[0]["escola_idEscola"].ToString());
            item.nome = dt.Rows[0]["escola"].ToString();

            return item;
        }

        public void Insert()
        {

            string sql = "";

            if (idChamado == 0)
            {
                sql = $"Insert into Chamado (data, tipo, situacao, protocolo, atendente, escola_idEscola, descricao) VALUES ('{data}','{tipo}','{situacao}','{protocolo}','{atendente}','{Escola_idEscola}', '{descricao}')";
                // sqp = $"Insert INTO contatoescola(telefone, email_Escola, ip, Escola_idEscola) values('{Telefone}','{Email}','{IP}',{idEscola})";
            }
            else
            {
                sql = $"UPDATE Chamado SET data ='{data}', tipo ='{tipo}', situacao ='{situacao}', protocolo ='{protocolo}', atendente ='{atendente}', escola_idEscola ='{Escola_idEscola}', descricao = '{descricao}' WHERE idChamado = '{idChamado}'";
                //sql = $"Insert INTO contatoescola(telefone, email_Escola, ip, Escola_idEscola) values('{Telefone}','{Email}','{IP}',{idEscola})";
            }
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir(int id_chamado)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM chamado WHERE idChamado = " + id_chamado);
        }

        public List<ChamadoModel> ListaPesquisa()
        {
            List<ChamadoModel> lista = new List<ChamadoModel>();
            ChamadoModel itens;

            string filtro = "";

            if ((Data != null) && (DataFinal != null))
            {
                filtro += $"and c.data >='{DateTime.Parse(Data).ToString("yyyy/MM/dd")}' and c.data <='{DateTime.Parse(DataFinal).ToString("yyyy/MM/dd")}' ";
            }

            if (Tipo != null)
            {
                if (Tipo == "D")
                {
                    filtro += $"and c.tipo ='{Tipo}' ";
                }
                if (Tipo == "V")
                {
                    filtro += $"and c.tipo ='{Tipo}' ";
                }
                if (Tipo == "T")
                {
                    filtro += $"and c.tipo ='{Tipo}' ";
                }
            }
            
            if (situacao != null)
            {
                if (situacao == "A")
                {
                    filtro += $"and c.situacao ='{situacao}' ";
                }
                if (situacao == "F")
                {
                    filtro += $"and c.situacao ='{situacao}' ";
                }
                
            }

            if(protocolo != null)
            {
                filtro += $"and c.protocolo ='{protocolo}'";
            }

            if (Escola_idEscola != 0)
            {
                filtro += $"where c.escola_idEscola = '{Escola_idEscola}'";
            }

            string sql = $"select e.nome as escola, C.* from escola e inner join chamado c on c.escola_idEscola = e.idEscola {filtro} order by c.data desc limit 25 ";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                itens = new ChamadoModel();
                itens.idChamado = int.Parse(dt.Rows[i]["idChamado"].ToString());
                itens.data = DateTime.Parse(dt.Rows[i]["data"].ToString()).ToString("dd/MM/yyyy");
                itens.nome = dt.Rows[i]["escola"].ToString();
                itens.tipo = dt.Rows[i]["tipo"].ToString();
                itens.situacao = dt.Rows[i]["situacao"].ToString();
                itens.protocolo = dt.Rows[i]["protocolo"].ToString();
                itens.atendente = dt.Rows[i]["atendente"].ToString();
                itens.descricao = dt.Rows[i]["descricao"].ToString();
                itens.Escola_idEscola = int.Parse(dt.Rows[i]["escola_idEscola"].ToString());


                lista.Add(itens);
            }
            return lista;
        }



    }
}
