using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic.Interfaces;
using BussinessLogic;
using BussinessEntity;

namespace BussinessLogic.WebHost.Controllers
{
    public class MaCarrerasProfesionalesController : Controller
    {
        //
        // GET: /MaCarrerasProfesionales/

        private IRepository repository;

        public MaCarrerasProfesionalesController()
        {
            this.repository = new MaCarreraProfesionalBL();
        }
        public ActionResult _create()
        {
            return PartialView();
        }


        public ActionResult _listarCarrerasProfesional()
        {
            return PartialView(repository.GetAll<MA_CARRERA_PROFESIONALES>());
        }

        public ActionResult edit(int id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_edit", repository.GetById<MA_CARRERA_PROFESIONALES>(id));
            }
            else
            {
                return View(repository.GetById<MA_CARRERA_PROFESIONALES>(id));
            }
        }
        public ActionResult index()
        {
            ViewBag.lista = repository.GetAll<MA_CARRERA_PROFESIONALES>();
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
        public ActionResult edit(MA_CARRERA_PROFESIONALES model)
        {
            if (ModelState.IsValid)
            {
                if (repository.edit(model) > 0)
                {
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
        public ActionResult guardar(MA_CARRERA_PROFESIONALES entity)
        {
            return Json(repository.create(entity), JsonRequestBehavior.AllowGet);
        }
    }
}
