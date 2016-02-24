using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.ViewModels;
using BussinessEntity;

namespace BussinessLogic.Interfaces
{
    public interface IPeopleStudies
    {
        int deleteEstudios(int id);
        int actualizarEstudios(SG_PERSONA_ESTUDIOS entity);
        List<SG_PERSONA_ESTUDIOS> listarPeopleStudies(string codPersona);
        List<MA_TIPO_INSTITUCION> listTypeForInstitutionEducational();
        List<MA_TIPO_ENTIDAD> listarTipoEntidad();
        List<MA_GRADO_ACADEMICO> listGradeAcademic();
        int registrarEstudios(SG_PERSONA_ESTUDIOS entity);
        List<MA_CARRERA_PROFESIONALES> listarCarrerasProfesionales();
        List<MA_ESPECIALIDAD> litarEspecialidad();
        SG_PERSONA_ESTUDIOS detalleEstudiosForID(int id);
    }
}
