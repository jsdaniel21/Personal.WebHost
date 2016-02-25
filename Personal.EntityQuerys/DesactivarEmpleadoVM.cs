using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BussinessEntity;
using Personal.BussinessEntity;

namespace Personal.ViewModels
{
    public class DesactivarEmpleadoVM
    {
        public DesactivarEmpleadoVM()
        {

            this.tipoEmpleado = new MA_TIPO_EMPLEADO();
            this.tipoModalidad = new MA_TIPO_MODALIDAD();
            this.personaModalidad = new RRHH_PERSONA_MODALIDAD();
            this.situacionMilitar = new List<MA_SITUACION_MILITAR>();
            this.tipoDocumento = new List<MA_TIPO_DOCUMENTO>();
            this.institucion = new MA_INSTITUCION();
            this.gradoMilitar = new MA_GRADO_MILITAR();
            this.personaGrado = new RRHH_PERSONA_GRADO();
        }
        public MA_TIPO_EMPLEADO tipoEmpleado { get; set; }
        public MA_TIPO_MODALIDAD tipoModalidad { get; set; }
        public RRHH_PERSONA_MODALIDAD personaModalidad { get; set; }
        public MA_INSTITUCION institucion { get; set; }
        public MA_GRADO_MILITAR gradoMilitar { get; set; }
        public RRHH_PERSONA_GRADO personaGrado { get; set; }
        public List<MA_SITUACION_MILITAR> situacionMilitar { get; set; }
        public List<MA_TIPO_DOCUMENTO> tipoDocumento { get; set; }

    }
}
