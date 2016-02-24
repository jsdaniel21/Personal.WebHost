using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Interfaces;
using Personal.ViewModels;
using BussinessLogic.DataAccess;
using BussinessEntity;

namespace BussinessLogic.BussinessLogic
{
    public class peopleStudiesBL : IPeopleStudies
    {
        public int deleteEstudios(int id)
        {
            return new peopleStudiesDA().deleteEstudios(id);
        }
        public int actualizarEstudios(SG_PERSONA_ESTUDIOS entity)
        {
            return new peopleStudiesDA().actualizarEstudios(entity);
        }
        public SG_PERSONA_ESTUDIOS detalleEstudiosForID(int id)
        {
            return new peopleStudiesDA().detalleEstudiosForID(id);
        }
        public List<MA_ESPECIALIDAD> litarEspecialidad()
        {
            return new peopleStudiesDA().litarEspecialidad();
        }
        public List<MA_CARRERA_PROFESIONALES> listarCarrerasProfesionales()
        {
            return new peopleStudiesDA().listarCarrerasProfesionales();
        }
        public List<MA_GRADO_ACADEMICO> listGradeAcademic()
        {

            return new peopleStudiesDA().listGradeAcademic();
        }
        public List<SG_PERSONA_ESTUDIOS> listarPeopleStudies(string codPersona)
        {
            return new peopleStudiesDA().listarPeopleStudies(codPersona);
        }

        public List<MA_TIPO_INSTITUCION> listTypeForInstitutionEducational()
        {
            return new peopleStudiesDA().listTypeForInstitutionEducational();
        }

        public List<MA_TIPO_ENTIDAD> listarTipoEntidad()
        {
            return new peopleStudiesDA().listarTipoEntidad();
        }
        public int registrarEstudios(SG_PERSONA_ESTUDIOS entity)
        {
            return new peopleStudiesDA().registrarEstudios(entity);
        }
        //public List<MA_INSTITUCION> listInstitutionEducational(int TypeInstitution)
        //{
        //    return new peopleStudiesDA().listInstitutionEducational(TypeInstitution);
        //}

        //public List<MA_TIPO_ESPECIALIDAD> listTypeSpecialty()
        //{
        //    return new peopleStudiesDA().listTypeSpecialty();
        //}

        //public List<MA_INSTITUCION_ESPECIALIDAD> listSpecialtyEducationalForType(int typeSpecialty, int institution)
        //{
        //    return new peopleStudiesDA().listSpecialtyEducationalForType(typeSpecialty, institution);
        //}

        //public List<MA_ESPECIALIDAD> listSpecialty()
        //{
        //    return new peopleStudiesDA().listSpecialty();

        //}

        //public List<MA_GRADO_ACADEMICO> listGradeAcademic()
        //{
        //    return new peopleStudiesDA().listGradeAcademic();
        //}

        //public int registerPeopleStudies(SG_PERSONA_ESTUDIOS entity)
        //{
        //    return new peopleStudiesDA().registerPeopleStudies(entity);
        //}

        //public int editPeopleStudies(SG_PERSONA_ESTUDIOS entity)
        //{
        //    return new peopleStudiesDA().editPeopleStudies(entity);
        //}
        //public int deleteStudiespeople(int codStudiespeople)
        //{
        //    return new peopleStudiesDA().deleteStudiespeople(codStudiespeople);
        //}
    }
}
