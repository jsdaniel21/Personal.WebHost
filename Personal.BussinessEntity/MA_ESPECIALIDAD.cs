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

    [MetadataType(typeof(SpecialtyModel))]
    public partial class MA_ESPECIALIDAD
    {
        public MA_ESPECIALIDAD()
        {
            this.SG_PERSONA_ESTUDIOS = new HashSet<SG_PERSONA_ESTUDIOS>();
        }

        public int I_COD_ESPECIALIDAD { get; set; }
        public string V_DES_ESPECIALIDAD { get; set; }

        public string C_ACTIVO { get; set; }
        public virtual ICollection<SG_PERSONA_ESTUDIOS> SG_PERSONA_ESTUDIOS { get; set; }
    }
}
