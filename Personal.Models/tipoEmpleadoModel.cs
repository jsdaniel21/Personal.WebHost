using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Personal.Models
{
    public partial class tipoEmpleadoModel
    {
        [Display(Name = "Tipo Empleado")]
        public string V_DES_TIPO_EMPLEADO { get; set; }
    }
}
