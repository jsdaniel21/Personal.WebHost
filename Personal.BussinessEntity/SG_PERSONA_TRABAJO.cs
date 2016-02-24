using System;
using Personal.Models;
using System.ComponentModel.DataAnnotations;

namespace BussinessEntity
{
    [MetadataType(typeof(peopleJobsModel))]
    public class SG_PERSONA_TRABAJO
    {
        public SG_PERSONA_TRABAJO() {

            this.MA_CARGO = new MA_CARGO();
            this.RRHH_PERSONA = new RRHH_PERSONA();
            this.MA_PAIS = new MA_PAI();
        }
        public int I_COD_PERSONA_TRABAJOS { get; set; }
        public string C_COD_PERSONA { get; set; }
        public Nullable<int> I_AÑO { get; set; }
        public Nullable<System.DateTime> D_FEC_REGISTRO { get; set; }
        public string C_ACTIVO { get; set; }
        public Nullable<int> I_COD_CARGO { get; set; }
        public string V_DES_ENTIDAD { get; set; }
        public int I_COD_PAIS { get; set; }
        public virtual MA_CARGO MA_CARGO { get; set; }
        public virtual RRHH_PERSONA RRHH_PERSONA { get; set; }

        public virtual MA_PAI MA_PAIS { get; set; }

    }
}
