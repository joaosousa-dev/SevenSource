﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemplateSevenSource3.Controllers
{
    public class ErroController : Controller
    {
        // GET: Erro
        public ActionResult NaoEncontrado()
        {
            return View();
        }
        public ActionResult erro()
        {
            return View();
        }
    }
}