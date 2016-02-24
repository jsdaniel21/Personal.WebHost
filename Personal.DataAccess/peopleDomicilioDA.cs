using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Configuration;
using BussinessEntity;
using Personal.ViewModels;
using System.Data.Spatial;

namespace BussinessLogic.DataAccess
{
    public class peopleDomicilioDA
    {
        public int deleteDomiclio(int id)
        {

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            int resultado = 0;
            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();
                using (DbTransaction trans = cone.BeginTransaction())
                {
                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_DELETE_PERSONA_DOMICILIO");
                        db.AddInParameter(cmd, "I_COD_PERSONA_DOMICILIO", DbType.Int32, id);
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
        public int actualizarPersonaDomicilio(RRHH_PERSONA_DOMICILIO entity)
        {

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            int resultado = 0;
            using (DbConnection cone = db.CreateConnection())
            {
                cone.Open();
                using (DbTransaction trans = cone.BeginTransaction())
                {

                    try
                    {
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_ACTUALIZAR_PERSONA_DOMICILIO");
                        db.AddInParameter(cmd, "I_COD_PERSONA_DOMICILIO", DbType.Int32, entity.I_COD_PERSONA_DOMICILIO);
                        db.AddInParameter(cmd, "I_COD_PAIS", DbType.Int32, entity.I_COD_PAIS);
                        db.AddInParameter(cmd, "C_COD_DEPARTAMENTO", DbType.String, entity.C_COD_DEPARTAMENTO);
                        db.AddInParameter(cmd, "C_COD_PROVINCIA", DbType.String, entity.C_COD_PROVINCIA);
                        db.AddInParameter(cmd, "C_COD_DISTRITO", DbType.String, entity.C_COD_DISTRITO);
                        db.AddInParameter(cmd, "V_DES_DIRECCION", DbType.String, entity.V_DES_DIRECCION);
                        db.AddInParameter(cmd, "V_DES_URBANIZACION", DbType.String, entity.V_DES_URBANIZACION);
                        db.AddInParameter(cmd, "I_COD_TIPO_DOMICILIO", DbType.Int32, entity.I_COD_TIPO_DOMICILIO);
                        db.AddInParameter(cmd, "V_GEO_LOCALIZACION", DbType.String, "");
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
        public RRHH_PERSONA_DOMICILIO detalleDomicilioPersonaForID(int codPersonaDomicilio)
        {
            RRHH_PERSONA_DOMICILIO entity = new RRHH_PERSONA_DOMICILIO();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("RRHH_DETALLE_DOMICILIO_X_ID_PERSONA_DOMICILIO");
            db.AddInParameter(cmd, "I_COD_PERSONA_DOMICILIO", DbType.Int32, codPersonaDomicilio);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.I_COD_PERSONA_DOMICILIO = Convert.ToInt32(lee["I_COD_PERSONA_DOMICILIO"].ToString());
                entity.C_COD_PERSONA = lee["C_COD_PERSONA"].ToString();
                entity.I_COD_PAIS = Convert.ToInt32(lee["I_COD_PAIS"]);
                entity.C_COD_DEPARTAMENTO = lee["C_COD_DEPARTAMENTO"].ToString();
                entity.C_COD_PROVINCIA = lee["C_COD_PROVINCIA"].ToString();
                entity.C_COD_DISTRITO = lee["C_COD_DISTRITO"].ToString();
                entity.V_DES_DIRECCION = lee["V_DES_DIRECCION"].ToString();
                entity.V_DES_URBANIZACION = lee["V_DES_URBANIZACION"].ToString();
                entity.I_COD_TIPO_DOMICILIO = Convert.ToInt32(lee["I_COD_TIPO_DOMICILIO"]);
                entity.V_GEO_LOCALIZACION = DbGeography.FromText(lee["V_GEO_LOCALIZACION"].ToString());
            }
            return entity;

        }
        public int registrarDomicilio(RRHH_PERSONA_DOMICILIO entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_REGISTRAR_DOMICILIO");            
                        db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, entity.C_COD_PERSONA);
                        db.AddInParameter(cmd, "I_COD_PAIS", DbType.String, entity.I_COD_PAIS);
                        db.AddInParameter(cmd, "C_COD_DEPARTAMENTO", DbType.String, entity.C_COD_DEPARTAMENTO);
                        db.AddInParameter(cmd, "C_COD_PROVINCIA", DbType.String, entity.C_COD_PROVINCIA);
                        db.AddInParameter(cmd, "C_COD_DISTRITO", DbType.String, entity.C_COD_DISTRITO);
                        db.AddInParameter(cmd, "V_DES_DIRECCION", DbType.String, entity.V_DES_DIRECCION);
                        db.AddInParameter(cmd, "V_DES_URBANIZACION", DbType.String, entity.V_DES_URBANIZACION);
                        db.AddInParameter(cmd, "I_COD_TIPO_DOMICILIO", DbType.String, entity.I_COD_TIPO_DOMICILIO);
                        db.AddInParameter(cmd, "V_GEO_LOCALIZACION", DbType.String, "POINT(" + entity.V_GEO_LOCALIZACION.Longitude.ToString().Replace(",", ".") + " " + entity.V_GEO_LOCALIZACION.Latitude.ToString().Replace(",", ".") + ")");
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
        public List<MA_DISTRITO> fillDistritoCb(int codPais, string codDepartamento, string codProvincia)
        {
            List<MA_DISTRITO> lista = new List<MA_DISTRITO>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_DISTRITO_X_PROVINCIA_ACTIVOS");
            db.AddInParameter(cmd, "I_COD_PAIS", DbType.Int32, codPais);
            db.AddInParameter(cmd, "C_COD_DEPARTAMENTO", DbType.String, codDepartamento);
            db.AddInParameter(cmd, "C_COD_PROVINCIA", DbType.String, codProvincia);

            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_DISTRITO entity = new MA_DISTRITO();
                    entity.V_DES_DISTRITO = lee["V_DES_DISTRITO"].ToString();
                    entity.C_COD_DISTRITO = lee["C_COD_DISTRITO"].ToString();
                    lista.Add(entity);
                }
            }


            return lista;
        }
        public List<MA_PROVINCIA> fillProvinciaCb(int codPais, string codDeprtamento)
        {
            List<MA_PROVINCIA> lista = new List<MA_PROVINCIA>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_PROVINCIA_X_DEPARTAMENTO_ACTIVOS");
            db.AddInParameter(cmd, "I_COD_PAIS", DbType.Int32, codPais);
            db.AddInParameter(cmd, "C_COD_DEPARTAMENTO", DbType.String, codDeprtamento);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    var entity = new MA_PROVINCIA();
                    entity.C_COD_PROVINCIA = lee["C_COD_PROVINCIA"].ToString();
                    entity.V_DES_PROVINCIA = lee["V_DES_PROVINCIA"].ToString();
                    lista.Add(entity);
                }

            }
            return lista;
        }
        public List<MA_DEPARTAMENTO> fillDepartamentoCb(int codPais)
        {
            List<MA_DEPARTAMENTO> lista = new List<MA_DEPARTAMENTO>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_DEPARTAMENTO_ACTIVOS");
            db.AddInParameter(cmd, "I_COD_PAIS", DbType.String, codPais);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_DEPARTAMENTO entity = new MA_DEPARTAMENTO();
                    entity.C_COD_DEPARTAMENTO = lee["C_COD_DEPARTAMENTO"].ToString();
                    entity.V_DES_DEPARTAMENTO = lee["V_DES_DEPARTAMENTO"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }
        public List<MA_TIPO_DOMICILIO> listarTipoDomicilio()
        {

            List<MA_TIPO_DOMICILIO> lista = new List<MA_TIPO_DOMICILIO>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_TIPO_DOMICILIO");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_TIPO_DOMICILIO entity = new MA_TIPO_DOMICILIO();
                    entity.I_COD_TIPO_DOMICILIO = Convert.ToInt32(lee["I_COD_TIPO_DOMICILIO"]);
                    entity.V_DES_TIPO_DOMICILIO = lee["V_DES_TIPO_DOMICILIO"].ToString();
                    lista.Add(entity);
                }
            }

            return lista;

        }
        public List<listDomicilioPersonaVM> listarDomicilioXpersona(string codPersona)
        {
            List<listDomicilioPersonaVM> lista = new List<listDomicilioPersonaVM>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("RRHH_SP_LISTAR_DOMICILIO_X_PERSONA");
            db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, codPersona);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    listDomicilioPersonaVM entity = new listDomicilioPersonaVM();
                    entity.RRHH_PERSONA_DOMICILIO.I_COD_PERSONA_DOMICILIO = Convert.ToInt32(lee["I_COD_PERSONA_DOMICILIO"].ToString());
                    entity.MA_PAI.V_DES_PAIS = lee["V_DES_PAIS"].ToString();
                    entity.MA_DEPARTAMENTO.V_DES_DEPARTAMENTO = lee["V_DES_DEPARTAMENTO"].ToString();
                    entity.MA_PROVINCIA.V_DES_PROVINCIA = lee["V_DES_PROVINCIA"].ToString();
                    entity.MA_DISTRITO.V_DES_DISTRITO = lee["V_DES_DISTRITO"].ToString();
                    entity.MA_TIPO_DOMICILIO.V_DES_TIPO_DOMICILIO = lee["V_DES_TIPO_DOMICILIO"].ToString();
                    lista.Add(entity);
                }
            }

            return lista;
        }

    }
}
