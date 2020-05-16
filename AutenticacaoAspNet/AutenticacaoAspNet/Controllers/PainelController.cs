using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoAspNet.Controllers
{
    public class PainelController : Controller
    {
        // GET: Painel
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Padrao"))
            {
                ViewBag.Mensagem = "Você é uma usuário padrão e não poderá altera dados do sistema.";
            }
            return View();
        }

        [Authorize]
        public ActionResult Mensagens()
        {
            return View();
        }
    }
}