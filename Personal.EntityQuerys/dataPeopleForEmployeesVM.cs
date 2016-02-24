using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

namespace Personal.ViewModels
{
    public class dataPeopleForEmployeesVM
    {
        //construxtor que se ejecutara cuando se haga una referencia a esta clase de entity queryes
        public dataPeopleForEmployeesVM()
        {
            this.clsPeople = new RRHH_PERSONA();
            this.clsPeopleIMG = new SG_PERSONA_IMAGENE();
            this.clsPeopleIdentification = new RRHH_PERSONA_IDENTIFICACION();
            this.clsPeopleModalidad = new RRHH_PERSONA_MODALIDAD();
            this.clsTipoModalidad = new MA_TIPO_MODALIDAD();
            this.clsGradoMilitar = new MA_GRADO_MILITAR();
            this.clsPeopleDetails = new RRHH_PERSONA_DETALLE();
            this.clsEstadoCivil = new MA_ESTADO_CIVIL();
            this.clsCargo = new MA_CARGO();
            this.clsMainstanciaArea = new MA_INSTANCIA_AREA();
            this.clsMaArea = new MA_AREA();
            this.clsPermisosUserVM = new List<listarPermisosUsuarioVM>();

        }

        public RRHH_PERSONA clsPeople;

        public SG_PERSONA_IMAGENE clsPeopleIMG;

        public RRHH_PERSONA_IDENTIFICACION clsPeopleIdentification;

        public RRHH_PERSONA_MODALIDAD clsPeopleModalidad;

        public MA_TIPO_MODALIDAD clsTipoModalidad;

        public MA_GRADO_MILITAR clsGradoMilitar;

        public RRHH_PERSONA_DETALLE clsPeopleDetails;

        public MA_ESTADO_CIVIL clsEstadoCivil;

        public MA_CARGO clsCargo;

        public MA_INSTANCIA_AREA clsMainstanciaArea;

        public MA_AREA clsMaArea;

        public List<listarPermisosUsuarioVM> clsPermisosUserVM;
    }
}
