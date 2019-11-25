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
            try
            {
                if (ModelState.IsValid)
                {
                    var metodo = new MetodosBDFUNC();
                    metodo.CadastroFUNC(funcionario);
                    return RedirectToAction("Index");
                }
                return View(funcionario);
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        public ActionResult Editar(int id)
        {
            try
            {
                var metodo = new MetodosBDFUNC();
                var funcionario = metodo.ListaId(id);
                if (funcionario == null)
                {
                    return HttpNotFound();
                }

                return View(funcionario);
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        [HttpPost]
        public ActionResult Editar(Funcionario funcionario)
        {
            try{
                if (funcionario.Nome != null && funcionario.IdCargo != 0 && funcionario.Login != null && funcionario.Cpf != null)
                {
                    var metodo = new MetodosBDFUNC();
                    metodo.AtualizarFUNC(funcionario);
                    return RedirectToAction("Index");
                }
                return View(funcionario);
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        public ActionResult Apagar(int id)
        {
            try
            {
                var metodo = new MetodosBDFUNC();
                var funcionario = metodo.ListaId(id);
                if (funcionario == null)
                {
                    return HttpNotFound();
                }
                return View(funcionario);
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        [HttpPost]
        public ActionResult Apagar(Funcionario funcionario, int id)
        {
            try
            {
                var metodo = new MetodosBDFUNC();
                metodo.DeletarFUNC(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        public ActionResult Detalhes(int id)
        {
            try
            {
                var metodo = new MetodosBDFUNC();
                var funcionario = metodo.ListaId(id);
                if (funcionario == null)
                {
                    return HttpNotFound();
                }
                return View(funcionario);
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        public ActionResult Menu()
        {
            return View();
        }
    }
    
}