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
    [MetadataType(typeof(personaModalidadModel))]
    public partial class RRHH_PERSONA_MODALIDAD
    {
        public string C_COD_PERSONA { get; set; }
        public Nullable<int> I_COD_TIPO_MODALIDAD { get; set; }
        public int I_COD_PERSONA_MODALIDAD { get; set; }
        public Nullable<System.DateTime> D_FECHA_CONTRATO { get; set; }
        public Nullable<System.DateTime> D_FECHA_SECE { get; set; }
        public string C_ACTIVO { get; set; }
        public string V_MOTIVO_CESE_CONTRATO { get; set; }
        public string V_NRO_DOCUMENTO_INGRESO { get; set; }
        public string V_NRO_DOCUMENTO_CESE { get; set; }
        public string V_OBSERVACION_INGRESO { get; set; }
        public int? I_COD_TIPO_DOCUMENTO_INGRESO { get; set; }
        public int? I_COD_TIPO_DOCUMENTO_CESE { get; set; }
        public virtual MA_TIPO_MODALIDAD MA_TIPO_MODALIDAD { get; set; }
        public virtual RRHH_PERSONA RRHH_PERSONA { get; set; }
    }
}
