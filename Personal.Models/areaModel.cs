using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Personal.Models
{
    public partial class areaModel
    {

        [Display(Name = "Area")]
        public string V_DES_FUNCIONES;

        [Display(Name = "Abrev.Area")]
        public string V_ABREV_FUNCIONES;

    }
}
