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
    
    public partial class MA_TIPO_SEÑALES
    {
        public MA_TIPO_SEÑALES()
        {
            this.SG_PERSONA_SEÑALES = new HashSet<SG_PERSONA_SEÑALES>();
        }
    
        public int I_COD_TIPO_SEÑALES { get; set; }
        public string V_DES_TIPO_SEÑALES { get; set; }
        public string C_ACTIVO { get; set; }
    
        public virtual ICollection<SG_PERSONA_SEÑALES> SG_PERSONA_SEÑALES { get; set; }
    }
}
