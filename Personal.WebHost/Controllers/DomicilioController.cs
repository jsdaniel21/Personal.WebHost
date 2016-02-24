using BussinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Spatial;
using BussinessLogic;
using BussinessLogic.BussinessLogic;
using BussinessEntity;

namespace BussinessLogic.WebHost.Controllers
{
    public class DomicilioController : Controller
    {
        private readonly IPeopleDomicilio IPeopleDomicilio;
        private readonly IPeopleTravel IPeopleTravel;
        //
        // GET: /Domicilio/

        public DomicilioController()
            : this(new peopleDomicilioBL(), new peopleTravelBL())
        {

        }
        public DomicilioController(IPeopleDomicilio IPeopleDomicilio, IPeopleTravel IPeopleTravel)
        {
            this.IPeopleDomicilio = IPeopleDomicilio;
            this.IPeopleTravel = IPeopleTravel;
        }

        /// <summary>
        /// JSON
        /// </summary>
        /// <param name="codMenu"></param>
        /// <returns></returns>


        public ActionResult fillDistritoCb(int codPais, string codDepartamento, string codProvincia)
        {
            return Json(new SelectList(IPeopleDomicilio.fillDistritoCb(codPais, codDepartamento, codProvincia), "C_COD_DISTRITO", "V_DES_DISTRITO"), JsonRequestBehavior.AllowGet);
        }
        public ActionResult fillProvinciaCb(int codPais, string codDepartamento)
        {
            return Json(new SelectList(IPeopleDomicilio.fillProvinciaCb(codPais, codDepartamento), "C_COD_PROVINCIA", "V_DES_PROVINCIA"), JsonRequestBehavior.AllowGet);
        }
        public ActionResult fillDepartamentoCb(int codPais)
        {
            return Json(new SelectList(IPeopleDomicilio.fillDepartamentoCb(codPais), "C_COD_DEPARTAMENTO", "V_DES_DEPARTAMENTO"), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// ACCIONES
        /// </summary>
        /// <returns></returns>
        public ActionResult _listarDomicilio(string codPersona)
        {
            return PartialView(IPeopleDomicilio.listarDomicilioXpersona(codPersona));
        }
        public ActionResult _create()
        {
            ViewBag.listarPais = new SelectList(IPeopleTravel.listPais(), "I_COD_PAIS", "V_DES_PAIS");
            ViewBag.listarTipoDomicilio = new SelectList(IPeopleDomicilio.listarTipoDomicilio(), "I_COD_TIPO_DOMICILIO", "V_DES_TIPO_DOMICILIO");

            return PartialView();
        }

        public ActionResult _update(int id)
        {
            var entity = IPeopleDomicilio.detalleDomicilioPersonaForID(id);

            ViewBag.listarPais = new SelectList(IPeopleTravel.listPais(), "I_COD_PAIS", "V_DES_PAIS");
            ViewBag.listarDepartamento = new SelectList(IPeopleDomicilio.fillDepartamentoCb(Convert.ToInt32(entity.I_COD_PAIS)), "C_COD_DEPARTAMENTO", "V_DES_DEPARTAMENTO");
            ViewBag.fillProvinciaCb = new SelectList(IPeopleDomicilio.fillProvinciaCb(Convert.ToInt32(entity.I_COD_PAIS), entity.C_COD_DEPARTAMENTO), "C_COD_PROVINCIA", "V_DES_PROVINCIA");
            ViewBag.fillDistritoCb = new SelectList(IPeopleDomicilio.fillDistritoCb(Convert.ToInt32(entity.I_COD_PAIS), entity.C_COD_DEPARTAMENTO, entity.C_COD_PROVINCIA), "C_COD_DISTRITO", "V_DES_DISTRITO");

            ViewBag.listarTipoDomicilio = new SelectList(IPeopleDomicilio.listarTipoDomicilio(), "I_COD_TIPO_DOMICILIO", "V_DES_TIPO_DOMICILIO");
            ViewBag.latitude = entity.V_GEO_LOCALIZACION.Latitude;
            ViewBag.longitude = entity.V_GEO_LOCALIZACION.Longitude;
            return PartialView(entity);
        }
        [HttpPost]
        public ActionResult _delete(int id)
        {
            return Json(IPeopleDomicilio.deleteDomiclio(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult _register(FormCollection form)
        {
            RRHH_PERSONA_DOMICILIO entity = new RRHH_PERSONA_DOMICILIO();
            entity.C_COD_PERSONA = form["codPersona"].ToString();
            entity.I_COD_PAIS = Convert.ToInt32(form["I_COD_PAIS"].ToString());
            entity.C_COD_DEPARTAMENTO = form["C_COD_DEPARTAMENTO"].ToString();
            entity.C_COD_PROVINCIA = form["C_COD_PROVINCIA"].ToString();
            entity.C_COD_DISTRITO = form["C_COD_DISTRITO"].ToString();
            entity.V_DES_DIRECCION = form["V_DES_DIRECCION"].ToString();
            entity.V_DES_URBANIZACION = form["V_DES_URBANIZACION"].ToString();
            entity.I_COD_TIPO_DOMICILIO = Convert.ToInt32(form["I_COD_TIPO_DOMICILIO"].ToString());
            entity.V_GEO_LOCALIZACION = DbGeography.FromText("POINT(" + form["longitude"] + " " + form["latitude"] + ")");
            var resultado = IPeopleDomicilio.registrarDomicilio(entity);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult _actualizar(FormCollection form)
        {
            RRHH_PERSONA_DOMICILIO entity = new RRHH_PERSONA_DOMICILIO();
            entity.I_COD_PERSONA_DOMICILIO = Convert.ToInt32(form["I_COD_PERSONA_DOMICILIO"].ToString());
            entity.C_COD_PERSONA = form["codPersona"].ToString();
            entity.I_COD_PAIS = Convert.ToInt32(form["I_COD_PAIS"].ToString());
            entity.C_COD_DEPARTAMENTO = form["C_COD_DEPARTAMENTO"].ToString();
            entity.C_COD_PROVINCIA = form["C_COD_PROVINCIA"].ToString();
            entity.C_COD_DISTRITO = form["C_COD_DISTRITO"].ToString();
            entity.V_DES_DIRECCION = form["V_DES_DIRECCION"].ToString();
            entity.V_DES_URBANIZACION = form["V_DES_URBANIZACION"].ToString();
            entity.I_COD_TIPO_DOMICILIO = Convert.ToInt32(form["I_COD_TIPO_DOMICILIO"].ToString());

            var resultado = IPeopleDomicilio.actualizarPersonaDomicilio(entity);
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }
        public ActionResult _index(string codMenu)
        {
            ViewBag.codMenu = codMenu;
            ViewBag.Model = IPeopleDomicilio.listarDomicilioXpersona(Request.QueryString["codPersona"]);
            ViewBag.codPersona = Request.QueryString["codPersona"];
            return PartialView();
        }

    }
}
