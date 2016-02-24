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
    public class peopleFamilyBL : IPeopleFamily
    { 

        public List<listPeopleFamilyVM> listPeopleFamily(string codPersona) {
            return new peopleFamilyDA().listPeopleFamily(codPersona);
        }
        public List<MA_TIPO_FAMILIAR> typeFamily()
        {
            return new peopleFamilyDA().typeFamily();
        }
    }
}
