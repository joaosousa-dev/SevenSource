using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateSevenSource3Dominio;

namespace TemplateSevenSource3.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult Cadastro(Funcionario func)
        {
            return View(func);
        }
    }
    
}