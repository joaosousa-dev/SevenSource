using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateSevenSource3.Dominio;
using TemplateSevenSource3.Metodos;
using TemplateSevenSource3AcessoDados;

namespace TemplateSevenSource3.Controllers
{
    public class ManutencaoController : Controller
    {
        public ActionResult Index()
        {
            var metodo = new MetodosBDMANUT();
            var todasmanut = metodo.ListarManutencao();
            return View(todasmanut);
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Manutencao manutencao)
        {
            if (ModelState.IsValid)
            {
                var metodo = new MetodosBDMANUT();
                metodo.CadastrarManutencao(manutencao);
                return RedirectToAction("Index");
            }
            return View(manutencao);
        }
        public ActionResult Editar(int id)
        {
            var metodo = new MetodosBDMANUT();
            var manutencao = metodo.ListaId(id);
            if (manutencao == null)
            {
                return HttpNotFound();
            }

            return View(manutencao);
        }
        [HttpPost]
        public ActionResult Editar(Manutencao manutencao)
        {
            if (ModelState.IsValid)
            {
                var metodo = new MetodosBDMANUT();
                metodo.AtualizarManutencao(manutencao);
                return RedirectToAction("Index");
            }
            return View(manutencao);
        }
        public ActionResult Apagar(int id)
        {
            var metodo = new MetodosBDMANUT();
            var manutencao = metodo.ListaId(id);
            if (manutencao == null)
            {
                return HttpNotFound();
            }
            return View(manutencao);
        }
        [HttpPost]
        public ActionResult Apagar(Manutencao manutencao, int id)
        {
            var metodo = new MetodosBDMANUT();
            metodo.DeletarManutencao(id);
            return RedirectToAction("Index");
        }
        public ActionResult Detalhes(int id)
        {
            var metodo = new MetodosBDMANUT();
            var manutencao = metodo.ListaId(id);
            if (manutencao == null)
            {
                return HttpNotFound();
            }
            return View(manutencao);
        }
    }
}