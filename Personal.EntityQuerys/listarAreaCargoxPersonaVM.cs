using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;
namespace Personal.ViewModels
{
    public class listarAreaCargoxPersonaVM
    {
        public listarAreaCargoxPersonaVM()
        {
            this.clsPeopleCharge = new RRHH_PERSONA_CARGO();

            this.clsInstancia = new MA_INSTANCIA();

            this.clsArea = new MA_AREA();

            this.clsCargo = new MA_CARGO();

        }

        public RRHH_PERSONA_CARGO clsPeopleCharge;

        public MA_INSTANCIA clsInstancia;

        public MA_AREA clsArea;

        public MA_CARGO clsCargo;

         
        public int iDia { get; set; }
        public int iMes { get; set; }
        public int iAño { get; set; }


    }
}
