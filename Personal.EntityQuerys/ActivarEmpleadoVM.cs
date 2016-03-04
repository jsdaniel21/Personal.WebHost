using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

namespace Personal.ViewModels
{
    public class ActivarEmpleadoVM
    {
        public ActivarEmpleadoVM()
        {
            this.modalidadesDelPersonal = new List<ModalidadPersonal>();
            this.tipoEmpleados = new List<MA_TIPO_EMPLEADO>();
            this.tipoModalidad = new List<MA_TIPO_MODALIDAD>();

            this.personaModalidad = new RRHH_PERSONA_MODALIDAD();
            this.personaCargos = new List<listarAreaCargoxPersonaVM>();
            this.personaGrado = new List<RRHH_PERSONA_GRADO>();

        }
        public listarAreaCargoxPersonaVM DefaultCargoPersonal
        {
            get { return new listarAreaCargoxPersonaVM(); }
        }
        public ModalidadPersonal DefaultModalidadPersonal
        {
            get { return new ModalidadPersonal(); }
        }
        public List<ModalidadPersonal> modalidadesDelPersonal { get; set; }
        public List<MA_TIPO_EMPLEADO> tipoEmpleados { get; set; }
        public List<MA_TIPO_MODALIDAD> tipoModalidad { get; set; }
        public RRHH_PERSONA_MODALIDAD personaModalidad { get; set; }
        public List<listarAreaCargoxPersonaVM> personaCargos { get; set; }
        public List<RRHH_PERSONA_GRADO> personaGrado { get; set; }
    }
}
