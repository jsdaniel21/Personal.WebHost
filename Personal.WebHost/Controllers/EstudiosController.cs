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
using System.Runtime.Caching;
using Personal.Interfaces;


namespace BussinessLogic.WebHost.Controllers
{
    public class EstudiosController : Controller
    {
        //
        // GET: /Estudios/

        private readonly IPeopleStudies peopleStudiesRepository;

        private readonly IPersona IPersona;
        public EstudiosController()
            : this(new peopleStudiesBL())
        {
            this.IPersona = new personaBL();

        }
        public EstudiosController(IPeopleStudies peopleStudiesRepository)
        {
            this.peopleStudiesRepository = peopleStudiesRepository;
        }
        /// <summary>
        /// Acciones
        /// </summary>
        /// <param name="codMenu"></param>
        /// <returns></returns>
        public ActionResult _index(string codMenu)
        {
            ViewBag.codMenu = codMenu;
            ViewBag.estudios = peopleStudiesRepository.listarPeopleStudies(Request.QueryString["codPersona"].ToString());

            return PartialView();
        }

        public ActionResult _crear()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.tipoInstitucion = new SelectList(peopleStudiesRepository.listTypeForInstitutionEducational(), "I_COD_TIPO_INSTITUCION", "V_DES_TIPO_INSTITUCION");
                ViewBag.gradoAcademido = new SelectList(peopleStudiesRepository.listGradeAcademic(), "C_COD_GRADO_ACADEMICO", "V_DES_GRADO_ACADEMICO");
                return PartialView();

            }
            else
            {
                return PartialView();
            }
        }

        public ActionResult _details(int id)
        {
            var entity = peopleStudiesRepository.detalleEstudiosForID(id);
            return PartialView(entity);
        }
        public ActionResult _edit(int id)
        {
            var entity = peopleStudiesRepository.detalleEstudiosForID(id);
            ViewBag.tipoInstitucion = new SelectList(peopleStudiesRepository.listTypeForInstitutionEducational(), "I_COD_TIPO_INSTITUCION", "V_DES_TIPO_INSTITUCION");
            ViewBag.gradoAcademido = new SelectList(peopleStudiesRepository.listGradeAcademic(), "C_COD_GRADO_ACADEMICO", "V_DES_GRADO_ACADEMICO");
            ViewBag.tipoentidad = new SelectList(peopleStudiesRepository.listarTipoEntidad(), "I_COD_TIPO_ENTIDAD", "V_DES_ENTIDAD");
            ViewBag.institucion = new SelectList(IPersona.listarInstitucionForTipo(Convert.ToInt32(entity.MA_INSTITUCION.I_COD_TIPO_INSTITUCION), entity.MA_INSTITUCION.I_COD_TIPO_ENTIDAD), "I_COD_INSTITUCION", "V_DES_INSTITUCION");

            return PartialView(entity);
        }


        public ActionResult _listStudies(string codPersona)
        {
            return PartialView(peopleStudiesRepository.listarPeopleStudies(codPersona));
        }


        //public ActionResult _edit(int codStudiesPeople)
        //{
        //    return PartialView(peopleStudiesRepository.detailsStudiesPeople(codStudiesPeople));
        //}



        #region JSON

        public ActionResult _delete(int id)
        {
            return Json(peopleStudiesRepository.deleteEstudios(id), JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult _actualizar(SG_PERSONA_ESTUDIOS model)
        {
            return Json(peopleStudiesRepository.actualizarEstudios(model), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult _register(SG_PERSONA_ESTUDIOS model)
        {
            return Json(peopleStudiesRepository.registrarEstudios(model), JsonRequestBehavior.AllowGet);
        }
        public ActionResult listarTipoEntidad()
        {
            return Json(new SelectList(peopleStudiesRepository.listarTipoEntidad(), "I_COD_TIPO_ENTIDAD", "V_DES_ENTIDAD"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarEspecialidad(string buscar)
        {
            ObjectCache cache = MemoryCache.Default;
            var lista = new List<MA_ESPECIALIDAD>();
            if (cache.Get("dataListEsp") == null)
            {
                lista = peopleStudiesRepository.litarEspecialidad();
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.Priority = CacheItemPriority.Default;
                cache.Add("dataListEsp", lista, policy);
            }
            else
            {
                lista = (List<MA_ESPECIALIDAD>)cache.Get("dataListEsp");
            }
            return Json(lista.AsParallel().Where(x => x.V_DES_ESPECIALIDAD.ToUpper().Contains(buscar.ToUpper())), JsonRequestBehavior.AllowGet);
        }
        public ActionResult listarCarrerasProfesionales(string buscar)
        {
            ObjectCache cache = MemoryCache.Default;
            //Create a custom Timeout of 10 seconds
            var lista = new List<MA_CARRERA_PROFESIONALES>();
            if (cache.Get("dataListCar") == null)
            {
                lista = peopleStudiesRepository.listarCarrerasProfesionales();
                CacheItemPolicy policy = new CacheItemPolicy();
                // policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30.0);
                policy.Priority = CacheItemPriority.Default;
                cache.Add("dataListCar", lista, policy);
            }
            else
            {
                lista = (List<MA_CARRERA_PROFESIONALES>)cache.Get("dataListCar");
            }


            return Json(lista.AsParallel().Where(x => x.V_DES_CARRERA_PROFESIONAL.ToUpper().Contains(buscar.ToUpper())), JsonRequestBehavior.AllowGet);
        }
        public ActionResult listarInstituciones(int codTipoInstitucion, int codTipoEntidad)
        {

            return Json(new SelectList(IPersona.listarInstitucionForTipo(codTipoInstitucion, codTipoEntidad), "I_COD_INSTITUCION", "V_DES_INSTITUCION"), JsonRequestBehavior.AllowGet);

        }
        //public ActionResult listTypeForInstitutionEducational()
        //{
        //    return Json(peopleStudiesRepository.listTypeForInstitutionEducational(), JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult listInstitutionEducational(int TypeInstitution)
        //{
        //    return Json(peopleStudiesRepository.listInstitutionEducational(TypeInstitution), JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult listTypeSpecialty()
        //{
        //    return Json(peopleStudiesRepository.listTypeSpecialty(), JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult listSpecialtyEducationalForType(int typeSpecialty, int institution)
        //{
        //    return Json(peopleStudiesRepository.listSpecialtyEducationalForType(typeSpecialty, institution));
        //}

        //public ActionResult listSpecialty()
        //{
        //    return Json(peopleStudiesRepository.listSpecialty(), JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult listGradeAcademic()
        //{
        //    return Json(peopleStudiesRepository.listGradeAcademic(), JsonRequestBehavior.AllowGet);
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult registerPeopleStudies(FormCollection form)
        //{
        //    SG_PERSONA_ESTUDIOS entity = new SG_PERSONA_ESTUDIOS();
        //    entity.C_COD_INSTITUCION_ESPECIALIDAD = Convert.ToInt32(form["clsSpecialtyEducational.C_COD_ESPECIALIDAD_EDUCATIVA"]);
        //    entity.I_COD_ESPECIALIDAD = Convert.ToInt32(form["clsSpecialty.I_COD_ESPECIALIDAD"]);
        //    entity.C_COD_GRADO_ACADEMICO = Convert.ToInt32(form["clsdegreeAcademic.C_COD_GRADO_ACADEMICO"].ToString());
        //    entity.I_AÑO_INGRESO = Convert.ToInt32(form["clsStudiesPeople.I_AÑO_INGRESO"].ToString());
        //    entity.I_AÑO_EGRESO = Convert.ToInt32(form["clsStudiesPeople.I_AÑO_EGRESO"].ToString());
        //    entity.C_COD_PERSONA = form["clsStudiesPeople.C_COD_PERSONA"].ToString();
        //    return Json(peopleStudiesRepository.registerPeopleStudies(entity));
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult editPeopleStudies(FormCollection form)
        //{
        //    SG_PERSONA_ESTUDIOS entity = new SG_PERSONA_ESTUDIOS();
        //    entity.I_COD_PERSONA_ESTUDIOS = Convert.ToInt32(form["clsStudiesPeople.I_COD_PERSONA_ESTUDIOS"]);
        //    entity.C_COD_INSTITUCION_ESPECIALIDAD = Convert.ToInt32(form["clsInstitutionSpecialty.C_COD_INSTITUCION_ESPECIALIDAD"]);
        //    entity.I_COD_ESPECIALIDAD = Convert.ToInt32(form["clsSpecialty.I_COD_ESPECIALIDAD"]);
        //    entity.C_COD_GRADO_ACADEMICO = Convert.ToInt32(form["clsdegreeAcademic.C_COD_GRADO_ACADEMICO"].ToString());
        //    entity.I_AÑO_INGRESO = Convert.ToInt32(form["clsStudiesPeople.I_AÑO_INGRESO"].ToString());
        //    entity.I_AÑO_EGRESO = Convert.ToInt32(form["clsStudiesPeople.I_AÑO_EGRESO"].ToString());
        //    entity.C_COD_PERSONA = form["clsStudiesPeople.C_COD_PERSONA"].ToString();
        //    return Json(peopleStudiesRepository.editPeopleStudies(entity));

        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult deleteStudiespeople(int codStudiespeople)
        //{
        //    return Json(peopleStudiesRepository.deleteStudiespeople(codStudiespeople));
        //}
        public ActionResult listarPeopleStudies(string codPersona)
        {

            return Json(peopleStudiesRepository.listarPeopleStudies(codPersona));
        }

        #endregion
    }
}
