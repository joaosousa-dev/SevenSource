using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateSevenSource3.Metodos;
using TemplateSevenSource3Dominio;

namespace TemplateSevenSource3.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            var metodo = new MetodosBDFUNC();
            var todosfuncs = metodo.ListarFUNC();
            return View(todosfuncs);
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var metodo = new MetodosBDFUNC();
                metodo.CadastroFUNC(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }
        public ActionResult Editar(int id)
        {
            var metodo = new MetodosBDFUNC();
            var funcionario = metodo.ListaId(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }

            return View(funcionario);
        }
        [HttpPost]
        public ActionResult Editar(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var metodo = new MetodosBDFUNC();
                metodo.AtualizarFUNC(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }
        public ActionResult Apagar(int id)
        {
            var metodo = new MetodosBDFUNC();
            var funcionario = metodo.ListaId(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }
        [HttpPost]
        public ActionResult Apagar(Funcionario funcionario, int id)
        {
            var metodo = new MetodosBDFUNC();
            metodo.DeletarFUNC(id);
            return RedirectToAction("Index");
        }
        public ActionResult Detalhes(int id)
        {
            var metodo = new MetodosBDFUNC();
            var funcionario = metodo.ListaId(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }
    }
    
}