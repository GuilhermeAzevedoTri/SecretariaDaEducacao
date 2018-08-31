using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEmeb2.Models;

namespace ProjetoEmeb2.Controllers
{
    public class FuncionarioController : Controller
    {
        /*IHttpContextAccessor HttpContextAccessor;
        public EscolaController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }*/
        public IActionResult Index()
        {
            FuncionarioModel objFuncionario = new FuncionarioModel();
            ViewBag.ListaFuncionario = objFuncionario.ListaFuncionario();

            return View();
        }

        [HttpPost]
        public IActionResult CriarFuncionario(FuncionarioModel formulario)
        {
            if (ModelState.IsValid)
            {

                formulario.CriarFuncionario();
                return RedirectToAction("Index");

            }
            return View();

        }



        [HttpGet]
        public IActionResult CriarFuncionario(int? id)
        {
            if (id != null)
            {
                FuncionarioModel objFuncionario = new FuncionarioModel();
                ViewBag.Registro = objFuncionario.CarregarRegistro(id);

            }

            return View();
        }

        [HttpGet]
        public IActionResult ExcluirFuncionario(int id)
        {
            FuncionarioModel objFuncionario = new FuncionarioModel();
            objFuncionario.Excluir(id);
            return RedirectToAction("Index");
        }


    }
}