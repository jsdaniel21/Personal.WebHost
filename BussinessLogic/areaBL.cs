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
    public class areaBL : IArea
    {
        public List<areaForInstanciaVM> listarAreaForIsntancia(int codInstancia)
        {
            return new areaDA().listarAreaForIsntancia(codInstancia);

        }

    }
}
