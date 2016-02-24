using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Personal.Models
{


    public partial class personaModel
    {

        //por uqe se ase de esta manera esto se debe supongamos que tengo distinto proyectos
        // en los cuales llamand al mismo procedimiento almacenado pero aqui necesitamos darle otro nombre
        // no puedo cambiar el nombre directo del procedimiento almacenado por q afectaria todo los sistemas
        // donde este entones lo hago directamente del modelo

        [Display(Name = "Apellido Paterno")]
        public string V_APELLIDO_PATERNO;

        [Display(Name = "Apellido Materno")]
        public string V_APELLIDO_MATERNO;

        [Display(Name = "Nombres")]
        public string V_NOMBRES;

        [Display(Name = "Estado")]
        public string C_ACTIVO;
         

    }
}
