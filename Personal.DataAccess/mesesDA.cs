using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data;
using System.Data.Common;
using System.Configuration;
using BussinessEntity;
using Personal.ViewModels;

namespace Personal.DataAccess
{
    public class mesesDA
    {

        public List<MA_MESES> meses()
        {

            List<MA_MESES> list = new List<MA_MESES>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_LISTAR_MESES]");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_MESES entity = new MA_MESES();

                    entity.I_COD_MES = Convert.ToInt32(lee["I_COD_MES"].ToString());
                    entity.V_DES_MES = lee["V_DES_MES"].ToString();
                    list.Add(entity);
                }
            }
            return list;
        }
    }
}
