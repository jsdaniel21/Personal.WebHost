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

    public partial class MA_INSTANCIA_AREAS
    {
        public MA_INSTANCIA_AREAS()
        {
            this.PED_PEDIDO_CABECERA = new HashSet<PED_PEDIDO_CABECERA>();
            this.PED_CAB_VALE_RETIRO = new HashSet<PED_CAB_VALE_RETIRO>();
            this.PED_ARTICULO_AREAS = new HashSet<PED_ARTICULO_AREAS>();
            this.RRHH_PERSONA_CARGO = new HashSet<RRHH_PERSONA_CARGO>();
        }

        public string C_ACTIVO { get; set; }
        public string I_COD_INSTANCIA { get; set; }
        public string C_COD_AREA { get; set; }
        public string C_COD_AREA_SUPERIOR { get; set; }
        public Nullable<int> I_NIVEL_INSTANCIA_AREA { get; set; }

        public virtual MA_AREAS MA_AREAS { get; set; }
        public virtual MA_INSTANCIA MA_INSTANCIA { get; set; }
        public virtual ICollection<PED_PEDIDO_CABECERA> PED_PEDIDO_CABECERA { get; set; }
        public virtual ICollection<PED_CAB_VALE_RETIRO> PED_CAB_VALE_RETIRO { get; set; }
        public virtual ICollection<PED_ARTICULO_AREAS> PED_ARTICULO_AREAS { get; set; }
        public virtual ICollection<RRHH_PERSONA_CARGO> RRHH_PERSONA_CARGO { get; set; }
    }
}
