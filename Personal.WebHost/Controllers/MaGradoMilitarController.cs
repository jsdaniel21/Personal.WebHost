using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic.Interfaces;
using BussinessEntity;
using BussinessLogic;
using Personal.Interfaces;

namespace BussinessLogic.WebHost.Controllers
{
    public class MaGradoMilitarController : Controller
    {
        //
        // GET: /MaGradoMilitar/
        private IPersona Ipersona;
        private IGradoMilitarRepository _IGradoMilitarRepository;
        public MaGradoMilitarController()
        {
            this._IGradoMilitarRepository = new MaGradMilitarBL();
            this.Ipersona = new personaBL();
        }
        public ActionResult _create()
        {
            ViewBag.institucion = new SelectList(Ipersona.listarInstitucionForTipo(2, 12), "I_COD_INSTITUCION", "V_DES_INSTITUCION");
            return PartialView();
        }
        public ActionResult edit(string id)
        {
            ViewBag.institucion = new SelectList(Ipersona.listarInstitucionForTipo(2, 12), "I_COD_INSTITUCION", "V_DES_INSTITUCION");

            if (Request.IsAjaxRequest())
            {
                return PartialView("_edit", _IGradoMilitarRepository.GetById<MA_GRADO_MILITAR>(id));
            }
            else
            {

                return View(_IGradoMilitarRepository.GetById<MA_GRADO_MILITAR>(id));
            }
        }
        [HttpPost]
        public ActionResult edit(MA_GRADO_MILITAR model)
        {
            if (ModelState.IsValid)
            {
                if (_IGradoMilitarRepository.edit(model) > 0)
                {
                    //is action buil an url but reditorroute redirection a route create an global asax
                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError("", "Ocurrrio un erro internamente comuniquese con la area de Sistemas con J.Salinas");
                    ViewBag.institucion = new SelectList(Ipersona.listarInstitucionForTipo(2, 12), "I_COD_INSTITUCION", "V_DES_INSTITUCION");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult delete(string id)
        {
            string msg = "";
            if (_IGradoMilitarRepository.delete(id) > 0)
                msg = "Se ha Eliminado COrrectamente";
            else
                msg = "ha ocurrido un error";
            return RedirectToAction("index");
        }

        public ActionResult index()
        {
            ViewBag.GetAll = _IGradoMilitarRepository.GetAll<MA_GRADO_MILITAR>();

            return View();
        }
        [HttpGet]
        public ActionResult listarGradoMilitarXinstitucion(int iCodigoInstitucion)
        {
            return Json(new SelectList(_IGradoMilitarRepository.listarGradoMilitarXinstitucion(iCodigoInstitucion, "s"), "C_COD_GRADO_MILITAR", "V_DES_GRADO"), JsonRequestBehavior.AllowGet);
        }
        public ActionResult _listarGradoMilitar()
        {
            return PartialView(_IGradoMilitarRepository.GetAll<MA_GRADO_MILITAR>());
        }
        [HttpPost]
        public ActionResult guardar(MA_GRADO_MILITAR model)
        {
            return Json(_IGradoMilitarRepository.create(model), JsonRequestBehavior.AllowGet);
        }
    }
}
