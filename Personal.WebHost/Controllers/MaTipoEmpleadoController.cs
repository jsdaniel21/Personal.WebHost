
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic.Interfaces;
using BussinessEntity;
using BussinessLogic;
using Personal.Interfaces;

namespace Personal.WebHost.Controllers
{
    public class MaTipoEmpleadoController : Controller
    {
        //
        // GET: /MaTipoEmpleado/
        private IMatipoEmpleadoRepository _IMatipoEmpleadoRepository;

        public MaTipoEmpleadoController()
        {
            _IMatipoEmpleadoRepository = new maTipoEmpleadoBL();
        }


        #region JSons

        [HttpGet]
        public JsonResult tipoEmpleados()
        {
            return Json(_IMatipoEmpleadoRepository.getAll(), JsonRequestBehavior.AllowGet);
        }


        #endregion

    }
}
