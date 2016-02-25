using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.DataAccess;
using Personal.ViewModels;
using BussinessEntity;
using Personal.Interfaces;
 

namespace BussinessLogic
{
    public class personaBL : IPersona, IRptPersonalRepository
    {
        public List<MA_TIPO_EMPLEADO> listarTipoEmpleado()
        {
            return new personaDA().listarTipoEmpleado();
        }
        public int registrarCaracteristicas(RRHH_PERSONA entity)
        {
            return new personaDA().registrarCaracteristicas(entity);
        }
        public int deletePersonaIdentificacion(int tipoIdentificacion, string codPersona)
        {
            return new personaDA().deletePersonaIdentificacion(tipoIdentificacion, codPersona);
        }
        public List<RRHH_PERSONA_IDENTIFICACION> listarIdentificacionPersonal(string codPersona)
        {
            return new personaDA().listarIdentificacionPersonal(codPersona);
        }
        public int registrarIdentificacion(RRHH_PERSONA_IDENTIFICACION entity)
        {
            return new personaDA().registrarIdentificacion(entity);
        }
        public List<MA_GRUPO_SANGUINEO> listarGrupoSanguineo()
        {

            return new personaDA().listarGrupoSanguineo();
        }
        public List<MA_SEXO> listarSexo()
        {
            return new personaDA().listarSexo();
        }
        public List<MA_ESTADO_CIVIL> listarEstadoCivil()
        {
            return new personaDA().listarEstadoCivil();
        }
        public RRHH_PERSONA caracteristicasPeople(string codPersona)
        {
            return new personaDA().caracteristicasPeople(codPersona);
        }
        public int registrarImagen(SG_PERSONA_IMAGENE entity)
        {
            return new personaDA().registrarImagen(entity);
        }
        public int registrarEmpleado(RRHH_PERSONA entity)
        {
            return new personaDA().registrarEmpleado(entity);
        }
        public List<MA_SITUACION_MILITAR> listarSituacionMilitar()
        {
            return new personaDA().listarSituacionMilitar();
        }


        public List<MA_INSTITUCION> listarInstitucionForTipo(int codTipoInstitucion, int codTipoEntidad)
        {
            return new personaDA().listarInstitucionForTipo(codTipoInstitucion, codTipoEntidad);
        }
        public List<MA_TIPO_IDENTIFICACION> listTypeIdentificacion()
        {
            return new personaDA().listTypeIdentificacion();
        }
        public dataPeopleForEmployeesVM dataPeopleForEmployees(string codPeople, string codTipoSistema, string username)
        {
            return new personaDA().dataPeopleForEmployees(codPeople, codTipoSistema, username);
        }
        public List<MA_TIPO_MODALIDAD> listTypeModality(int codTipoEmpleado)
        {
            return new personaDA().listTypeModality(codTipoEmpleado);
        }


        public List<DetallePersonal> queryEmployees(string vCodigoPersona, int iCodigoTipoEmpleado, int iCodigoTipoModalidad, int iCodigoInstitucion, string vCodigoGradoMilitar, int iCodigoSituacionMilitar, int iCodigoInstancia, string cActivo)
        {
            return new personaDA().queryEmployees(vCodigoPersona, iCodigoTipoEmpleado, iCodigoTipoModalidad, iCodigoInstitucion, vCodigoGradoMilitar, iCodigoSituacionMilitar, iCodigoInstancia, cActivo);
        }

        public List<rptPersonalList> rptListarPersonal(int iCodigoTipoEmpleado, int iCodigoTipoModalidad, int iCodigoInstitucion, string vCodigoGradoMilitar, int iCodigoSituacionMilitar, int iCodigoInstancia, string cActivo)
        {
            return new personaDA().rptListarPersonal(iCodigoTipoEmpleado, iCodigoTipoModalidad, iCodigoInstitucion, vCodigoGradoMilitar, iCodigoSituacionMilitar, iCodigoInstancia,cActivo);
        }
    }
}
