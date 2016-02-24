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
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using System.Dynamic;
using BussinessLogic;
using System.Configuration;
using Personal.Interfaces;

namespace Personal.WebHost.Controllers
{
    public class MaInstitucionController : Controller
    {
        //
        // GET: /MaInstitucion/
        private IMaInstanciaRepository _IMaInstanciaRepository;
        public MaInstitucionController() {
            _IMaInstanciaRepository = new MaInstanciaBL();
        }
        public ActionResult listInstanciaForTypeInst(string typeInstitution)
        {
            return Json(_IMaInstanciaRepository.listInstanciaForTypeInst(typeInstitution), JsonRequestBehavior.AllowGet);

        }

    }
}
