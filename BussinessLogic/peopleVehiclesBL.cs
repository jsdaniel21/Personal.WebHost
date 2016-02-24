using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Interfaces;
using Personal.ViewModels;
using BussinessLogic.DataAccess;

namespace BussinessLogic.BussinessLogic
{
    public class peopleVehiclesBL : IPeopleVehicles
    {
        public List<listPeopleVehiclesVM> listPeopleVehicles(string codPersona) {
            return new peopleVehiclesDA().listPeopleVehicles(codPersona);
        }
    }
}
