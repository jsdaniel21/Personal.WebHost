   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

using System.Threading.Tasks;



namespace Personal.ViewModels
{
    public class StudiesPeopleVM
    {
        public StudiesPeopleVM() {
            this.clsTypeInstitution = new MA_TIPO_INSTITUCION();
            this.clsInstitution = new MA_INSTITUCION();
            this.clsSpecialty = new MA_ESPECIALIDAD();
            this.clsdegreeAcademic = new MA_GRADO_ACADEMICO();
            this.clsStudiesPeople = new SG_PERSONA_ESTUDIOS();
        }
        public MA_TIPO_INSTITUCION clsTypeInstitution;

        public MA_INSTITUCION clsInstitution;

           public MA_ESPECIALIDAD clsSpecialty;

        public MA_GRADO_ACADEMICO clsdegreeAcademic;

        public SG_PERSONA_ESTUDIOS clsStudiesPeople;

    }
}
