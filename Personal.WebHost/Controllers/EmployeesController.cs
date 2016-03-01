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
using Personal.BussinessEntity;

using Personal.Interfaces;

namespace BussinessLogic.WebHost.Controllers
{
    public class EmployeesController : Controller
    {
        //
        // GET: /Employees/
        private readonly IPersona _IPersona;
        private readonly IPeopleModalidadRepository _IPeopleModalidadRepository;
        private readonly IPeopleDomicilio IPeopleDomicilio;
        private readonly IPeopleTravel IPeopleTravel;
        private readonly IMaInstanciaRepository _IMaInstanciaRepository;
        private readonly IMaTipoDocumentoRepository _IMaTipoDocumentoRepository;
        public EmployeesController()
            : this(new personaBL())
        {

        }
        public EmployeesController(IPersona personaRepository)
        {
            this._IPersona = personaRepository;
            this.IPeopleDomicilio = new peopleDomicilioBL();
            this.IPeopleTravel = new peopleTravelBL();
            this._IMaInstanciaRepository = new MaInstanciaBL();
            this._IMaTipoDocumentoRepository = new maTipoDocumentoBL();
            this._IPeopleModalidadRepository = new peopleModalidadBL();
        }
        /// <summary>
        /// ACCIONES
        /// </summary>
        /// <param name="codInstitucion"></param>
        /// <returns></returns>

        public ActionResult _DesactivarEmpleado(string codMenu, string codPersona)
        {
            ViewBag.codMenu = codMenu;
            var modalidadActual = _IPeopleModalidadRepository.ModalidadActualPersona(codPersona);

            DesactivarEmpleadoVM model = new DesactivarEmpleadoVM();
            model.tipoEmpleado.V_DES_TIPO_EMPLEADO = modalidadActual.tipoEmpleado.V_DES_TIPO_EMPLEADO;
            model.tipoModalidad.V_DES_TIPO_MODALIDA = modalidadActual.tipoModalidad.V_DES_TIPO_MODALIDA;
            model.tipoDocumento = _IMaTipoDocumentoRepository.GetAll<MA_TIPO_DOCUMENTO>();

            model.vTipoDocumeto = _IMaTipoDocumentoRepository.GetById<MA_TIPO_DOCUMENTO>(modalidadActual.personaModalidad.I_COD_TIPO_DOCUMENTO_INGRESO).V_DES_TIPO_DOCUMENTO;
            model.personaModalidad.I_COD_TIPO_DOCUMENTO_INGRESO = modalidadActual.personaModalidad.I_COD_TIPO_DOCUMENTO_INGRESO;
            model.personaModalidad.V_NRO_DOCUMENTO_INGRESO = modalidadActual.personaModalidad.V_NRO_DOCUMENTO_INGRESO;
            model.personaModalidad.D_FECHA_CONTRATO = modalidadActual.personaModalidad.D_FECHA_CONTRATO;
            model.personaModalidad.I_COD_TIPO_DOCUMENTO_CESE = modalidadActual.personaModalidad.I_COD_TIPO_DOCUMENTO_CESE;
            model.personaModalidad.V_NRO_DOCUMENTO_CESE = modalidadActual.personaModalidad.V_NRO_DOCUMENTO_CESE;
            model.personaModalidad.D_FECHA_SECE = modalidadActual.personaModalidad.D_FECHA_SECE;
            model.personaModalidad.V_MOTIVO_CESE_CONTRATO = modalidadActual.personaModalidad.V_MOTIVO_CESE_CONTRATO;
            model.personaModalidad.C_ACTIVO = modalidadActual.personaModalidad.C_ACTIVO;

            model.institucion.V_DES_INSTITUCION = modalidadActual.institucion.V_DES_INSTITUCION;
            model.gradoMilitar.V_DES_GRADO = modalidadActual.vDescripcionGrado;
            model.situacionMilitar = _IPersona.listarSituacionMilitar();
            model.personaGrado.I_COD_SITUACION_MILITAR = modalidadActual.situacionMilitar.I_COD_SITUACION_MILITAR;
            model.personaGrado.D_FECHA_BAJA = modalidadActual.personaGrado.D_FECHA_BAJA;
            model.personaGrado.V_OBSERVACION_ANULACION = modalidadActual.personaGrado.V_OBSERVACION_ANULACION;
            

            return PartialView(model);

        }
        public ActionResult _DetailsPeople(string codMenu, string codPersona)
        {
            var entity = _IPersona.caracteristicasPeople(codPersona);

            ViewBag.codMenu = codMenu;
            ViewBag.estadoCivil = new SelectList(_IPersona.listarEstadoCivil(), "I_COD_ESTADO_CIVIL", "V_DES_ESTADO_CIVIL", entity.RRHH_PERSONA_DETALLE.FirstOrDefault().I_COD_ESTADO_CIVIL);
            ViewBag.sexo = new SelectList(_IPersona.listarSexo(), "I_COD_SEXO", "V_DES_SEXO", entity.RRHH_PERSONA_DETALLE.FirstOrDefault().I_COD_SEXO);
            ViewBag.gruposanguineo = new SelectList(_IPersona.listarGrupoSanguineo(), "I_COD_GRUPO_SANGUINEO", "V_DES_GRUPO_SANGUINEO", entity.RRHH_PERSONA_DETALLE.FirstOrDefault().I_COD_GRUPO_SANGUINEO);
            ViewBag.pais = new SelectList(IPeopleTravel.listPais(), "I_COD_PAIS", "V_DES_PAIS", selectedValue: entity.RRHH_PERSONA_DETALLE.FirstOrDefault().I_COD_PAIS);
            ViewBag.departamento = new SelectList(IPeopleDomicilio.fillDepartamentoCb(Convert.ToInt32(entity.RRHH_PERSONA_DETALLE.FirstOrDefault().I_COD_PAIS)), "C_COD_DEPARTAMENTO", "V_DES_DEPARTAMENTO"
                , entity.RRHH_PERSONA_DETALLE.FirstOrDefault().C_COD_DEPARTAMENTO);
            ViewBag.provincia = new SelectList(IPeopleDomicilio.fillProvinciaCb(Convert.ToInt32(entity.RRHH_PERSONA_DETALLE.FirstOrDefault().I_COD_PAIS), entity.RRHH_PERSONA_DETALLE.FirstOrDefault().C_COD_DEPARTAMENTO)
                , "C_COD_PROVINCIA", "V_DES_PROVINCIA", entity.RRHH_PERSONA_DETALLE.FirstOrDefault().C_COD_PROVINCIA);
            ViewBag.distrito = new SelectList(IPeopleDomicilio.fillDistritoCb(Convert.ToInt32(entity.RRHH_PERSONA_DETALLE.FirstOrDefault().I_COD_PAIS)
                , entity.RRHH_PERSONA_DETALLE.FirstOrDefault().C_COD_DEPARTAMENTO
                , entity.RRHH_PERSONA_DETALLE.FirstOrDefault().C_COD_PROVINCIA)
                , "C_COD_DISTRITO", "V_DES_DISTRITO", entity.RRHH_PERSONA_DETALLE.FirstOrDefault().C_COD_DISTRITO);
            ViewBag.tipoEmpleado = new SelectList(_IPersona.listarTipoEmpleado(), "I_COD_TIPO_EMPLEADO", "V_DES_TIPO_EMPLEADO", entity.RRHH_PERSONA_MODALIDAD.FirstOrDefault().MA_TIPO_MODALIDAD.I_COD_TIPO_EMPLEADO);
            ViewBag.modalidad = new SelectList(_IPersona.listTypeModality(entity.RRHH_PERSONA_MODALIDAD.FirstOrDefault().MA_TIPO_MODALIDAD.I_COD_TIPO_EMPLEADO), "I_COD_TIPO_MODALIDAD", "V_DES_TIPO_MODALIDA", entity.RRHH_PERSONA_MODALIDAD.FirstOrDefault().I_COD_TIPO_MODALIDAD);
            ViewBag.typeIdentificacion = new SelectList(_IPersona.listTypeIdentificacion(), "I_COD_TIPO_IDENTIFICACION", "V_ABREV_IDENTIFICACION");

            //retornar una vista parcial de una parte de la pagina
            return PartialView(entity);
        }
        public ActionResult Index()
        {
            string vCodigoPersona = vCodigoPersona = User.Identity.Name.ToString().ToLower().Contains(ConfigurationManager.AppSettings["userMaster"].ToLower()) ? "PERS00000000001" : "";
            ViewBag.institucion = new SelectList(_IPersona.listarInstitucionForTipo(2, 12), "I_COD_INSTITUCION", "V_DES_INSTITUCION");
            ViewBag.situacionMilitar = new SelectList(_IPersona.listarSituacionMilitar(), "I_COD_SITUACION_MILITAR", "V_DES_TIPO_SITUACION");
            ViewBag.instanciaPorTipoInstitucion = new SelectList(_IMaInstanciaRepository.listInstanciaForTypeInst("1"), "I_COD_INSTANCIA", "V_DES_INSTANCIA");


            return View(_IPersona.queryEmployees(vCodigoPersona, 0, 0, 0, "", 0, 0, "S"));
        }

        public ActionResult Avatar(string codPersona, string codTipoSistema)
        {
            //_codPersona
            return View(_IPersona.dataPeopleForEmployees(codPersona, codTipoSistema, User.Identity.Name));
        }

        public ActionResult _Create()
        {
            ViewBag.situacionMilitar = new SelectList(_IPersona.listarSituacionMilitar(), "I_COD_SITUACION_MILITAR", "V_DES_TIPO_SITUACION");
            ViewBag.typeIdentificacion = new SelectList(_IPersona.listTypeIdentificacion(), "I_COD_TIPO_IDENTIFICACION", "V_ABREV_IDENTIFICACION");
            ViewBag.institucion = new SelectList(_IPersona.listarInstitucionForTipo(2, 12), "I_COD_INSTITUCION", "V_DES_INSTITUCION");
            ViewBag.tipoEmpleado = new SelectList(_IPersona.listarTipoEmpleado(), "I_COD_TIPO_EMPLEADO", "V_DES_TIPO_EMPLEADO");
            return PartialView();
        }

        [HttpPost]
        public ActionResult saveEmployees(FormCollection form, string IICdentificacion)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            var IICdentificacionPARSE = jsSerializer.Deserialize<List<RRHH_PERSONA_IDENTIFICACION>>(IICdentificacion);
            //var BoolGrade = Convert.ToBoolean(form["boolGrade"].ToString());

            RRHH_PERSONA entity = new RRHH_PERSONA();
            entity.V_NOMBRES = form["clsPersona.V_NOMBRES"].ToString().ToUpper();
            entity.V_APELLIDO_PATERNO = form["clsPersona.V_APELLIDO_PATERNO"].ToString().ToUpper();
            entity.V_APELLIDO_MATERNO = form["clsPersona.V_APELLIDO_MATERNO"].ToString().ToUpper();
            //if (BoolGrade == true)
            entity.RRHH_PERSONA_MODALIDAD.Add(new RRHH_PERSONA_MODALIDAD { I_COD_TIPO_MODALIDAD = Convert.ToInt32(form["clsTypeModality.I_COD_TIPO_MODALIDAD"].ToString()) });
            entity.RRHH_PERSONA_IDENTIFICACION = IICdentificacionPARSE;
            entity.RRHH_PERSONA_GRADO.Add(new RRHH_PERSONA_GRADO
            {
                I_COD_INSTITUCION = form["clsInstitucion.I_COD_INSTITUCION"] == "" ? null : (int?)Convert.ToInt32(form["clsInstitucion.I_COD_INSTITUCION"])
                ,
                C_COD_GRADO_MILITAR = form["C_COD_GRADO_MILITAR"].ToString() == "" ? null : form["C_COD_GRADO_MILITAR"].ToString()
                ,
                I_COD_SITUACION_MILITAR = form["clsSituacionMilitar.I_COD_SITUACION_MILITAR"].ToString() == "" ? null : (int?)Convert.ToInt32(form["clsSituacionMilitar.I_COD_SITUACION_MILITAR"].ToString())
            });
            entity.RRHH_PERSONA_CARGO.Add(new RRHH_PERSONA_CARGO
            {
                I_COD_INSTANCIA = form["Instancia"].ToString(),
                C_COD_AREA = form["Area"].ToString(),
                I_COD_CARGO = Convert.ToInt32(form["Cargo"]),
                V_OBSERVACION_INGRESO = form["clsPeopleCharge.V_OBSERVACION_INGRESO"].ToString(),
                D_FEC_INGRESO = Convert.ToDateTime(form["iDia"].ToString() + "/" + form["iMes"].ToString() + "/" + form["iAno"].ToString())
            });

            return Json(_IPersona.registrarEmpleado(entity), JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// JSON
        /// </summary>
        /// <param name="codInstitucion"></param>
        /// <returns></returns>
        #region Json
        [HttpPost]
        public ActionResult desactivarEmpleado(string vCodigoPersona, string vTipoBaja, string vFechaCese, string vTexto,
            int iCodigoTipoEmpleado,
            string vDescricionTipoEmpleado,
            string vDescripcionTipoDocumentoCese,
            string vNumeroDocumenCese,
            int iCodigoTipoDocumentoCese)
        {

            return Json(_IPeopleModalidadRepository.DesactivarPersonal(vCodigoPersona, vTipoBaja, Convert.ToDateTime(vFechaCese), vTexto, iCodigoTipoEmpleado, vDescricionTipoEmpleado, vDescripcionTipoDocumentoCese, vNumeroDocumenCese,iCodigoTipoDocumentoCese)
                , JsonRequestBehavior.AllowGet);
        }
        public ActionResult personaIdentificacion(RRHH_PERSONA_IDENTIFICACION entity, string op)
        {
            var count = 0;
            if (op == "el")
            {
                count = _IPersona.deletePersonaIdentificacion(Convert.ToInt32(entity.I_COD_TIPO_IDENTIFICACION), entity.C_COD_PERSONA);
            }
            else if (op == "srv" || op == "loc")
            {
                count = _IPersona.registrarIdentificacion(entity);
            }
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listTypeModality(int codTipoEmpleado)
        {
            return Json(new SelectList(_IPersona.listTypeModality(codTipoEmpleado), "I_COD_TIPO_MODALIDAD", "V_DES_TIPO_MODALIDA"), JsonRequestBehavior.AllowGet);
        }
        public ActionResult listTypeIdentificacion()
        {
            return Json(_IPersona.listTypeIdentificacion(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarIdentificacionPersonal(string codPersona)
        {
            return Json(_IPersona.listarIdentificacionPersonal(codPersona), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult registrarCaracteristicas(FormCollection form)
        {
            return Json(_IPersona.registrarCaracteristicas(personaEntity(form)), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult empleados(int iCodigoTipoEmpleado, int iCodigoTipoModalidad, int iCodigoInstitucion, string vCodigoGradoMilitar, int iCodigoSituacionMilitar, int iCodigoInstancia, string cActivo)
        {
            return Json(_IPersona.queryEmployees(User.Identity.Name.ToString().ToLower().Contains(ConfigurationManager.AppSettings["userMaster"].ToLower()) ? "" : "PERS00000000001",
                iCodigoTipoEmpleado,
                iCodigoTipoModalidad,
                iCodigoInstitucion,
                vCodigoGradoMilitar,
                iCodigoSituacionMilitar,
                iCodigoInstancia,
                cActivo
                )
                , JsonRequestBehavior.AllowGet);
        }

        #endregion

        public RRHH_PERSONA personaEntity(FormCollection form)
        {
            var entity = new RRHH_PERSONA();
            entity.C_COD_PERSONA = form["C_COD_PERSONA"].ToString();
            entity.V_APELLIDO_PATERNO = form["V_APELLIDO_PATERNO"].ToString();
            entity.V_APELLIDO_MATERNO = form["V_APELLIDO_MATERNO"].ToString();
            entity.V_NOMBRES = form["V_NOMBRES"].ToString();
            entity.C_ACTIVO = "s";
            entity.RRHH_PERSONA_MODALIDAD.Add(new RRHH_PERSONA_MODALIDAD { I_COD_TIPO_MODALIDAD = form["I_COD_TIPO_MODALIDAD"].ToString() == "" ? null : (int?)Convert.ToInt32(form["I_COD_TIPO_MODALIDAD"].ToString()) });
            entity.RRHH_PERSONA_DETALLE.Add(new RRHH_PERSONA_DETALLE
            {
                I_COD_PAIS = converIntNull(form["I_COD_PAIS"]),
                C_COD_DEPARTAMENTO = converStrNull(form["C_COD_DEPARTAMENTO"].ToString()),
                C_COD_PROVINCIA = converStrNull(form["C_COD_PROVINCIA"].ToString()),
                C_COD_DISTRITO = converStrNull(form["C_COD_DISTRITO"].ToString()),
                D_FEC_NACIMIENTO = form["D_FEC_NACIMIENTO"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(form["D_FEC_NACIMIENTO"].ToString()),
                I_COD_ESTADO_CIVIL = converIntNull(form["I_COD_ESTADO_CIVIL"]),
                I_COD_SEXO = converIntNull(form["I_COD_SEXO"].ToString()),
                I_COD_GRUPO_SANGUINEO = converIntNull(form["I_COD_GRUPO_SANGUINEO"].ToString()),
                I_PESO = converIntNull(form["I_PESO"].ToString()),
                DE_TALLA = Convert.ToDecimal(form["DE_TALLA"].ToString())
            });

            return entity;
        }

        public int converIntNull(string val)
        {
            if (val == "")
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(val);
            }
        }
        public string converStrNull(string val)
        {
            if (val == "")
            {
                return null;
            }
            else
            {
                return val;
            }
        }
    }
}
