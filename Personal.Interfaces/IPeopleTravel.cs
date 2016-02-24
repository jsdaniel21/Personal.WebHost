using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.ViewModels;
using BussinessEntity;

namespace BussinessLogic.Interfaces
{
    public interface IPeopleTravel
    {
        List<listTravelVM> listPeopleTravel(string codPersona);

        List<MA_PAI> listPais();

        int registerPeopleTravels(SG_PERSONA_VIAJES entity);

        listTravelVM DetailsPeopleTravel(int codpeopleTravels);

        int actualizarPeopleTravels(SG_PERSONA_VIAJES entity);
        int delete(int codPeopleTravels);

    }
}
