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
    
    public partial class PED_PEDIDO_PECOSA
    {
        public PED_PEDIDO_PECOSA()
        {
            this.PED_PECOSA_ESTADO = new HashSet<PED_PECOSA_ESTADO>();
        }
    
        public string C_COD_PEDIDO { get; set; }
        public string C_COD_PECOSA { get; set; }
    
        public virtual ICollection<PED_PECOSA_ESTADO> PED_PECOSA_ESTADO { get; set; }
        public virtual PED_PEDIDO_CABECERA PED_PEDIDO_CABECERA { get; set; }
    }
}
