using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmeb2.Models
{
    public class ExtratoModel
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        private string valor;
        public double Valor { get; set; }
        public string Tipo { get; set; }
        public string Data { get; set; }
        public string DataFinal { get; set; }

        public int idEscola { get; set; }
        public int idGasto { get; set; }

        public ExtratoModel()
        {

        }

        public List<ExtratoModel> ListaExtrato()
        {
            List<ExtratoModel> lista = new List<ExtratoModel>();
            ExtratoModel item;

            string filtro = "";

            if ((Data != null) && (DataFinal != null) )
            {
                filtro += $"and g.data >='{DateTime.Parse(Data).ToString("yyyy/MM/dd")}' and g.data <='{DateTime.Parse(DataFinal).ToString("yyyy/MM/dd")}' ";
            }

            if (Tipo != null)
            {
                if (Tipo == "A")
                {
                    filtro += $"and g.tipo ='{Tipo}' ";
                }
                if(Tipo == "L")
                {
                    filtro += $"and g.tipo ='{Tipo}' ";
                }
            }

            if (idEscola != 0)
            {
                filtro += $"and g.escola_idEscola = '{idEscola}'";
            }

            string sql = $"select e.nome as escola, e.idEscola, g.valor, g.tipo, g.data, g.idGastos, g.descricao as historico from escola e inner Join gastos g on g.escola_idEscola = e.idEscola where g.escola_idEscola = {idEscola} {filtro} order by g.data desc limit 10 ";

            //string sql = $"select e.idExtrato, e.nome as escola, e.descricao as historico, e.valor, e.tipo, e.data, es.nome, c.idGastos from extrato as e inner join escola es on e.escola_idEscola = es.idEscola inner join Gastos as c on e.Gastos_idGastos = c.idGastos where e.Escola_idEscola = {idEscola} {filtro} order by e.data desc limit 10"; 

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ExtratoModel();
                item.id = int.Parse(dt.Rows[i]["idEscola"].ToString());
                item.Nome = dt.Rows[i]["escola"].ToString();
                item.Tipo = dt.Rows[i]["tipo"].ToString();
                item.Descricao = dt.Rows[i]["historico"].ToString();
                item.Valor = double.Parse(dt.Rows[i]["valor"].ToString());
                item.Data = DateTime.Parse(dt.Rows[i]["data"].ToString()).ToString("dd/MM/yyyy");
                item.idGasto = int.Parse(dt.Rows[i]["idGastos"].ToString());
            
                
                lista.Add(item);
            }
            return lista;
        }

        public ExtratoModel CarregarRegistro(int? id)
        {
            ExtratoModel item;

            string sql = $"select e.nome as escola, e.idEscola, g.valor, g.tipo, g.data, g.idGastos, g.descricao as historico from escola e inner Join gastos g on g.escola_idEscola = e.idEscola where g.escola_idEscola = {id}";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            item = new ExtratoModel();
            item.id = int.Parse(dt.Rows[0]["idEscola"].ToString());
            item.Nome = dt.Rows[0]["escola"].ToString();
            item.Tipo = dt.Rows[0]["tipo"].ToString();
            item.Descricao = dt.Rows[0]["historico"].ToString();
            item.Valor = double.Parse(dt.Rows[0]["valor"].ToString());
            item.Data = DateTime.Parse(dt.Rows[0]["data"].ToString()).ToString("dd/MM/yyyy");
            item.idGasto = int.Parse(dt.Rows[0]["idGastos"].ToString());

            return item;
        }
        
    }

    public class Dashboard
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        private string valor;

        public double Valor { get; set; }
        public double Total { get; set; }
        public string Tipo { get; set; }
        public string Data { get; set; }
        public string DataFinal { get; set; }

        public int idEscola { get; set; }
        public int idGasto { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public Dashboard()
        {

        }

        //Recebe o contexto para acesso às variáveis de sessão.
        public Dashboard(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<Dashboard> RetornarDadosGraficoPie()
        {
            List<Dashboard> lista = new List<Dashboard>();
            Dashboard item;

            string filtro = "";

            if ((Data != null) && (DataFinal != null))
            {
                filtro += $"and g.data >='{DateTime.Parse(Data).ToString("yyyy/MM/dd")}' and g.data <='{DateTime.Parse(DataFinal).ToString("yyyy/MM/dd")}' ";
            }

            if (Tipo != null)
            {
                if (Tipo == "A")
                {
                    filtro += $"and g.tipo ='{Tipo}' ";
                }
                if (Tipo == "L")
                {
                    filtro += $"and g.tipo ='{Tipo}' ";
                }
            }

            if (idEscola != 0)
            {
                filtro += $"and g.escola_idEscola = '{idEscola}'";
            }

            string sql = $"select e.nome as escola, g.* from escola e inner join gastos g on g.escola_idEscola = e.idEscola where g.escola_idEscola = {idEscola} {filtro}";
            DAL objDAL = new DAL();
            DataTable dt = new DataTable();
            dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Dashboard();
                item.Valor = double.Parse(dt.Rows[i]["Valor"].ToString());
                item.Nome = dt.Rows[i]["Escola"].ToString();
                lista.Add(item);
            }
            return lista;
        }
    }
}
    

