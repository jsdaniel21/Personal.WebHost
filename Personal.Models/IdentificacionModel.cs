using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Personal.Models
{
    public partial class IdentificacionModel
    {
        [Display(Name = "Tipo de identificacion")]
        public int I_COD_TIPO_IDENTIFICACION;

        [Display(Name = "N° Documento")]
        public int V_DES_TIPO_IDENTIFICACION;
    }
}
