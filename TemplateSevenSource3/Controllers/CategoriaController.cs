using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateSevenSource3.Dominio;
using TemplateSevenSource3.Metodos;
using TemplateSevenSource3AcessoDados;
using TemplateSevenSource3Dominio;

namespace TemplateSevenSource3.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            var metodoscategoria = new MetodosBDCATEG();
            var todascategorias = metodoscategoria.ListarCategoria();
            return View(todascategorias);
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var metodoscategoria = new MetodosBDCATEG();
                metodoscategoria.CadastrarCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }
        public ActionResult Editar(int id)
        {
            var metodoscategoria = new MetodosBDCATEG();
            var categoria = metodoscategoria.ListaId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }
        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var metodoscategoria = new MetodosBDCATEG();
                metodoscategoria.AtualizarCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }
        public ActionResult Apagar(int id)
        {
            var metodoscategoria = new MetodosBDCATEG();
            var categoria = metodoscategoria.ListaId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        [HttpPost]
        public ActionResult Apagar(Categoria categoria, int id)
        {
            var metodoscategoria = new MetodosBDCATEG();
            metodoscategoria.DeletarCategoria(id);
            return RedirectToAction("Index");
        }
        public ActionResult Detalhes(int id)
        {
            var metodoscategoria = new MetodosBDCATEG();
            var categoria = metodoscategoria.ListaId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        public ActionResult Lista()
        {
            var metodoscategoria = new MetodosBDCATEG();
            var todascategorias = metodoscategoria.ListarCategoria();
            return View(todascategorias);
        }
    }
}