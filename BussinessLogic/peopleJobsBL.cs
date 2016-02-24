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
    public class peopleJobsBL : IPeopleJobs
    {
        public SG_PERSONA_TRABAJO detallePersonaTrabajoId(int id)
        {

            return new peopleJobsDA().detallePersonaTrabajoId(id);
        }
        public List<SG_PERSONA_TRABAJO> listPeopleJobs(string codPersona)
        {
            return new peopleJobsDA().listPeopleJobs(codPersona);
        }

        public int registrarPersonaTrabajos(SG_PERSONA_TRABAJO entity)
        {

            return new peopleJobsDA().registrarPersonaTrabajos(entity);
        }
        public int actualizarTrabajos(SG_PERSONA_TRABAJO entity)
        {
            return new peopleJobsDA().actualizarTrabajos(entity);
        }
        public int deleteTrabajos(int id)
        {
            return new peopleJobsDA().deleteTrabajos(id);
        }

    }
}
