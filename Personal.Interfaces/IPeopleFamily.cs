using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.ViewModels;
using BussinessEntity;

namespace BussinessLogic.Interfaces
{
    public interface IPeopleFamily
    {
        List<listPeopleFamilyVM> listPeopleFamily(string codPersona);
        List<MA_TIPO_FAMILIAR> typeFamily();
    }
}
