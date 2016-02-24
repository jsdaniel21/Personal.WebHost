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
using BussinessEntity;



namespace BussinessLogic.WebHost.Controllers
{
    public class ViajesController : Controller
    {
        //
        // GET: /Viajes/
        private readonly IPeopleTravel peopleTravelRepository;

        public ViajesController()
            : this(new peopleTravelBL())
        {

        }

        public ViajesController(IPeopleTravel peopleTravelRepository)
        {
            this.peopleTravelRepository = peopleTravelRepository;
        }
        public ActionResult _listarViajes(string codPersona = null)
        {
            return PartialView(peopleTravelRepository.listPeopleTravel(codPersona));
        }

        public ActionResult _index(string codMenu)
        {
            ViewBag.codMenu = codMenu;
            return PartialView(peopleTravelRepository.listPeopleTravel(Request.QueryString["codPersona"]));
        }
        public ActionResult _edit(int codPeopleTravels)
        {
            return PartialView(peopleTravelRepository.DetailsPeopleTravel(codPeopleTravels));
        }
        public ActionResult _create()
        {
            return PartialView();
        }

        #region JSON

        public ActionResult listPais()
        {

            return Json(peopleTravelRepository.listPais(), JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult registerPeopleTravels(FormCollection form)
        {
            SG_PERSONA_VIAJES entity = this.entity(form);
            return Json(peopleTravelRepository.registerPeopleTravels(entity));

        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult updatePeopleTravels(FormCollection form)
        {
            var entity = this.entity(form);
            return Json(peopleTravelRepository.actualizarPeopleTravels(this.entity(form)), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult delete(int codPeopleTravels)
        {
            return Json(peopleTravelRepository.delete(codPeopleTravels), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region metodos
        public SG_PERSONA_VIAJES entity(FormCollection form)
        {
            SG_PERSONA_VIAJES entity = new SG_PERSONA_VIAJES();
            entity.I_COD_PAIS = Convert.ToInt32(form["clsPais.I_COD_PAIS"]);
            entity.C_COD_PERSONA = form["clsPeopleTravel.C_COD_PERSONA"];
            entity.I_AÑO = Convert.ToInt32(form["clsPeopleTravel.I_AÑO"]);
            entity.V_TIEMPO_PERMANENCIA = form["clsPeopleTravel.V_TIEMPO_PERMANENCIA"];
            entity.V_DES_MOTIVO = form["clsPeopleTravel.V_DES_MOTIVO"];
            entity.I_COD_PERSONA_VIAJES = Convert.ToInt32(form["clsPeopleTravel.I_COD_PERSONA_VIAJES"]);
            return entity;
        }


        #endregion
    }
}
