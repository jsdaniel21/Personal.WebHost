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
using Personal.BussinessEntity;


namespace Personal.DataAccess
{
    public class MaTipoDoumentoDA
    {
        public List<MA_TIPO_DOCUMENTO> ListarTipoDocumentos()
        {
            List<MA_TIPO_DOCUMENTO> lista = new List<MA_TIPO_DOCUMENTO>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_TIPO_DOCUMENTO_ACTIVOS");
            IDataReader lee = db.ExecuteReader(cmd);
            while (lee.Read())
            {

                MA_TIPO_DOCUMENTO model = new MA_TIPO_DOCUMENTO();
                model.I_COD_TIPO_DOCUMENTO = Convert.ToInt32(lee["I_COD_TIPO_DOCUMENTO"]);
                model.V_DES_TIPO_DOCUMENTO = lee["V_DES_TIPO_DOCUMENTO"].ToString();
                model.C_ACTIVO = lee["C_ACTIVO"].ToString();

                lista.Add(model);
            }

            return lista;
        }

        public MA_TIPO_DOCUMENTO BuscarTipoDocumentoPorCodigo(int? iCodigoTipoDocumento)
        {
            MA_TIPO_DOCUMENTO model = new MA_TIPO_DOCUMENTO();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_BUSCAR_TIPO_DOCUMENTO_X_CODIGO");
            db.AddInParameter(cmd, "I_COD_TIPO_DOCUMENTO", DbType.Int32, iCodigoTipoDocumento);
            IDataReader lee = db.ExecuteReader(cmd);
            if(lee.Read())
            {
                model.I_COD_TIPO_DOCUMENTO = Convert.ToInt32(lee["I_COD_TIPO_DOCUMENTO"]);
                model.V_DES_TIPO_DOCUMENTO = lee["V_DES_TIPO_DOCUMENTO"].ToString();
                model.C_ACTIVO = lee["C_ACTIVO"].ToString();
            }
            return model;
        }
    }
}
