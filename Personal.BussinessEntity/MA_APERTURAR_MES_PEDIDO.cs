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
    
    public partial class MA_APERTURAR_MES_PEDIDO
    {
        public MA_APERTURAR_MES_PEDIDO()
        {
            this.PED_PEDIDO_CABECERA = new HashSet<PED_PEDIDO_CABECERA>();
            this.PED_CAB_VALE_RETIRO = new HashSet<PED_CAB_VALE_RETIRO>();
        }
    
        public string C_COD_TIPO_SISTEMA { get; set; }
        public Nullable<int> I_COD_AÑO { get; set; }
        public Nullable<int> I_COD_MES { get; set; }
        public string C_COD_APERTURAR_MES_PEDIDO { get; set; }
        public Nullable<System.DateTime> FEC_APERTURA { get; set; }
        public Nullable<System.DateTime> FEC_FINALIZACION { get; set; }
        public string C_ESTADO_APERTURA { get; set; }
    
        public virtual MA_APERTURAR_AÑOS MA_APERTURAR_AÑOS { get; set; }
        public virtual MA_MESES MA_MESES { get; set; }
        public virtual ICollection<PED_PEDIDO_CABECERA> PED_PEDIDO_CABECERA { get; set; }
        public virtual ICollection<PED_CAB_VALE_RETIRO> PED_CAB_VALE_RETIRO { get; set; }
    }
}