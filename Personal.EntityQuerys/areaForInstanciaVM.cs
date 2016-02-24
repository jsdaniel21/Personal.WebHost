using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

namespace Personal.ViewModels
{
    public class areaForInstanciaVM
    {
        public areaForInstanciaVM()
        {
            this.clsArea = new MA_AREA();
            this.clsInstanciaArea = new MA_INSTANCIA_AREA();

        }
        public MA_AREA clsArea;

        public MA_INSTANCIA_AREA clsInstanciaArea;

    }
}
