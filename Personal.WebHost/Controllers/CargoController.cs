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
using System.Data.Spatial;

using BussinessEntity;


namespace BussinessLogic.WebHost.Controllers
{
    public class CargoController : Controller
    {
        //
        // GET: /Cargo/
        private readonly IPeopleCharge personaChargeRepository;

        public CargoController()
            : this(new peopleChargeBL())
        {

        }

        public ActionResult Details(int codPeopleCharge)
        {
            var entity = personaChargeRepository.detailsChargeForPeople(codPeopleCharge);
            //ViewBag.latitude = entity.clsInstancia.V_GEO_LOCALIZACION.Latitude;
            //ViewBag.longitude = entity.clsInstancia.V_GEO_LOCALIZACION.Longitude;
            ViewBag.latitude = 0;
            ViewBag.longitude = 0;
            return PartialView(entity);
        }
        public CargoController(IPeopleCharge personaChargeRepository)
        {
            this.personaChargeRepository = personaChargeRepository;
        }

        //este de aca es por defecto metodo GET pasand las variable por la URL
        public ActionResult _listarCargos(string codMenu, string codPersona)
        {
            ViewBag.codMenu = codMenu;
            return PartialView(personaChargeRepository.listarAreaCargoxPersona(codPersona));
        }

        public ActionResult _crear()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();

            }
            else
            {
                return View();
            }
        }

        #region JSONTRANSACTION
        //EL VERBO ES OBLIGATORIO PARA CADA TRANSACION
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult savePeopleCharge(RRHH_PERSONA_CARGO entity)
        {
            return Json(personaChargeRepository.savePeopleCharge(entity), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult actualizarCargoPrincipal(string codPersona, int codPersonaCargo)
        {
            RRHH_PERSONA_CARGO entity = new RRHH_PERSONA_CARGO { C_COD_PERSONA = codPersona, I_COD_PERSONA_CARGO = codPersonaCargo };
            return Json(personaChargeRepository.actualizarCargoPrincipal(entity), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region JSON
    
        public ActionResult verifychargeActiveForPeople(string codPersona)
        {
            return Json(personaChargeRepository.verifychargeActiveForPeople(codPersona), JsonRequestBehavior.AllowGet);
        }

        public ActionResult anularChargeForPeople(int codCargo, string observacion)
        {
            return Json(personaChargeRepository.anularChargeForPeople(codCargo, observacion), JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarCargosMaster()
        {
            return Json(personaChargeRepository.listarCargo(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult _listarChargePeople(string codPersona)
        {
            return Json(personaChargeRepository.listarAreaCargoxPersona(codPersona), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// BORRAME
        /// </summary>
        /// <param name="codPeopleCharge"></param>
        /// <returns></returns>
        public ActionResult detailsChargeForPeople(int codPeopleCharge)
        {
            return Json(personaChargeRepository.detailsChargeForPeople(codPeopleCharge), JsonRequestBehavior.AllowGet);
        }
        #endregion




    }
}
