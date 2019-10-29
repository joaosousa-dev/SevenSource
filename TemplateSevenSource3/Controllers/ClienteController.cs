using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateSevenSource3Dominio;
using TemplateSevenSource3AcessoDados;
using TemplateSevenSource3Metodos;

namespace TemplateSevenSource3.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            var metodosbd = new metodosBD();
            var todosclientes = metodosbd.ListarCLI(); 
            return View(todosclientes);
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var metodosbd = new metodosBD();
                metodosbd.CadastroCLI(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
    }
}