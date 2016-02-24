using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

namespace Personal.ViewModels
{
    public class listDomicilioPersonaVM
    {
        public listDomicilioPersonaVM()
        {
            this.RRHH_PERSONA_DOMICILIO = new RRHH_PERSONA_DOMICILIO();
            this.MA_DISTRITO = new MA_DISTRITO();
            this.MA_DEPARTAMENTO = new MA_DEPARTAMENTO();
            this.MA_PROVINCIA = new MA_PROVINCIA();
            this.MA_PAI = new MA_PAI();
            this.MA_TIPO_DOMICILIO = new MA_TIPO_DOMICILIO();

        }
        public RRHH_PERSONA_DOMICILIO RRHH_PERSONA_DOMICILIO { get; set; }
        public MA_DISTRITO MA_DISTRITO { get; set; }
        public MA_DEPARTAMENTO MA_DEPARTAMENTO { get; set; }
        public MA_PROVINCIA MA_PROVINCIA { get; set; }
        public MA_PAI MA_PAI { get; set; }
        public MA_TIPO_DOMICILIO MA_TIPO_DOMICILIO { get; set; }
    }
}
