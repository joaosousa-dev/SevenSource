using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateSevenSource3.Dominio;
using TemplateSevenSource3.Metodos;
using TemplateSevenSource3AcessoDados;
using TemplateSevenSource3Dominio;
using TemplateSevenSource3Metodos;

namespace TemplateSevenSource3.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            var metodosmarca = new MetodosBDMARCA();
            var todasmarcas = metodosmarca.ListarMarca();
            return View(todasmarcas);
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Marca marca)
        {
            if (ModelState.IsValid)
            {
                var metodosmarca = new MetodosBDMARCA();
                metodosmarca.CadastrarMarca(marca);
                return RedirectToAction("Index");
            }
            return View(marca);
        }
        public ActionResult Editar(int id)
        {
            var banco = new Banco();
            var metodosmarca = new MetodosBDMARCA();
            var marca = metodosmarca.ListaId(id);
            if (marca == null)
            {
                return HttpNotFound();
            }

            return View(marca);
        }
        [HttpPost]
        public ActionResult Editar(Marca marca)
        {
            if (ModelState.IsValid)
            {
                var metodosmarca = new MetodosBDMARCA();
                metodosmarca.AtualizarMarca(marca);
                return RedirectToAction("Index");
            }
            return View(marca);
        }
        public ActionResult Apagar(int id)
        {
            var metodosmarca = new MetodosBDMARCA();
            var marca = metodosmarca.ListaId(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }
        [HttpPost]
        public ActionResult Apagar(Marca marca,int id)
        {
            var metodosmarca = new MetodosBDMARCA();
            metodosmarca.DeletarMarca(id);
            return RedirectToAction("Index");
        }
        public ActionResult Detalhes(int id)
        {
            var metodosmarca = new MetodosBDMARCA();
            var marca = metodosmarca.ListaId(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }
    }

}