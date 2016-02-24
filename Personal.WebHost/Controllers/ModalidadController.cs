using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic.BussinessLogic;
using BussinessLogic.Interfaces;
using BussinessLogic;
using BussinessEntity;
using Personal.Interfaces;

namespace BussinessLogic.WebHost.Controllers
{
    public class ModalidadController : Controller
    {
        //
        // GET: /Modalidad/

        private IMaTipoModalidadRepository _IMaTipoModalidadRepository;

        public ModalidadController()
        {
            _IMaTipoModalidadRepository = new tipoModalidadBL();
        }


        public ActionResult _create()
        {

            return PartialView();
        }


        public ActionResult _List()
        {
            return PartialView(_IMaTipoModalidadRepository.GetAll<MA_TIPO_MODALIDAD>());
        }

        public ActionResult edit(int id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_edit", _IMaTipoModalidadRepository.GetById<MA_TIPO_MODALIDAD>(id));
            }
            else
            {
                return View(_IMaTipoModalidadRepository.GetById<MA_TIPO_MODALIDAD>(id));
            }
        }
        public ActionResult index()
        {
            ViewBag.lista = _IMaTipoModalidadRepository.GetAll<MA_TIPO_MODALIDAD>();
            return View();
        }
        public ActionResult delete(int id)
        {
            string msg = "";
            if (_IMaTipoModalidadRepository.delete(id) > 0)
                msg = "Se ha Eliminado COrrectamente";
            else
                msg = "ha ocurrido un error";
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult edit(MA_TIPO_MODALIDAD model)
        {
            if (ModelState.IsValid)
            {
                if (_IMaTipoModalidadRepository.edit(model) > 0)
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

        #region Json
        [HttpPost]
        public ActionResult guardar(MA_TIPO_MODALIDAD model)
        {
            return Json(_IMaTipoModalidadRepository.create(model), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult tipoModalidadPorTipoEmpleado(int iCodigoTipoEmpleado)
        {
            return Json(new SelectList(_IMaTipoModalidadRepository.tipoModalidadPorTipoEmpleado(iCodigoTipoEmpleado), "I_COD_TIPO_MODALIDAD", "V_DES_TIPO_MODALIDA"), JsonRequestBehavior.AllowGet);
        }

        #endregion




    }
}
