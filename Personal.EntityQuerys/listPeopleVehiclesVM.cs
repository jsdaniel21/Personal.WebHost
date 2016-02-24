using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

namespace Personal.ViewModels
{
    public class listPeopleVehiclesVM
    {
        public listPeopleVehiclesVM() {
            this.clsColor = new MA_COLOR();
            this.clsBrandVehicles = new MA_MARCA_VEHICULO();
            this.clsModelVehicles = new MA_MODELO_VEHICULOS();
            this.clsPeopleVehicles = new SG_PERSONA_VEHICULOS();

        }

        public MA_COLOR clsColor;

        public MA_MARCA_VEHICULO clsBrandVehicles;

        public MA_MODELO_VEHICULOS clsModelVehicles;

        public SG_PERSONA_VEHICULOS clsPeopleVehicles;
    }
}
