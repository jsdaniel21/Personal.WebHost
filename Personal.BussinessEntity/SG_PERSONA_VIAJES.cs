//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BussinessEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class SG_PERSONA_VIAJES
    {
        public Nullable<int> I_COD_PAIS { get; set; }
        public string C_COD_PERSONA { get; set; }
        public int I_COD_PERSONA_VIAJES { get; set; }
        public Nullable<int> I_AÑO { get; set; }
        public string V_TIEMPO_PERMANENCIA { get; set; }
        public string V_DES_MOTIVO { get; set; }
        public Nullable<System.DateTime> D_FEC_REGISTRO { get; set; }
        public Nullable<System.DateTime> D_FEC_BAJA { get; set; }
        public string C_ACTIVO { get; set; }
    
        public virtual RRHH_PERSONA RRHH_PERSONA { get; set; }
    }
}
