using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntity;

namespace Personal.ViewModels
{
    public class listPeopleJobsVM
    {
        public listPeopleJobsVM()
        {

            this.clsPeopleJobs = new SG_PERSONA_TRABAJO();
            this.clsPais = new MA_PAI();
            this.clsCharge = new MA_CARGO();
        }
        public SG_PERSONA_TRABAJO clsPeopleJobs;

        public MA_PAI clsPais;

        public MA_CARGO clsCharge;

    }
}
