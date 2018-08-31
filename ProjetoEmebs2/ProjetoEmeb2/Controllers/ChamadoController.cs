using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoEmeb2.Models;

namespace ProjetoEmeb2.Controllers
{
    public class ChamadoController : Controller
    {
        [HttpGet]
        [HttpPost]
        public IActionResult Index(ChamadoModel formulario)
        {
            ViewBag.ListaPesquisa = formulario.ListaPesquisa();
            ViewBag.ListaChamado = formulario.ListaChamado();
            ViewBag.ListaEscola = new EscolaModel().ListaEscola();
            return View();
        }

        [HttpPost]
        public IActionResult CriarChamado(ChamadoModel formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.Insert();
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult CriarChamado(int? id)
        {
            if (id != null)
            {
                ChamadoModel objChamado = new ChamadoModel();
                ViewBag.Registro = objChamado.CarregarRegistro(id);

            }
            ViewBag.ListaEscola = new EscolaModel().ListaEscola();
            return View();
        }

        [HttpGet]
        public IActionResult ExcluirChamado(int id)
        {
            ChamadoModel objChamado = new ChamadoModel();
            objChamado.Excluir(id);
            return RedirectToAction("Index");
        }

        

    }
}