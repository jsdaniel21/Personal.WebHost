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
    
    public partial class MA_MENU
    {
        public MA_MENU()
        {
            this.MA_MENU_SISTEMA = new HashSet<MA_MENU_SISTEMA>();
        }
    
        public string V_DES_MENU { get; set; }
        public string C_ACTIVO { get; set; }
        public string C_COD_MENU { get; set; }
    
        public virtual ICollection<MA_MENU_SISTEMA> MA_MENU_SISTEMA { get; set; }
    }
}