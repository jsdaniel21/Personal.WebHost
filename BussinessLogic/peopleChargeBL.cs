using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.DataAccess;
using Personal.ViewModels;
using BussinessEntity;
using BussinessLogic.Interfaces;
using Personal.Interfaces;
namespace BussinessLogic.BussinessLogic
{
    public class peopleChargeBL : IPeopleCharge
    {
        public int actualizarCargoPrincipal(RRHH_PERSONA_CARGO entity) {
            return new peopleChargeDA().actualizarCargoPrincipal(entity);
        }
        public List<listarAreaCargoxPersonaVM> listarAreaCargoxPersona(string codPersona)
        {
            return new peopleChargeDA().listarAreaCargoxPersona(codPersona);
        }

        public int verifychargeActiveForPeople(string codPersona)
        {
            return new peopleChargeDA().verifychargeActiveForPeople(codPersona);
        }
        public listarAreaCargoxPersonaVM detailsChargeForPeople(int codPeopleCharge)
        {
            return new peopleChargeDA().detailsChargeForPeople(codPeopleCharge);
        }
        public DateTime anularChargeForPeople(int codCargo, string observacion)
        {
            return new peopleChargeDA().anularChargeForPeople(codCargo, observacion);
        }

        public int savePeopleCharge(RRHH_PERSONA_CARGO entity)
        {

            return new peopleChargeDA().savePeopleCharge(entity);
        }
  

        public List<MA_CARGO> listarCargo()
        {
            return new peopleChargeDA().listarCargo();
        }
    }
}
