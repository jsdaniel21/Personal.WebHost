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
    
    public partial class MA_GRUPO_SANGUINEO
    {
        public MA_GRUPO_SANGUINEO()
        {
            this.RRHH_PERSONA_DETALLE = new HashSet<RRHH_PERSONA_DETALLE>();
        }
    
        public int I_COD_GRUPO_SANGUINEO { get; set; }
        public string V_DES_GRUPO_SANGUINEO { get; set; }
        public string C_ACTIVO { get; set; }
    
        public virtual ICollection<RRHH_PERSONA_DETALLE> RRHH_PERSONA_DETALLE { get; set; }
    }
}
