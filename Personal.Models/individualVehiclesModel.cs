

namespace Personal.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    public class individualVehiclesModel
    {
        [Display(Name = "Placa")]
        public string V_DES_PLACA;
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string D_FEC_REGISTRO;
    }
}
