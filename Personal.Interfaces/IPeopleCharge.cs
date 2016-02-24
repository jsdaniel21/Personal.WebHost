using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.ViewModels;
using BussinessEntity;

namespace BussinessLogic.Interfaces
{
    public interface IPeopleCharge
    {
        List<listarAreaCargoxPersonaVM> listarAreaCargoxPersona(string codPersona);
        int verifychargeActiveForPeople(string codPersona);
        DateTime anularChargeForPeople(int codCargo, string observacion);
        int savePeopleCharge(RRHH_PERSONA_CARGO entity);

        List<MA_CARGO> listarCargo();
        listarAreaCargoxPersonaVM detailsChargeForPeople(int codPeopleCharge);
        int actualizarCargoPrincipal(RRHH_PERSONA_CARGO entity);
    }
}
