using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateSevenSource3.Metodos;
using TemplateSevenSource3Dominio;

namespace TemplateSevenSource3.Controllers
{
    public class VeiculoController : Controller
    {
        // GET: Veiculo
        public ActionResult Index()
        {
            var metodosbdveiculo = new MetodosBDVEICULO();
            var todosveiculos=metodosbdveiculo.ListarVeiculo();
            return View(todosveiculos);
        }
        public ActionResult Lista()
        {
            var metodosbdveiculo = new MetodosBDVEICULO();
            var todosveiculos = metodosbdveiculo.ListarVeiculo();
            return View(todosveiculos);
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Veiculo veiculo,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if(file.FileName != null)
                {
                    //string caminho = @"\\Content\\CarrosImg\\" + file.FileName.ToString();
                    veiculo.fotopath = file.FileName;
                }
                var metodosveiculo = new MetodosBDVEICULO();
                metodosveiculo.CadastroVeiculo(veiculo);
                return RedirectToAction("Index");
            }
            return View(veiculo);
        }
        public ActionResult Editar(int id)
        {
            var metodosBDVEICULO = new MetodosBDVEICULO();
            var veiculo = metodosBDVEICULO.ListaId(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }

            return View(veiculo);
        }
        [HttpPost]
        public ActionResult Editar(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                var metodosBDVEICULO = new MetodosBDVEICULO();
                metodosBDVEICULO.AtualizarVeiculo(veiculo);
                return RedirectToAction("Index");
            }
            return View(veiculo);
        }
        public ActionResult Apagar(int id)
        {
            var metodosBDVEICULO= new MetodosBDVEICULO();
            var veiculo = metodosBDVEICULO.ListaId(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }
        [HttpPost]
        public ActionResult Apagar(Veiculo veiculo,int id)
        {
            var metodosBDVEICULO = new MetodosBDVEICULO();
            metodosBDVEICULO.DeletarVeiculo(id);
            return RedirectToAction("Index");
        }
        public ActionResult Detalhes(int id)
        {
            var metodosBDVEICULO = new MetodosBDVEICULO();
            var veiculo = metodosBDVEICULO.ListaId(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }
    }
}