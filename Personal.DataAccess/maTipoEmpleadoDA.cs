using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BussinessEntity;
using System.Configuration;


namespace Personal.DataAccess
{
    public class maTipoEmpleadoDA
    {

        private string cn = ConfigurationManager.AppSettings["conecion"];


        public List<MA_TIPO_EMPLEADO> getAll()
        {
            List<MA_TIPO_EMPLEADO> lista = new List<MA_TIPO_EMPLEADO>();

            Database db = DatabaseFactory.CreateDatabase(cn);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_TIPO_EMPLEADO_LISTAR_aCTIVOS]");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_TIPO_EMPLEADO model = new MA_TIPO_EMPLEADO();
                    model.I_COD_TIPO_EMPLEADO = Convert.ToInt32(lee["I_COD_TIPO_EMPLEADO"]);
                    model.V_DES_TIPO_EMPLEADO = lee["V_DES_TIPO_EMPLEADO"].ToString();      
                    lista.Add(model);
                    
                }
               
            }
            return lista;
        }
    }
}
