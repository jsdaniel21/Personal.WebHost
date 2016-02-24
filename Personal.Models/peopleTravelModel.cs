using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Personal.Models
{
    public partial class peopleTravelModel
    {
        [Display(Name="Año")]
        public int I_AÑO;

        [Display(Name="Tiempo permanenecia")]
        public int V_TIEMPO_PERMANENCIA;

        [Display(Name="Motivo")]
        public int V_DES_MOTIVO;
    }
}
