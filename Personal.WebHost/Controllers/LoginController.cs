using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic.Interfaces;
using BussinessLogic.BussinessLogic;
using Personal.Models;
using System.Web.Security;
using Personal.ViewModels;
using BussinessLogic.WebHost.ViewModels;
namespace BussinessLogic.WebHost.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private readonly IPrvUsuario prvUsuarioRepository;

        public LoginController()
            : this(new usuarioBL())
        {
        }

        public LoginController(IPrvUsuario prvUsuarioRepository)
        {
             
            this.prvUsuarioRepository = prvUsuarioRepository;

        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(usuarioModel model)
        {
            if (ModelState.IsValid)
            {
                if (prvUsuarioRepository.verifyUser(model.V_NOM_USUARIO, model.V_CONTRASEÑA) > 0)
                {
                    FormsAuthentication.SetAuthCookie(model.V_NOM_USUARIO, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(model.V_NOM_USUARIO, "Last Name " + "ff" + " not found");
                    return View(model);
                }

            }
            else
            {
                return View();
            }
        }
        public ActionResult permisosUsuarioXSistema(string codTipoSistema, string nomUsuario, string tipoMenu)
        {
            return Json(prvUsuarioRepository.permisosUsuarioXSistema(codTipoSistema, nomUsuario, tipoMenu), JsonRequestBehavior.AllowGet);
        }
        public ActionResult datosAvatarUser(string username)
        {
            return Json(prvUsuarioRepository.consultarAreaCargoXusuarioEQ(username), JsonRequestBehavior.AllowGet);

        }

        public ActionResult listarPermisoXmenuParent(string codMenu, string codTipoSistema, string tipoOpcion, string nomUsuario)
        {

            return Json(prvUsuarioRepository.listarPermisoXmenuParent(codMenu, codTipoSistema, tipoOpcion, nomUsuario), JsonRequestBehavior.AllowGet);

        }
        public ActionResult closedSession()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");

        }
    }
}
