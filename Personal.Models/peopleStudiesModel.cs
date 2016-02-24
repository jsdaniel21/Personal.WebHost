using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Personal.Models
{
    public partial class peopleStudiesModel
    {
        [Display(Name = "Año ingreso")]
        //[DataType(DataType.Currency)]
        public int I_AÑO_INGRESO;

        [Display(Name = "Año egreso")]
        public int I_AÑO_EGRESO;
    }
}
