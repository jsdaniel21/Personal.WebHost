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
    
    public partial class MA_TIPO_ESTADO
    {
        public MA_TIPO_ESTADO()
        {
            this.PRV_USUARIO_ESTADO = new HashSet<PRV_USUARIO_ESTADO>();
        }
    
        public int I_COD_TIPO_ESTADO { get; set; }
        public string V_DES_TIPO_ESTADO { get; set; }
    
        public virtual ICollection<PRV_USUARIO_ESTADO> PRV_USUARIO_ESTADO { get; set; }
    }
}