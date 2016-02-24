using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal.ViewModels;
using BussinessEntity;


namespace BussinessLogic.Interfaces
{
    public interface IPeopleJobs
    {
        SG_PERSONA_TRABAJO detallePersonaTrabajoId(int id);
        List<SG_PERSONA_TRABAJO> listPeopleJobs(string codPersona);
        int registrarPersonaTrabajos(SG_PERSONA_TRABAJO entity);
        int actualizarTrabajos(SG_PERSONA_TRABAJO entity);
        int deleteTrabajos(int id);

    }
}
