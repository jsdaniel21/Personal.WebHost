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
    public class PertenenciasController : Controller
    {
        //
        // GET: /Pertenencias/
        private readonly IPeopleVehicles PeopleVehiclesRepository;

        public PertenenciasController()
            : this(new peopleVehiclesBL())
        {

        }

        public PertenenciasController(IPeopleVehicles PeopleVehiclesRepository)
        {
            this.PeopleVehiclesRepository = PeopleVehiclesRepository;
        }
        public ActionResult _listPeopleVehicles()
        {

            return PartialView(PeopleVehiclesRepository.listPeopleVehicles("_codPersona"));
        }

    }
}
