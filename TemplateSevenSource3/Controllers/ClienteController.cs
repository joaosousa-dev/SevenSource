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
            var metodosbd = new metodosBDCLI();
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
                var metodosbd = new metodosBDCLI();
                metodosbd.CadastroCLI(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
        public ActionResult Editar(long cpf)
        {
            var banco = new Banco();
            var metodosusuario = new metodosBDCLI();
            var cliente = metodosusuario.ListaId(cpf);            
            cliente.idend= banco.RetornaIdEnd(cliente);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            
            return View(cliente);
        }
        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var metodosusuario = new metodosBDCLI();
                metodosusuario.AtualizarCLI(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
        public ActionResult Apagar(long cpf)
        {
            var metodosusuario = new metodosBDCLI();
            var cliente=metodosusuario.ListaId(cpf);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Apagar(Cliente cliente,long cpf)
        {
            var metodosusuario = new metodosBDCLI();
            metodosusuario.DeletarCLI(cpf);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(long cpf)
        {
            var metodosusuario = new metodosBDCLI();
           var cliente = metodosusuario.ListaId(cpf);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
        
    }
}