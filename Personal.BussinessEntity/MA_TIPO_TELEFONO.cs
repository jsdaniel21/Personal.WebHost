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
    
    public partial class MA_TIPO_TELEFONO
    {
        public MA_TIPO_TELEFONO()
        {
            this.RRHH_PERSONA_TELEFONO = new HashSet<RRHH_PERSONA_TELEFONO>();
        }
    
        public int I_COD_TELEFONO { get; set; }
        public string V_DES_TELEFONO { get; set; }
        public string C_ACTIVO { get; set; }
    
        public virtual ICollection<RRHH_PERSONA_TELEFONO> RRHH_PERSONA_TELEFONO { get; set; }
    }
}
