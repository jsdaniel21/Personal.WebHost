using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.DataAccess;
using Personal.ViewModels;
using BussinessEntity;
using BussinessLogic.Interfaces;


namespace BussinessLogic
{
    public class peopleDomicilioBL : IPeopleDomicilio
    {
     
        public int deleteDomiclio(int id)
        {
            return new peopleDomicilioDA().deleteDomiclio(id);
        }

        public int actualizarPersonaDomicilio(RRHH_PERSONA_DOMICILIO entity)
        {
            return new peopleDomicilioDA().actualizarPersonaDomicilio(entity);
        }
        public RRHH_PERSONA_DOMICILIO detalleDomicilioPersonaForID(int codPersonaDomicilio)
        {
            return new peopleDomicilioDA().detalleDomicilioPersonaForID(codPersonaDomicilio);
        }
        public int registrarDomicilio(RRHH_PERSONA_DOMICILIO entity)
        {
            return new peopleDomicilioDA().registrarDomicilio(entity);
        }
        public List<MA_DISTRITO> fillDistritoCb(int codPais, string codDepartamento, string codProvincia)
        {
            return new peopleDomicilioDA().fillDistritoCb(codPais, codDepartamento, codProvincia);
        }
        public List<MA_PROVINCIA> fillProvinciaCb(int codPais, string codDeprtamento)
        {
            return new peopleDomicilioDA().fillProvinciaCb(codPais, codDeprtamento);
        }
        public List<MA_TIPO_DOMICILIO> listarTipoDomicilio()
        {
            return new peopleDomicilioDA().listarTipoDomicilio();
        }
        public List<listDomicilioPersonaVM> listarDomicilioXpersona(string codPersona)
        {
            return new peopleDomicilioDA().listarDomicilioXpersona(codPersona);
        }

        public List<MA_DEPARTAMENTO> fillDepartamentoCb(int codPais)
        {
            return new peopleDomicilioDA().fillDepartamentoCb(codPais);
        }
    }
}
