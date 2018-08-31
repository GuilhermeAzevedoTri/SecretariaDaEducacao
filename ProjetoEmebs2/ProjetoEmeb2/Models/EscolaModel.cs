using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmeb2.Models
{
    public class EscolaModel
    {
        public int idEscola { get; set; }

        [Required(ErrorMessage = "Informe o Nome da Escola!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Endereço!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe o N°!")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Informe o Bairro!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe o CEP!")]
        public string Cep { get; set; }


        public string CodAgua { get; set; }


        public string CodLuz { get; set; }

        //CONTATO
        public int idContatoEscola { get; set; }
        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
        public string IP { get; set; }
        public string Email { get; set; }





        IHttpContextAccessor HttpContextAccessor { get; set; }

        public EscolaModel()
        {

        }

        /*public EscolaModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }*/
        public List<EscolaModel> ListaEscola()
        {
            List<EscolaModel> lista = new List<EscolaModel>();
            EscolaModel item;

            //string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"select * from Escola";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                item = new EscolaModel();

                item.idEscola = int.Parse(dt.Rows[i]["idEscola"].ToString());
                item.Nome = dt.Rows[i]["nome"].ToString();
                item.Endereco = dt.Rows[i]["endereco"].ToString();
                item.Numero = dt.Rows[i]["numero"].ToString();
                item.Bairro = dt.Rows[i]["bairro"].ToString();
                item.Cep = dt.Rows[i]["cep"].ToString();
                item.CodAgua = dt.Rows[i]["codigo_Agua"].ToString();
                item.CodLuz = dt.Rows[i]["codigo_Luz"].ToString();
                item.Telefone = dt.Rows[i]["telefone"].ToString();
                item.Telefone2 = dt.Rows[i]["telefone2"].ToString();
                item.IP = dt.Rows[i]["ip"].ToString();
                item.Email = dt.Rows[i]["email_Escola"].ToString();
                lista.Add(item);
            }
            return lista;

        }

        public void CadastrarEscola()

        {
            string sql = "";
           
            if (idEscola == 0)
            {
                sql = $"INSERT INTO escola(nome, endereco, numero, bairro, cep, codigo_Agua, codigo_Luz, telefone, telefone2, ip, email_Escola) values('{Nome}','{Endereco}','{Numero}','{Bairro}','{Cep}','{CodAgua}','{CodLuz}','{Telefone}','{Telefone2}','{IP}','{Email}')";
               // sqp = $"Insert INTO contatoescola(telefone, email_Escola, ip, Escola_idEscola) values('{Telefone}','{Email}','{IP}',{idEscola})";
            }
            else
            {
                sql = $"UPDATE escola SET nome ='{Nome}', endereco ='{Endereco}', numero ='{Numero}', bairro ='{Bairro}', cep ='{Cep}', codigo_Agua ='{CodAgua}', codigo_Luz='{CodLuz}', telefone ='{Telefone}', telefone2 = '{Telefone2}', ip = '{IP}' , email_Escola ='{Email}' WHERE idEscola = '{idEscola}'";
                //sql = $"Insert INTO contatoescola(telefone, email_Escola, ip, Escola_idEscola) values('{Telefone}','{Email}','{IP}',{idEscola})";
            }   
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }

        public void Visualizar()
        {

        }

        public void Excluir(int id_escola)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM ESCOLA WHERE IdEscola = " + id_escola);
        }

        public EscolaModel CarregarRegistro(int? id_escola)
        {
            EscolaModel item = new EscolaModel();

            string sql = $"SELECT idEscola, nome, endereco, numero, bairro, cep, codigo_Agua, codigo_Luz, telefone, telefone2, ip, email_Escola from escola Where idEscola = {id_escola}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);


            item.idEscola = int.Parse(dt.Rows[0]["idEscola"].ToString());
            item.Nome = dt.Rows[0]["nome"].ToString();
            item.Endereco = dt.Rows[0]["endereco"].ToString();
            item.Numero = dt.Rows[0]["numero"].ToString();
            item.Bairro = dt.Rows[0]["bairro"].ToString();
            item.Cep = dt.Rows[0]["cep"].ToString();
            item.CodAgua = dt.Rows[0]["codigo_Agua"].ToString();
            item.CodLuz = dt.Rows[0]["codigo_Luz"].ToString();
            item.Telefone = dt.Rows[0]["telefone"].ToString();
            item.Telefone2 = dt.Rows[0]["telefone2"].ToString();
            item.IP = dt.Rows[0]["ip"].ToString();
            item.Email = dt.Rows[0]["email_Escola"].ToString();

            return item;
        }

    }



}

