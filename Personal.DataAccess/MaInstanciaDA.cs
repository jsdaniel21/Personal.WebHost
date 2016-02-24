using BussinessEntity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.DataAccess
{
   public class MaInstanciaDA
    {
        public List<MA_INSTANCIA> listInstanciaForTypeInst(string typeInstitution)
        {
            List<MA_INSTANCIA> lista = new List<MA_INSTANCIA>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_LISTAR_INSTANCIAS_X_TIPO_INSTITUCION]");
            db.AddInParameter(cmd, "I_COD_TIPO_INSTITUCION", DbType.Int32, typeInstitution);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_INSTANCIA entity = new MA_INSTANCIA();
                    entity.I_COD_INSTANCIA = lee["I_COD_INSTANCIA"].ToString();
                    entity.I_COD_INSTANCIA_SUPERIOR = lee["I_COD_INSTANCIA_SUPERIOR"].ToString();
                    entity.V_DES_INSTANCIA = lee["V_DES_INSTANCIA"].ToString();

                    lista.Add(entity);
                }

            }

            return lista;
        }

    }
}
