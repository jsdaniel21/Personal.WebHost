using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.DataAccess;
using Personal.ViewModels;
using BussinessEntity;
using BussinessLogic.Interfaces;

namespace BussinessLogic.BussinessLogic
{
    public class peopleTravelBL : IPeopleTravel
    {
        public List<listTravelVM> listPeopleTravel(string codPersona)
        {
            return new peopleTravelDA().listPeopleTravel(codPersona);
        }

        public List<MA_PAI> listPais()
        {
            return new peopleTravelDA().listPais();
        }

        public int registerPeopleTravels(SG_PERSONA_VIAJES entity)
        {
            return new peopleTravelDA().registerPeopleTravels(entity);
        }
        public listTravelVM DetailsPeopleTravel(int codpeopleTravels)
        {
            return new peopleTravelDA().DetailsPeopleTravel(codpeopleTravels);
        }
        public int actualizarPeopleTravels(SG_PERSONA_VIAJES entity)
        {
            return new peopleTravelDA().actualizarPeopleTravels(entity);
        }
        public int delete(int codPeopleTravels)
        {
            return new peopleTravelDA().delete(codPeopleTravels);
        }
    }
}
