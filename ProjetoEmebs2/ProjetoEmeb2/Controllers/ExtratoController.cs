using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoEmeb2.Models;

namespace ProjetoEmeb2.Controllers
{
    public class ExtratoController : Controller
    {
        public IActionResult Index()
        {
            ExtratoModel objConta = new ExtratoModel();
            ViewBag.ListaExtrato = objConta.ListaExtrato();
            return View();
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Extrato(ExtratoModel formulario)
        {
            ViewBag.ListaExtrato = formulario.ListaExtrato();
            ViewBag.ListaEscola = new EscolaModel().ListaEscola();
            ViewBag.ListaConta = new ContaModel().ListaConta();

            List<Dashboard> lista = new Dashboard().RetornarDadosGraficoPie();
            string valores = "";
            string labels = "";
            string cores = "";
            var random = new Random();

            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].Total.ToString() + ",";
                labels += "'" + lista[i].Nome.ToString() + "',";
                cores += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }

            ViewBag.Cores = cores;
            ViewBag.Labels = labels;
            ViewBag.Valores = valores;

            return View();

        }

        public IActionResult Dashboard()
        {
            List<Dashboard> lista = new Dashboard().RetornarDadosGraficoPie();
            string valores = "";
            string labels = "";
            string cores = "";
            var random = new Random();

            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].Valor.ToString() + ",";
                labels += "'" + lista[i].Nome.ToString() + "',";
                cores += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }

            ViewBag.Cores = cores;
            ViewBag.Labels = labels;
            ViewBag.Valores = valores;

            return View();
        }
    }
}