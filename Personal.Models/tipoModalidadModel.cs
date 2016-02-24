using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Personal.Models
{

    public partial class tipoModalidadModel
    {
        [Display(Name = "Modalidad")]
        public string V_DES_TIPO_MODALIDA;

        [Display(Name = "Estado")]
        public string C_ACTIVO;
    }
}
