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
    
    public partial class MA_MARCA_ARMA
    {
        public MA_MARCA_ARMA()
        {
            this.SG_PERSONA_ARMAS = new HashSet<SG_PERSONA_ARMAS>();
        }
    
        public int I_COD_MARCA_ARMA { get; set; }
        public string V_DES_MARCA_ARMA { get; set; }
        public string C_ACTIVO { get; set; }
    
        public virtual ICollection<SG_PERSONA_ARMAS> SG_PERSONA_ARMAS { get; set; }
    }
}
