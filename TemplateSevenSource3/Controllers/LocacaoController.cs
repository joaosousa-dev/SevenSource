using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateSevenSource3.Metodos;
using TemplateSevenSource3Dominio;

namespace TemplateSevenSource3.Controllers
{
    public class LocacaoController : Controller
    {
        // GET: Locacao
        public ActionResult Index()
        {
            var metodo = new MetodosBDLOCAC();
            var todaslocac = metodo.ListarLocacao();
            return View(todaslocac);
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Locacao locacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodo = new MetodosBDLOCAC();
                    metodo.CadastrarLocacao(locacao);
                    return RedirectToAction("Index");
                }

                return View(locacao);
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }

        public ActionResult Devolucao(int id, int idv)
        {
            try
            {
                var metodo = new MetodosBDLOCAC();
                metodo.DevolucaoLocacao(id, idv);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        public ActionResult Pagamento(int id)
        {
            try
            {
                var metodo = new MetodosBDLOCAC();
                var locacao = metodo.ListaId(id);
                if (locacao == null)
                {
                    return HttpNotFound();
                }

                return View(locacao);
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        [HttpPost]
        public ActionResult Pagamento(Locacao locacao)
        {
            try
            {
                var metodo = new MetodosBDLOCAC();
                metodo.PagamentoLocacao(locacao);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
    }
}