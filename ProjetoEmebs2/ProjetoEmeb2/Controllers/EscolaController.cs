using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEmeb2.Models;

namespace ProjetoEmeb2.Controllers
{
    public class EscolaController : Controller
    {
        /*IHttpContextAccessor HttpContextAccessor;
        public EscolaController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }*/
        public IActionResult Index()
        {
            EscolaModel objEscola = new EscolaModel();
            ViewBag.ListaEscola = objEscola.ListaEscola();

            return View();
        }

        [HttpPost]
        public IActionResult CriarEscola(EscolaModel formulario)
        {
            if (ModelState.IsValid)
            {
                //formulario.HttpContextAccessor = httpContextAccessor;
                formulario.CadastrarEscola();
                return RedirectToAction("Index");
            }
            return View();
        }

       

        [HttpGet]
        public IActionResult CriarEscola(int? id)
        {
            if (id != null)
            {
                EscolaModel objEscola = new EscolaModel();
                ViewBag.Registro = objEscola.CarregarRegistro(id);

            }
            
            return View();
        }

        [HttpGet]
        public IActionResult ExcluirEscola(int id)
        {
            EscolaModel objEscola = new EscolaModel();
            objEscola.Excluir(id);
            return RedirectToAction("Index");
        }
  
        [HttpGet]
        public IActionResult Visualizar(int id)
        {
            EscolaModel objEscola = new EscolaModel();
            ViewBag.Registro = objEscola.CarregarRegistro(id);
            return View();

        }


    }
}