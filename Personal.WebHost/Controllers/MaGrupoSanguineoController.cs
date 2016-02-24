
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic.Interfaces;
using BussinessEntity;
using BussinessLogic;


namespace Personal.WebHost.Controllers
{
    public class MaGrupoSanguineoController : Controller
    {
        //
        // GET: /MaGrupoSanguineo/
        private IRepository repository;
        public MaGrupoSanguineoController()
        {
            this.repository = new MA_GRUPO_SANGUINEOBL();
        }
        public ActionResult _create()
        {
            return PartialView();
        }

        public ActionResult _List()
        {
            return PartialView(repository.GetAll<MA_GRUPO_SANGUINEO>());
        }

        public ActionResult edit(int id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_edit", repository.GetById<MA_GRUPO_SANGUINEO>(id));
            }
            else
            {
                return View(repository.GetById<MA_GRUPO_SANGUINEO>(id));
            }
        }
        public ActionResult index()
        {
            ViewBag.lista = repository.GetAll<MA_GRUPO_SANGUINEO>();
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
        public ActionResult edit(MA_GRUPO_SANGUINEO model)
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
        public ActionResult guardar(MA_GRUPO_SANGUINEO entity)
        {
            return Json(repository.create(entity), JsonRequestBehavior.AllowGet);
        }

    }
}
