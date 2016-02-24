using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic.Interfaces;
using BussinessEntity;
using BussinessLogic;

namespace BussinessLogic.WebHost.Controllers
{
    public class MaEspecilidadController : Controller
    {
        //
        // GET: /MaEspecilidad/
        private IRepository repository;
        public MaEspecilidadController()
        {

            this.repository = new MaEspecialidadBL();

        }
        public ActionResult _create()
        {
            return PartialView();
        }

        public ActionResult _listarEspecilidad()
        {
            return PartialView(repository.GetAll<MA_ESPECIALIDAD>());
        }

        public ActionResult edit(int id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_edit", repository.GetById<MA_ESPECIALIDAD>(id));
            }
            else
            {
                return View(repository.GetById<MA_ESPECIALIDAD>(id));
            }
        }
        public ActionResult index()
        {
            ViewBag.lista = repository.GetAll<MA_ESPECIALIDAD>();
            return View();
        }
        public ActionResult delete(int id)
        {
            string msg = "";
            if (repository.delete(id) > 0)
                msg = "Se ha Eliminado COrrectamente";
            else
                msg = "ha ocurrido un error";
            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult edit(MA_ESPECIALIDAD model)
        {
            if (ModelState.IsValid)
            {
                if (repository.edit(model) > 0)
                {
                    //is action buil an url but reditorroute redirection a route create an global asax
                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError("", "Ocurrrio un erro internamente comuniquese con la area de Sistemas con J.Salinas");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult guardar(MA_ESPECIALIDAD entity)
        {
            return Json(repository.create(entity), JsonRequestBehavior.AllowGet);
        }

    }
}
