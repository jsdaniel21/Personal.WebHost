using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Personal.Models
{
    public partial class situacionMilitarModel
    {
        [Display(Name="Situacion Militar")]
        public int I_COD_SITUACION_MILITAR { get; set; }
    }
}
