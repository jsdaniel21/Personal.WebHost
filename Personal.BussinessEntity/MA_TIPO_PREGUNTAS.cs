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
    
    public partial class MA_TIPO_PREGUNTAS
    {
        public MA_TIPO_PREGUNTAS()
        {
            this.MA_PREGUNTAS = new HashSet<MA_PREGUNTAS>();
        }
    
        public int I_COD_TIPO_PREGUNTAS { get; set; }
        public string V_DES_TIPO_PREGUNTAS { get; set; }
        public string C_ACTIVO { get; set; }
    
        public virtual ICollection<MA_PREGUNTAS> MA_PREGUNTAS { get; set; }
    }
}
