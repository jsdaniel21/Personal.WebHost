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
    public class RazgosController : Controller
    {
        //
        // GET: /Razgos/

        public ActionResult Index()
        {
            return View();
        }

    }
}
