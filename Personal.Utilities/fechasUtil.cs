using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Personal.Interfaces;
using BussinessLogic;
using BussinessEntity;

namespace Personal.Utilities
{
    public static class fechasUtil
    {
        public static IMesesRepository _IMesesRepository = new mesesBL();

        public static Dictionary<string, int> meses = new Dictionary<string, int>();
        public static List<int> dia=new List<int>();
        public static List<int> año=new List<int>();


        public static void initialize()
        {
            setMeses();
            setDia();
            setAño();
        }

        private static void setMeses()
        {
            var list = _IMesesRepository.getAll();

            foreach (var item in list)
            {
                meses.Add(item.V_DES_MES, Convert.ToInt32(item.I_COD_MES));
            }
        }

        private static void setDia()
        {
            for (int i = 1; i <= 31; i++)
            {
                dia.Add(i);
            }
        }

        private static void setAño()
        {

            for (int i = 1950; i <= DateTime.Now.Year; i++)
            {
                año.Add(i);
            }
        }
    }
}



