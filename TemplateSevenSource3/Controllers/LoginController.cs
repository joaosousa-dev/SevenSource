using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TemplateSevenSource3.Metodos;
using TemplateSevenSource3Dominio;

namespace TemplateSevenSource3.Controllers
{
    public class LoginController : Controller
    {
        MetodosBDFUNC metodo = new MetodosBDFUNC();
        public ActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar(Funcionario funcionario)
        {

            funcionario=metodo.TestarUsuario(funcionario);

            // foi devolvido um resultado do banco, caso as informaççoes
            // do banco forem diferentes de nula, ou seja se foram
            // encontradas informações no banco serão criadas sessões
            if (funcionario.Login != null && funcionario.Senha != null)
            {
                FormsAuthentication.SetAuthCookie(funcionario.Login, false);
                Session["usuarioLogado"] = funcionario.Login.ToString();
                Session["senhaLogado"] = funcionario.Senha.ToString();
                Session["nomeCargo"] = funcionario.NomeCargo.ToString(); ;
                //direcionando o usuario para pagina Index da home
                return RedirectToAction("Menu", "Funcionario");
            }
            else
            {
                // se estiver errado usuário e senha permaneça na pagina login
                return RedirectToAction("Entrar", "Login");
            }
        }
        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null; // destruindo a sessão.
            return RedirectToAction("Entrar", "Login");
        }
    }
}