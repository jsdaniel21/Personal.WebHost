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
    public class FamiliaresController : Controller
    {
        //
        // GET: /Familiares/
        private readonly IPeopleFamily peopleFamilyRepository;

        public FamiliaresController()
            : this(new peopleFamilyBL())
        {

        }

        public FamiliaresController(IPeopleFamily peopleFamilyRepository)
        {
            this.peopleFamilyRepository = peopleFamilyRepository;
        }
     

        public ActionResult _index(string codMenu)
        {
            ViewBag.codMenu = codMenu;
            return PartialView(peopleFamilyRepository.listPeopleFamily("_codPersona"));
        }
 

        #region JSON
        public ActionResult typeFamily()
        {

            return Json(peopleFamilyRepository.typeFamily());
        }


        #endregion
    }
}
