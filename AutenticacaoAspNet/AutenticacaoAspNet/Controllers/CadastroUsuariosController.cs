using AutenticacaoAspNet.Filters;
using AutenticacaoAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoAspNet.Controllers
{
    public class CadastroUsuariosController : Controller
    {
        // GET: CadastroUsuarios
        [AutorizacaoTipo(new[] { TipoUsuario.Administrador })]
        public ActionResult Index()
        {
            return View();
        }
    }
}