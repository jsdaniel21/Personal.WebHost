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
    using System.ComponentModel.DataAnnotations;
    using Personal.Models;
    using System.Collections.Generic;

    [MetadataType(typeof(occupationModel))]
    public partial class MA_OCUPACION
    {
        public MA_OCUPACION()
        {
            this.SG_DET_PERSONA_FAMILIAR = new HashSet<SG_DET_PERSONA_FAMILIAR>();
        }
    
        public int I_COD_OCUPACION { get; set; }
        public string V_DES_OCUPACION { get; set; }
        public string C_ACTIVO { get; set; }
    
        public virtual ICollection<SG_DET_PERSONA_FAMILIAR> SG_DET_PERSONA_FAMILIAR { get; set; }
    }
}
