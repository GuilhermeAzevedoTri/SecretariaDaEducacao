using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoEmeb2.Models;

namespace ProjetoEmeb2.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Index()
        {
            ContaModel objConta = new ContaModel();
            ViewBag.ListaConta = objConta.ListaConta();
            return View();
        }

        
        [HttpPost]
        public IActionResult CriarConta(ContaModel formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.Insert();
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult CriarConta(int? id)
        {
            if (id != null)
            {
                ContaModel objConta = new ContaModel();
                ViewBag.Registro = objConta.CarregarRegistro(id);

            }
            ViewBag.ListaEscola = new EscolaModel().ListaEscola();

            return View();
        }

        [HttpGet]
        public IActionResult ExcluirConta(int id)
        {
            ContaModel objConta = new ContaModel();
            objConta.Excluir(id);
            return RedirectToAction("Index");
        }



    }
}