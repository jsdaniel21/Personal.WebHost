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
    
    public partial class MA_MODELO_VEHICULOS
    {
        public MA_MODELO_VEHICULOS()
        {
            this.SG_PERSONA_VEHICULOS = new HashSet<SG_PERSONA_VEHICULOS>();
        }
    
        public int I_COD_MODELO_VEHICULOS { get; set; }
        public string V_DES_MODELO_VEHICULOS { get; set; }
        public int I_COD_MARCA_VEHICULO { get; set; }
    
        public virtual MA_MARCA_VEHICULO MA_MARCA_VEHICULO { get; set; }
        public virtual ICollection<SG_PERSONA_VEHICULOS> SG_PERSONA_VEHICULOS { get; set; }
    }
}