using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Personal.ViewModels;
using System.Configuration;
using System.Data.Common;
using System.Data;
using BussinessEntity;

namespace BussinessLogic.DataAccess
{
    public class peopleJobsDA
    {

        public SG_PERSONA_TRABAJO detallePersonaTrabajoId(int id)
        {
            SG_PERSONA_TRABAJO entity = new SG_PERSONA_TRABAJO();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_DETALLE_PERSONA_TRABAJO_X_ID");
            db.AddInParameter(cmd, "I_COD_PERSONA_TRABAJOS", DbType.Int32, id);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.I_COD_PERSONA_TRABAJOS = Convert.ToInt32(lee["I_COD_PERSONA_TRABAJOS"]);
                entity.I_COD_PAIS = Convert.ToInt32(lee["I_COD_PAIS"]);
                entity.V_DES_ENTIDAD = lee["V_DES_ENTIDAD"].ToString();
                entity.I_AÑO = Convert.ToInt32(lee["I_AÑO"]);
                entity.I_COD_CARGO = Convert.ToInt32(lee["I_COD_CARGO"]);

            }
            return entity;

        }
        public List<SG_PERSONA_TRABAJO> listPeopleJobs(string codPersona)
        {
            List<SG_PERSONA_TRABAJO> lista = new List<SG_PERSONA_TRABAJO>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("SG_SP_LISTAR_TRABAJOS_X_PERSONA");
            db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, codPersona);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    SG_PERSONA_TRABAJO entity = new SG_PERSONA_TRABAJO();
                    entity.I_COD_PERSONA_TRABAJOS = Convert.ToInt32(lee["I_COD_PERSONA_TRABAJOS"]);
                    entity.I_AÑO = Convert.ToInt32(lee["I_AÑO"]);
                    entity.MA_PAIS.V_DES_PAIS = lee["V_DES_PAIS"].ToString();
                    entity.V_DES_ENTIDAD = lee["V_DES_ENTIDAD"].ToString();
                    entity.MA_CARGO.V_DES_CARGO = lee["V_DES_CARGO"].ToString();
                    entity.C_ACTIVO = lee["C_ACTIVO"].ToString();
                    lista.Add(entity);
                }

            }

            return lista;

        }

        public int registrarPersonaTrabajos(SG_PERSONA_TRABAJO entity)
        {
            int resultado = 0;
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();
                using (DbTransaction trans = cone.BeginTransaction())
                {

                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_REGISTRAR_PERSONA_TRABAJOS");
                        db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, entity.C_COD_PERSONA);
                        db.AddInParameter(cmd, "I_COD_PAIS", DbType.Int32, entity.I_COD_PAIS);
                        db.AddInParameter(cmd, "I_AÑO", DbType.Int32, entity.I_AÑO);
                        db.AddInParameter(cmd, "I_COD_CARGO", DbType.Int32, entity.I_COD_CARGO);
                        db.AddInParameter(cmd, "V_DES_ENTIDAD", DbType.String, entity.V_DES_ENTIDAD);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                    finally
                    {
                        if (cone.State == ConnectionState.Open)
                        {
                            cone.Close();
                        }

                    }

                }
                return resultado;

            }
        }


        public int actualizarTrabajos(SG_PERSONA_TRABAJO entity)
        {

            int resultado = 0;
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);

            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();
                using (DbTransaction trans = cone.BeginTransaction())
                {

                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_ACTUALIZAR_PERSONA_TRABAJOS");
                        db.AddInParameter(cmd, "I_COD_PERSONA_TRABAJOS", DbType.Int32, entity.I_COD_PERSONA_TRABAJOS);
                        db.AddInParameter(cmd, "I_COD_PAIS", DbType.Int32, entity.I_COD_PAIS);
                        db.AddInParameter(cmd, "I_AÑO", DbType.Int32, entity.I_AÑO);
                        db.AddInParameter(cmd, "I_COD_CARGO", DbType.Int32, entity.I_COD_CARGO);
                        db.AddInParameter(cmd, "V_DES_ENTIDAD", DbType.String, entity.V_DES_ENTIDAD);
                        resultado = db.ExecuteNonQuery(cmd, trans);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                    finally
                    {

                        if (cone.State == ConnectionState.Open)
                        {

                            cone.Close();
                        }
                    }
                }

            }

            return resultado;
        }
        public int deleteTrabajos(int id)
        {
            int resultado = 0;
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();
                using (DbTransaction trans = cone.BeginTransaction())
                {
                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_DELETE_PERSONA_TRABAJOS");
                        db.AddInParameter(cmd, "I_COD_PERSONA_TRABAJOS", DbType.Int32, id);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                    finally
                    {

                        if (cone.State == ConnectionState.Open)
                        {
                            cone.Close();
                        }
                    }
                }
            }

            return resultado;
        }

    }

}
