using AutenticacaoAspNet.Models;
using AutenticacaoAspNet.Utils;
using AutenticacaoAspNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoAspNet.Controllers
{
    public class AutenticacaoController : Controller
    {
        private UsuariosContext db = new UsuariosContext();
        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewModel)
        {
            //SE AS CREDENCIAS NÃO FOREM VÁLIDAS, RETORNA PARA DE CADASTRO
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            //VALIDAÇÃO DE LOGIN EXISTENTE
            if (db.Usuarios.Count(u => u.Login ==viewModel.Login) >0)
            {
                ModelState.AddModelError("Login", "Esse login já está em uso");
                return View(viewModel);
            }
            //CEIAÇÃO DE USUÁRIO
            Usuario novoUsuario = new Usuario()
            {
                Nome = viewModel.Nome,
                Login = viewModel.Login,
                Senha = Hash.GerarHash(viewModel.Senha)
            };

            db.Usuarios.Add(novoUsuario);
            db.SaveChanges();

            TempData["Mensagem"] = "Cadastro realizado com sucesso. Efeute seu login.";

            return RedirectToAction("Login");
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewModel = new LoginViewModel
            {
                //PROTEÇÃO DE ACESSO NÃO AUTENTICADO
                UrlRetorno = ReturnUrl
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login (LoginViewModel viewModel)
        {
            //VALIDAÇÃO DE LOGIN
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            //CONSULTA AO BANCO DE DADOS (OU RETORNA O LOGIN OU RETORNA VALOR NULL)
            var usuario = db.Usuarios.FirstOrDefault(dbuser => dbuser.Login == viewModel.Login);

            //SE O USUÁRIO ESTIVER ERRADO É RETORNADO UMA MENSAGEM DE ERRO
            if (usuario == null)
            {
                ModelState.AddModelError("Login", "Login incorreto");
                return View(viewModel);
            }

            //SE A SENHA ESTIVER ERRDA É RETONADO UMA MENSAGEM DE ERRO
            if (usuario.Senha != Hash.GerarHash(viewModel.Senha))
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                return View(viewModel);
            }

            //SE A ATUTENTICAÇÃO ESTIVER VALIDA
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Login),
                new Claim(ClaimTypes.Role, usuario.Tipo.ToString())
            }, "ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewModel.UrlRetorno) || Url.IsLocalUrl(viewModel.UrlRetorno))
            {
                return Redirect(viewModel.UrlRetorno);
            }
            else
            {
                return RedirectToAction("Index", "Painel");
            }
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
    }

}