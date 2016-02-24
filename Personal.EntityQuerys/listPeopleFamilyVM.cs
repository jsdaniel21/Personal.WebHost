using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;


namespace Personal.ViewModels
{
    public class listPeopleFamilyVM
    {

        public listPeopleFamilyVM() {
            this.clsPeople = new RRHH_PERSONA();
            this.clsCabPeopleFamily = new SG_CAB_PERSONA_FAMILIAR();
            this.clsTypeFamily = new MA_TIPO_FAMILIAR();
            this.clsPeopleDetails = new RRHH_PERSONA_DETALLE();
            this.clsOccupation = new MA_OCUPACION();

        
        }


        public RRHH_PERSONA clsPeople;

        public SG_CAB_PERSONA_FAMILIAR clsCabPeopleFamily;

        public MA_TIPO_FAMILIAR clsTypeFamily;

        public RRHH_PERSONA_DETALLE clsPeopleDetails;

        public MA_OCUPACION clsOccupation;

    }
}
