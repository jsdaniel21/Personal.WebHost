using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

namespace Personal.ViewModels
{
    public class CreatePeopleVM
    {
        public CreatePeopleVM()
        {
            //
            this.clsTypeModality = new MA_TIPO_MODALIDAD();
            this.clsPersona = new RRHH_PERSONA();
            this.clsInstitucion = new MA_INSTITUCION();
            this.clsGradeAcademic = new MA_GRADO_MILITAR();
            this.clsIdentificacion = new MA_TIPO_IDENTIFICACION();
            this.clsSituacionMilitar = new MA_SITUACION_MILITAR();
            this.clsInstancia = new MA_INSTANCIA();
            this.clsArea = new MA_AREA();
            this.clsCargo = new MA_CARGO();
            this.clsTipoEmpleado = new MA_TIPO_EMPLEADO();
            this.clsPersonaDetalle = new RRHH_PERSONA_DETALLE();
        }

        public MA_TIPO_MODALIDAD clsTypeModality;

        public RRHH_PERSONA_DETALLE clsPersonaDetalle;

        public RRHH_PERSONA clsPersona;

        public MA_INSTITUCION clsInstitucion;

        public MA_GRADO_MILITAR clsGradeAcademic;

        public MA_TIPO_IDENTIFICACION clsIdentificacion;

        public MA_SITUACION_MILITAR clsSituacionMilitar;

        public MA_INSTANCIA clsInstancia;

        public MA_AREA clsArea;

        public MA_CARGO clsCargo;

        public MA_TIPO_EMPLEADO clsTipoEmpleado;
    }
}
