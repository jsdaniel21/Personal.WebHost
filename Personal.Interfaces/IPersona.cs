using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.ViewModels;
using BussinessEntity;

namespace BussinessLogic.Interfaces
{
    public interface IPersona
    {
        List<MA_TIPO_EMPLEADO> listarTipoEmpleado();
        int registrarCaracteristicas(RRHH_PERSONA entity);
        int deletePersonaIdentificacion(int tipoIdentificacion, string codPersona);
        List<RRHH_PERSONA_IDENTIFICACION> listarIdentificacionPersonal(string codPersona);
        int registrarIdentificacion(RRHH_PERSONA_IDENTIFICACION entity);
        List<MA_GRUPO_SANGUINEO> listarGrupoSanguineo();
        List<MA_SEXO> listarSexo();
        List<MA_ESTADO_CIVIL> listarEstadoCivil();
        RRHH_PERSONA caracteristicasPeople(string codPersona);
        int registrarImagen(SG_PERSONA_IMAGENE entity);
        int registrarEmpleado(RRHH_PERSONA entity);
        List<RRHH_PERSONA> queryEmployees(string vCodigoPersona, int iCodigoTipoEmpleado,int iCodigoTipoModalidad, int iCodigoInstitucion, string vCodigoGradoMilitar, int iCodigoSituacionMilitar,int iCodigoInstancia);
        dataPeopleForEmployeesVM dataPeopleForEmployees(string codPeople, string codTipoSistema, string username);
        List<MA_TIPO_IDENTIFICACION> listTypeIdentificacion();
        List<MA_TIPO_MODALIDAD> listTypeModality(int codTipoEmpleado);
        List<MA_INSTITUCION> listarInstitucionForTipo(int codTipoInstitucion, int codTipoEntidad);
        List<MA_SITUACION_MILITAR> listarSituacionMilitar();
    }
}
