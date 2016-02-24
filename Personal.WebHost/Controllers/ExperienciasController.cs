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
    public class ExperienciasController : Controller
    {
        //
        // GET: /Experiencias/
        private readonly IPeopleJobs peopleJobsRepository;
        private readonly IPeopleTravel IPeopleTravel;
        private readonly IPeopleCharge IPeopleCharge;
        public ExperienciasController()
            : this(new peopleJobsBL(), new peopleTravelBL(), new peopleChargeBL())
        {

        }
        public ExperienciasController(IPeopleJobs peopleJobsRepository, IPeopleTravel IPeopleTravel, IPeopleCharge IPeopleCharge)
        {
            this.peopleJobsRepository = peopleJobsRepository;
            this.IPeopleTravel = IPeopleTravel;
            this.IPeopleCharge = IPeopleCharge;
        }

        /// <summary>
        /// JSON
        /// </summary>
        /// <param name="peopleJobsRepository"></param>
        /// <param name="IPeopleTravel"></param>
        /// <param name="IPeopleCharge"></param>

        [HttpPost]
        public ActionResult _register(SG_PERSONA_TRABAJO model)
        {
            return Json(peopleJobsRepository.registrarPersonaTrabajos(model), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// ACCIONES
        /// </summary>
        /// <returns></returns>
        public ActionResult _index(string codMenu)
        {
            ViewBag.codMenu = codMenu;
            ViewBag.Model = peopleJobsRepository.listPeopleJobs(Request.QueryString["codPersona"]);
            ViewBag.codPersona = Request.QueryString["codPersona"];
            return PartialView();

        }
        public ActionResult _create()
        {
            ViewBag.listarPais = new SelectList(IPeopleTravel.listPais(), "I_COD_PAIS", "V_DES_PAIS");
            ViewBag.listCargo = new SelectList(IPeopleCharge.listarCargo(), "I_COD_CARGO", "V_DES_CARGO");

            return PartialView();
        }

        public ActionResult _Edit(int id)
        {
            ViewBag.listarPais = new SelectList(IPeopleTravel.listPais(), "I_COD_PAIS", "V_DES_PAIS");
            ViewBag.listCargo = new SelectList(IPeopleCharge.listarCargo(), "I_COD_CARGO", "V_DES_CARGO");
            return PartialView(peopleJobsRepository.detallePersonaTrabajoId(id));
        }
        [HttpPost]
        public ActionResult _actualizar(SG_PERSONA_TRABAJO model) {
            return Json(peopleJobsRepository.actualizarTrabajos(model), JsonRequestBehavior.AllowGet);
        }

        public ActionResult _delete(int id) {

            return Json(peopleJobsRepository.deleteTrabajos(id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult _listarExperiencias(string codPersona)
        {
            return PartialView("_listJobs", peopleJobsRepository.listPeopleJobs(codPersona));
        }

    }
}
