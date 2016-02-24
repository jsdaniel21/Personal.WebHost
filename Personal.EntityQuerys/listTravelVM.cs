using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

namespace Personal.ViewModels
{
    public class listTravelVM
    {

        public listTravelVM() {

            this.clsPeopleTravel = new SG_PERSONA_VIAJE();
            this.clsPais = new MA_PAI();

        }

        public SG_PERSONA_VIAJE clsPeopleTravel;

        public MA_PAI clsPais;
    }
}
