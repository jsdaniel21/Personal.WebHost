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
    using System.ComponentModel.DataAnnotations;
    using Personal.Models;

    [MetadataType(typeof(IdentificacionModel))]
    public partial class MA_TIPO_IDENTIFICACION
    {
        public MA_TIPO_IDENTIFICACION()
        {
            this.RRHH_PERSONA_IDENTIFICACION = new HashSet<RRHH_PERSONA_IDENTIFICACION>();
        }
    
        public int I_COD_TIPO_IDENTIFICACION { get; set; }
        public string V_DES_TIPO_IDENTIFICACION { get; set; }
        public string C_ACTIVO { get; set; }
        public string V_ABREV_IDENTIFICACION { get; set; }
    
        public virtual ICollection<RRHH_PERSONA_IDENTIFICACION> RRHH_PERSONA_IDENTIFICACION { get; set; }
    }
}
