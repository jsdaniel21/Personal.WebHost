using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.ViewModels;
using BussinessEntity;

namespace BussinessLogic.Interfaces
{
    public interface IPeopleDomicilio
    {
        int deleteDomiclio(int id);
        int actualizarPersonaDomicilio(RRHH_PERSONA_DOMICILIO entity);
        RRHH_PERSONA_DOMICILIO detalleDomicilioPersonaForID(int codPersonaDomicilio);
        List<MA_TIPO_DOMICILIO> listarTipoDomicilio();
        List<listDomicilioPersonaVM> listarDomicilioXpersona(string codPersona);
        List<MA_DEPARTAMENTO> fillDepartamentoCb(int codPais);
        List<MA_PROVINCIA> fillProvinciaCb(int codPais, string codDeprtamento);
        List<MA_DISTRITO> fillDistritoCb(int codPais, string codDepartamento, string codProvincia);
        int registrarDomicilio(RRHH_PERSONA_DOMICILIO entity);
    }
}
