
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
    public class MaEstadoCivilController : Controller
    {
        //
        // GET: /MACargo/
        private IRepository repository;
        public MaEstadoCivilController()
        {
            this.repository = new MA_ESTADO_CIVILBL();
        }
        public ActionResult _create()
        {
            return PartialView();
        }

        public ActionResult _List()
        {
            return PartialView(repository.GetAll<MA_ESTADO_CIVIL>());
        }

        public ActionResult edit(int id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_edit", repository.GetById<MA_ESTADO_CIVIL>(id));
            }
            else
            {
                return View(repository.GetById<MA_ESTADO_CIVIL>(id));
            }
        }
        public ActionResult index()
        {
            ViewBag.lista = repository.GetAll<MA_ESTADO_CIVIL>();
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
        public ActionResult edit(MA_ESTADO_CIVIL model)
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
        public ActionResult guardar(MA_ESTADO_CIVIL entity)
        {
            return Json(repository.create(entity), JsonRequestBehavior.AllowGet);
        }
    }
}
