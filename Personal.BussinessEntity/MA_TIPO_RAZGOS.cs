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
    
    public partial class MA_TIPO_RAZGOS
    {
        public MA_TIPO_RAZGOS()
        {
            this.MA_DETALLE_RAZGOS = new HashSet<MA_DETALLE_RAZGOS>();
        }
    
        public int I_COD_RAZGOS { get; set; }
        public string V_DES_RAZGOS { get; set; }
    
        public virtual ICollection<MA_DETALLE_RAZGOS> MA_DETALLE_RAZGOS { get; set; }
    }
}
