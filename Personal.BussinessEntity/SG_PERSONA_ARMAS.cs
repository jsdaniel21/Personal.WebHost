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
    
    public partial class SG_PERSONA_ARMAS
    {
        public string C_COD_PERSONA { get; set; }
        public Nullable<int> I_COD_MARCA_ARMA { get; set; }
        public Nullable<int> I_COD_TIPO_ARMA { get; set; }
        public int I_COD_PERSONA_ARMAS { get; set; }
        public string V_NUM_ARMA { get; set; }
        public string V_LICENCIA { get; set; }
        public Nullable<System.DateTime> D_FEC_REGISTRO { get; set; }
        public Nullable<System.DateTime> D_FEC_BAJA { get; set; }
        public string C_ACTIVO { get; set; }
        public string V_CALIBRE { get; set; }
    
        public virtual MA_MARCA_ARMA MA_MARCA_ARMA { get; set; }
        public virtual MA_TIPO_ARMA MA_TIPO_ARMA { get; set; }
        public virtual RRHH_PERSONA RRHH_PERSONA { get; set; }
    }
}
