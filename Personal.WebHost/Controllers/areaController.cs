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
    public class areaController : Controller
    {
        //
        // GET: /area/
        private readonly IArea areaRepository;

        public areaController()
            : this(new areaBL())
        {
        }

        public areaController(IArea areaRepository)
        {
            this.areaRepository = areaRepository;
        }


        public ActionResult listarAreaForIsntancia(int codInstancia)
        {
            return Json(areaRepository.listarAreaForIsntancia(codInstancia), JsonRequestBehavior.AllowGet);

        }

    }
}
