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
    public partial class peopleStudiesDA
    {
        public int deleteEstudios(int id)
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
                        DbCommand cmd = db.GetStoredProcCommand("SG_SP_DELETE_PERSONA_ESTUDIOS");
                        db.AddInParameter(cmd, "I_COD_PERSONA_ESTUDIOS", DbType.Int32, id);
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
        public int actualizarEstudios(SG_PERSONA_ESTUDIOS entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("SG_SP_ACTUALIZAR_PERSONA_ESTUDIOS");
                        db.AddInParameter(cmd, "I_COD_PERSONA_ESTUDIOS", DbType.Int32, entity.I_COD_PERSONA_ESTUDIOS);
                        db.AddInParameter(cmd, "I_COD_INSTITUCION", DbType.Int32, entity.I_COD_INSTITUCION);
                        if (entity.I_COD_ESPECIALIDAD == 0)
                            db.AddInParameter(cmd, "I_COD_CARRERA_PROFESIONAL", DbType.Int32, DBNull.Value);
                        else
                            db.AddInParameter(cmd, "I_COD_CARRERA_PROFESIONAL", DbType.Int32, entity.I_COD_CARRERA_PROFESIONAL);
                        if (entity.I_COD_ESPECIALIDAD == 0)
                            db.AddInParameter(cmd, "I_COD_ESPECIALIDAD", DbType.Int32, DBNull.Value);
                        else
                            db.AddInParameter(cmd, "I_COD_ESPECIALIDAD", DbType.Int32, entity.I_COD_ESPECIALIDAD);
                        db.AddInParameter(cmd, "I_AÑO_INGRESO", DbType.Int32, entity.I_AÑO_INGRESO);
                        db.AddInParameter(cmd, "I_AÑO_EGRESO", DbType.Int32, entity.I_AÑO_EGRESO);
                        db.AddInParameter(cmd, "C_COD_GRADO_ACADEMICO", DbType.Int32, entity.C_COD_GRADO_ACADEMICO);
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


        public List<MA_ESPECIALIDAD> litarEspecialidad()
        {

            List<MA_ESPECIALIDAD> lista = new List<MA_ESPECIALIDAD>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_ESPECIALIDAD_CBO");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_ESPECIALIDAD entity = new MA_ESPECIALIDAD();
                    entity.I_COD_ESPECIALIDAD = Convert.ToInt32(lee["I_COD_ESPECIALIDAD"]);
                    entity.V_DES_ESPECIALIDAD = lee["V_DES_ESPECIALIDAD"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;

        }
        public List<MA_CARRERA_PROFESIONALES> listarCarrerasProfesionales()
        {
            List<MA_CARRERA_PROFESIONALES> lista = new List<MA_CARRERA_PROFESIONALES>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_CARRERAS_PROFESIONALES_CBO");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_CARRERA_PROFESIONALES entity = new MA_CARRERA_PROFESIONALES();
                    entity.I_COD_CARRERA_PROFESIONAL = Convert.ToInt32(lee["I_COD_CARRERA_PROFESIONAL"]);
                    entity.V_DES_CARRERA_PROFESIONAL = lee["V_DES_CARRERA_PROFESIONAL"].ToString();
                    lista.Add(entity);

                }

            }

            return lista;

        }
        public List<SG_PERSONA_ESTUDIOS> listarPeopleStudies(string codPersona)
        {
            List<SG_PERSONA_ESTUDIOS> lista = new List<SG_PERSONA_ESTUDIOS>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("SG_LISTAR_ESTUDIOS_X_PERSONA");
            db.AddInParameter(cmd, "C_COD_PERSONA", System.Data.DbType.String, codPersona);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    SG_PERSONA_ESTUDIOS entity = new SG_PERSONA_ESTUDIOS();
                    entity.I_COD_PERSONA_ESTUDIOS = Convert.ToInt32(lee["I_COD_PERSONA_ESTUDIOS"].ToString());
                    entity.MA_INSTITUCION.V_DES_INSTITUCION = lee["V_DES_INSTITUCION"].ToString();
                    entity.MA_INSTITUCION.MA_TIPO_ENTIDAD.V_DES_ENTIDAD = lee["V_DES_ENTIDAD"].ToString();
                    entity.MA_INSTITUCION.MA_TIPO_INSTITUCION.V_DES_TIPO_INSTITUCION = lee["V_DES_TIPO_INSTITUCION"].ToString();
                    entity.MA_CARRERA_PROFESIONALES.V_DES_CARRERA_PROFESIONAL = lee["V_DES_CARRERA_PROFESIONAL"].ToString();
                    entity.MA_GRADO_ACADEMICO.V_DES_GRADO_ACADEMICO = lee["V_DES_GRADO_ACADEMICO"].ToString();
                    entity.C_ACTIVO = lee["C_ACTIVO"].ToString();

                    lista.Add(entity);
                }
            }
            return lista;

        }

        public List<MA_TIPO_ENTIDAD> listarTipoEntidad()
        {
            List<MA_TIPO_ENTIDAD> lista = new List<MA_TIPO_ENTIDAD>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_TIPO_ENTIDAD");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_TIPO_ENTIDAD entity = new MA_TIPO_ENTIDAD();
                    entity.I_COD_TIPO_ENTIDAD = Convert.ToInt32(lee["I_COD_TIPO_ENTIDAD"]);
                    entity.V_DES_ENTIDAD = lee["V_DES_ENTIDAD"].ToString();
                    lista.Add(entity);
                }

            }
            return lista;

        }
        public List<MA_TIPO_INSTITUCION> listTypeForInstitutionEducational()
        {

            List<MA_TIPO_INSTITUCION> list = new List<MA_TIPO_INSTITUCION>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_TIPO_INSTITUCION_EDUCATIVA");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_TIPO_INSTITUCION entity = new MA_TIPO_INSTITUCION();
                    entity.I_COD_TIPO_INSTITUCION = Convert.ToInt32(lee["I_COD_TIPO_INSTITUCION"].ToString());
                    entity.V_DES_TIPO_INSTITUCION = lee["V_DES_TIPO_INSTITUCION"].ToString();
                    list.Add(entity);
                }

            }

            return list;
        }

        public List<MA_GRADO_ACADEMICO> listGradeAcademic()
        {
            List<MA_GRADO_ACADEMICO> list = new List<MA_GRADO_ACADEMICO>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_LISTAR_GRADO_ACADEMICO]");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_GRADO_ACADEMICO entity = new MA_GRADO_ACADEMICO();
                    entity.C_COD_GRADO_ACADEMICO = Convert.ToInt32(lee["C_COD_GRADO_ACADEMICO"]);
                    entity.V_DES_GRADO_ACADEMICO = lee["V_DES_GRADO_ACADEMICO"].ToString();
                    list.Add(entity);
                }

            }
            return list;
        }


        public int registrarEstudios(SG_PERSONA_ESTUDIOS entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("SG_SP_REGISTRAR_PERSONA_ESTUDIOS");
                        db.AddInParameter(cmd, "C_COD_PERSONA", DbType.String, entity.C_COD_PERSONA);
                        db.AddInParameter(cmd, "I_COD_INSTITUCION", DbType.Int32, entity.I_COD_INSTITUCION);
                        db.AddInParameter(cmd, "I_COD_CARRERA_PROFESIONAL", DbType.Int32, entity.I_COD_CARRERA_PROFESIONAL);
                        db.AddInParameter(cmd, "I_COD_ESPECIALIDAD", DbType.Int32, entity.I_COD_ESPECIALIDAD);
                        db.AddInParameter(cmd, "I_AÑO_INGRESO", DbType.Int32, entity.I_AÑO_INGRESO);
                        db.AddInParameter(cmd, "I_AÑO_EGRESO", DbType.Int32, entity.I_AÑO_EGRESO);
                        db.AddInParameter(cmd, "C_COD_GRADO_ACADEMICO", DbType.Int32, entity.C_COD_GRADO_ACADEMICO);
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

        public SG_PERSONA_ESTUDIOS detalleEstudiosForID(int id)
        {
            SG_PERSONA_ESTUDIOS entity = new SG_PERSONA_ESTUDIOS();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("SG_SP_DETALLE_PERSONA_ESTUDIOS_X_ID");
            db.AddInParameter(cmd, "I_COD_PERSONA_ESTUDIOS", DbType.Int32, id);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.I_COD_PERSONA_ESTUDIOS = Convert.ToInt32(lee["I_COD_PERSONA_ESTUDIOS"]);
                entity.MA_INSTITUCION.I_COD_TIPO_INSTITUCION = Convert.ToInt32(lee["I_COD_TIPO_INSTITUCION"]);
                entity.MA_INSTITUCION.MA_TIPO_INSTITUCION.V_DES_TIPO_INSTITUCION = lee["V_DES_TIPO_INSTITUCION"].ToString();
                entity.MA_INSTITUCION.I_COD_TIPO_ENTIDAD = Convert.ToInt32(lee["I_COD_TIPO_ENTIDAD"]);
                entity.MA_INSTITUCION.MA_TIPO_ENTIDAD.V_DES_ENTIDAD = lee["V_DES_ENTIDAD"].ToString();
                entity.I_COD_INSTITUCION = Convert.ToInt32(lee["I_COD_INSTITUCION"]);
                entity.MA_INSTITUCION.V_DES_INSTITUCION = lee["V_DES_INSTITUCION"].ToString();
                entity.I_COD_CARRERA_PROFESIONAL = Convert.ToInt32(lee["I_COD_CARRERA_PROFESIONAL"].Equals(DBNull.Value) ? 0 : lee["I_COD_CARRERA_PROFESIONAL"]);
                entity.MA_CARRERA_PROFESIONALES.V_DES_CARRERA_PROFESIONAL = lee["V_DES_CARRERA_PROFESIONAL"].ToString();
                entity.I_COD_ESPECIALIDAD = Convert.ToInt32(lee["I_COD_ESPECIALIDAD"].Equals(DBNull.Value) ? 0 : lee["I_COD_ESPECIALIDAD"]);
                entity.MA_ESPECIALIDAD.V_DES_ESPECIALIDAD = lee["V_DES_ESPECIALIDAD"].ToString();
                entity.I_AÑO_INGRESO = Convert.ToInt32(lee["I_AÑO_INGRESO"]);
                entity.I_AÑO_EGRESO = Convert.ToInt32(lee["I_AÑO_EGRESO"]);
                entity.C_COD_GRADO_ACADEMICO = Convert.ToInt32(lee["C_COD_GRADO_ACADEMICO"]);
                entity.MA_GRADO_ACADEMICO.V_DES_GRADO_ACADEMICO = lee["V_DES_GRADO_ACADEMICO"].ToString();
            }

            return entity;
        }




    }
}
