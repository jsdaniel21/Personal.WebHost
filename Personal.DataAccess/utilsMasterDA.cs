using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.Data;
using BussinessEntity;
using System.Configuration;

namespace BussinessLogic.DataAccess
{
    public class tipoModalidadDA
    {
        public List<MA_TIPO_MODALIDAD> tipoModalidadPorTipoEmpleado(int iCodigoTipoEmpleado)
        {
            List<MA_TIPO_MODALIDAD> lista = new List<MA_TIPO_MODALIDAD>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_TIPO_MODALIDAD_X_TIPO_EMPLEADO");
            db.AddInParameter(cmd, "I_COD_TIPO_EMPLEADO", DbType.Int32, iCodigoTipoEmpleado);
            IDataReader lee = db.ExecuteReader(cmd);
            while (lee.Read())
            {
                MA_TIPO_MODALIDAD model = new MA_TIPO_MODALIDAD();
                model.I_COD_TIPO_MODALIDAD = Convert.ToInt32(lee["I_COD_TIPO_MODALIDAD"]);
                model.V_DES_TIPO_MODALIDA = lee["V_DES_TIPO_MODALIDA"].ToString();
                lista.Add(model);
            }
            return lista;
        }
        public int create(MA_TIPO_MODALIDAD entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_TIPO_MODALIDAD_CREATE");
                        db.AddInParameter(cmd, "V_DES_TIPO_MODALIDA", DbType.String, entity.V_DES_TIPO_MODALIDA);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
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

        public int delete(int id)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_TIPO_MODALIDAD_DELETE");
                        db.AddInParameter(cmd, "I_COD_TIPO_MODALIDAD", DbType.Int32, id);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public int edit(MA_TIPO_MODALIDAD entity)
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

                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_TIPO_MODALIDAD_EDIT");
                        db.AddInParameter(cmd, "I_COD_TIPO_MODALIDAD", DbType.Int32, entity.I_COD_TIPO_MODALIDAD);
                        db.AddInParameter(cmd, "V_DES_TIPO_MODALIDA", DbType.String, entity.V_DES_TIPO_MODALIDA);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public MA_TIPO_MODALIDAD GetById(int id)
        {
            MA_TIPO_MODALIDAD entity = new MA_TIPO_MODALIDAD();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_TIPO_MODALIDAD_DETALLE_X_ID");
            db.AddInParameter(cmd, "I_COD_TIPO_MODALIDAD", DbType.String, id);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.I_COD_TIPO_MODALIDAD = Convert.ToInt32(lee["I_COD_TIPO_MODALIDAD"]);
                entity.V_DES_TIPO_MODALIDA = lee["V_DES_TIPO_MODALIDA"].ToString();
            }

            return entity;
        }

        public List<MA_TIPO_MODALIDAD> GetAll()
        {
            List<MA_TIPO_MODALIDAD> lista = new List<MA_TIPO_MODALIDAD>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_TIPO_MODALIDAD_LISTAR");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_TIPO_MODALIDAD entity = new MA_TIPO_MODALIDAD();
                    entity.I_COD_TIPO_MODALIDAD = Convert.ToInt32(lee["I_COD_TIPO_MODALIDAD"]);
                    entity.V_DES_TIPO_MODALIDA = lee["V_DES_TIPO_MODALIDA"].ToString();
                    entity.C_ACTIVO = lee["C_ACTIVO"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }


    }

    public class MaCargoDA
    {
        public int create(MA_CARGO entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_CARGO_CREATE");
                        db.AddInParameter(cmd, "V_DES_CARGO", DbType.String, entity.V_DES_CARGO);
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


        public int delete(int id)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_CARGO_DELETE");
                        db.AddInParameter(cmd, "I_COD_CARGO", DbType.Int32, id);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public int edit(MA_CARGO entity)
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

                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_CARGO_EDIT");
                        db.AddInParameter(cmd, "I_COD_CARGO", DbType.Int32, entity.I_COD_CARGO);
                        db.AddInParameter(cmd, "V_DES_CARGO", DbType.String, entity.V_DES_CARGO);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public MA_CARGO GetById(int id)
        {
            MA_CARGO entity = new MA_CARGO();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_CARGO_DETALLE_X_ID");
            db.AddInParameter(cmd, "I_COD_CARGO", DbType.String, id);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.I_COD_CARGO = Convert.ToInt32(lee["I_COD_CARGO"]);
                entity.V_DES_CARGO = lee["V_DES_CARGO"].ToString();
            }

            return entity;
        }

        public List<MA_CARGO> GetAll()
        {
            List<MA_CARGO> lista = new List<MA_CARGO>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_CARGO_LISTAR");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_CARGO entity = new MA_CARGO();
                    entity.I_COD_CARGO = Convert.ToInt32(lee["I_COD_CARGO"]);
                    entity.V_DES_CARGO = lee["V_DES_CARGO"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }
    }

    public class MaCarreraProfesionalDA
    {
        public int create(MA_CARRERA_PROFESIONALES entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_CARRERA_PROFESIONAL_CREATE");
                        db.AddInParameter(cmd, "V_DES_CARRERA_PROFESIONAL", DbType.String, entity.V_DES_CARRERA_PROFESIONAL);
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

        public int delete(int id)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_CARRERA_PROFESIONAL_DELETE");
                        db.AddInParameter(cmd, "I_COD_CARRERA_PROFESIONAL", DbType.Int32, id);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public int edit(MA_CARRERA_PROFESIONALES entity)
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

                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_CARRERA_PROFESIONAL_EDIT");
                        db.AddInParameter(cmd, "I_COD_CARRERA_PROFESIONAL", DbType.Int32, entity.I_COD_CARRERA_PROFESIONAL);
                        db.AddInParameter(cmd, "V_DES_CARRERA_PROFESIONAL", DbType.String, entity.V_DES_CARRERA_PROFESIONAL);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public MA_CARRERA_PROFESIONALES GetById(int id)
        {
            MA_CARRERA_PROFESIONALES entity = new MA_CARRERA_PROFESIONALES();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_CARRERA_PROFESIONAL_DETALLE_X_ID");
            db.AddInParameter(cmd, "I_COD_CARRERA_PROFESIONAL", DbType.String, id);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.I_COD_CARRERA_PROFESIONAL = Convert.ToInt32(lee["I_COD_CARRERA_PROFESIONAL"]);
                entity.V_DES_CARRERA_PROFESIONAL = lee["V_DES_CARRERA_PROFESIONAL"].ToString();
            }

            return entity;
        }

        public List<MA_CARRERA_PROFESIONALES> GetAll()
        {
            List<MA_CARRERA_PROFESIONALES> lista = new List<MA_CARRERA_PROFESIONALES>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_CARRERA_PROFESIONAL_LISTAR");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_CARRERA_PROFESIONALES entity = new MA_CARRERA_PROFESIONALES();
                    entity.I_COD_CARRERA_PROFESIONAL = Convert.ToInt32(lee["I_COD_CARRERA_PROFESIONAL"]);
                    entity.V_DES_CARRERA_PROFESIONAL = lee["V_DES_CARRERA_PROFESIONAL"].ToString();
                    entity.C_ACTIVO = lee["C_ACTIVO"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }


    }

    public class MaEspecialidadDA
    {
        public int create(MA_ESPECIALIDAD entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_ESPECILIDAD_CREATE");
                        db.AddInParameter(cmd, "V_DES_ESPECIALIDAD", DbType.String, entity.V_DES_ESPECIALIDAD);
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

        public int delete(int id)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_ESPECIALIDAD_DELETE");
                        db.AddInParameter(cmd, "I_COD_ESPECIALIDAD", DbType.Int32, id);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public int edit(MA_ESPECIALIDAD entity)
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

                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_ESPECIALIDAD_EDIT");
                        db.AddInParameter(cmd, "I_COD_ESPECIALIDAD", DbType.Int32, entity.I_COD_ESPECIALIDAD);
                        db.AddInParameter(cmd, "V_DES_ESPECIALIDAD", DbType.String, entity.V_DES_ESPECIALIDAD);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public MA_ESPECIALIDAD GetById(int id)
        {
            MA_ESPECIALIDAD entity = new MA_ESPECIALIDAD();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_ESPECIALIDAD_DETALLE_X_ID");
            db.AddInParameter(cmd, "I_COD_ESPECIALIDAD", DbType.String, id);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.I_COD_ESPECIALIDAD = Convert.ToInt32(lee["I_COD_ESPECIALIDAD"]);
                entity.V_DES_ESPECIALIDAD = lee["V_DES_ESPECIALIDAD"].ToString();
            }

            return entity;
        }

        public List<MA_ESPECIALIDAD> GetAll()
        {
            List<MA_ESPECIALIDAD> lista = new List<MA_ESPECIALIDAD>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_ESPECIALIDAD_LISTAR");
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

    }

    public class MaGradMilitarDA
    {
        public List<MA_GRADO_MILITAR> listarGradoMilitarXinstitucion(int codInstitucion, string activo)
        {

            List<MA_GRADO_MILITAR> lista = new List<MA_GRADO_MILITAR>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"].ToString());
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_LISTAR_GRADO_MILITAR_X_INSTIUCION");
            db.AddInParameter(cmd, "I_COD_INSTITUCION", DbType.Int32, codInstitucion);
            db.AddInParameter(cmd, "C_ACTIVO", DbType.String, activo);
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    MA_GRADO_MILITAR entity = new MA_GRADO_MILITAR();
                    entity.C_COD_GRADO_MILITAR = reader["C_COD_GRADO_MILITAR"].ToString();
                    entity.V_DES_GRADO = reader["V_DES_GRADO"].ToString();
                    entity.V_ABREV_GRADOS = reader["V_ABREV_GRADOS"].ToString();
                    entity.C_ATIVO = reader["C_ATIVO"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }
        public MA_GRADO_MILITAR GetById(string id)
        {
            MA_GRADO_MILITAR entity = new MA_GRADO_MILITAR();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_GRADO_MILITAR_DETALLE_X_ID");
            db.AddInParameter(cmd, "C_COD_GRADO_MILITAR", DbType.String, id);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.C_COD_GRADO_MILITAR = lee["C_COD_GRADO_MILITAR"].ToString();
                entity.V_DES_GRADO = lee["V_DES_GRADO"].ToString();
                entity.V_ABREV_GRADOS = lee["V_ABREV_GRADOS"].ToString();
                entity.I_COD_INSTITUCION = Convert.ToInt32(lee["I_COD_INSTITUCION"].ToString());
                entity.C_ATIVO = lee["C_ATIVO"].ToString();
            }
            return entity;
        }
        public List<MA_GRADO_MILITAR> GetAll()
        {
            List<MA_GRADO_MILITAR> lista = new List<MA_GRADO_MILITAR>();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("MA_SP_GRADO_MILITAR_LISTAR");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_GRADO_MILITAR entity = new MA_GRADO_MILITAR();
                    entity.C_COD_GRADO_MILITAR = lee["C_COD_GRADO_MILITAR"].ToString();
                    entity.V_DES_GRADO = lee["V_DES_GRADO"].ToString();
                    entity.V_ABREV_GRADOS = lee["V_ABREV_GRADOS"].ToString();
                    entity.MA_INSTITUCION.V_DES_INSTITUCION = lee["V_DES_INSTITUCION"].ToString();
                    entity.C_ATIVO = lee["C_ATIVO"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }
        public int delete(string id)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_GRADO_MILITAR_DELETE");
                        db.AddInParameter(cmd, "C_COD_GRADO_MILITAR", DbType.String, (string)id);
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
        public int edit(MA_GRADO_MILITAR entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_GRADO_MILITAR_EDIT");
                        db.AddInParameter(cmd, "V_DES_GRADO", DbType.String, entity.V_DES_GRADO);
                        db.AddInParameter(cmd, "V_ABREV_GRADOS", DbType.String, entity.V_ABREV_GRADOS);
                        db.AddInParameter(cmd, "I_COD_INSTITUCION", DbType.String, entity.I_COD_INSTITUCION);
                        db.AddInParameter(cmd, "C_COD_GRADO_MILITAR", DbType.String, entity.C_COD_GRADO_MILITAR);
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
        public int create(MA_GRADO_MILITAR entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_GRADO_MILITAR_CREATE");
                        db.AddInParameter(cmd, "V_DES_GRADO", DbType.String, entity.V_DES_GRADO);
                        db.AddInParameter(cmd, "V_ABREV_GRADOS", DbType.String, entity.V_ABREV_GRADOS);
                        db.AddInParameter(cmd, "I_COD_INSTITUCION", DbType.String, entity.I_COD_INSTITUCION);
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


    public class MA_GRUPO_SANGUINEODA
    {
        public int create(MA_GRUPO_SANGUINEO entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_GRUPO_SANGUINEO_CREATE");
                        db.AddInParameter(cmd, "V_DES_GRUPO_SANGUINEO", DbType.String, entity.V_DES_GRUPO_SANGUINEO);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
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


        public int delete(int id)
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
                        DbCommand cmd = db.GetStoredProcCommand("[MA_SP_GRUPO_SANGUINEO_DELETE]");
                        db.AddInParameter(cmd, "I_COD_GRUPO_SANGUINEO", DbType.Int32, id);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public int edit(MA_GRUPO_SANGUINEO entity)
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

                        DbCommand cmd = db.GetStoredProcCommand("[MA_SP_GRUPO_SANGUINEO_EDIT]");
                        db.AddInParameter(cmd, "V_DES_GRUPO_SANGUINEO", DbType.String, entity.V_DES_GRUPO_SANGUINEO);
                        db.AddInParameter(cmd, "I_COD_GRUPO_SANGUINEO", DbType.String, entity.I_COD_GRUPO_SANGUINEO);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public MA_GRUPO_SANGUINEO GetById(int id)
        {
            MA_GRUPO_SANGUINEO entity = new MA_GRUPO_SANGUINEO();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_GRUPO_SANGUINEO_DETALLE_X_ID]");
            db.AddInParameter(cmd, "I_COD_GRUPO_SANGUINEO", DbType.String, id);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.I_COD_GRUPO_SANGUINEO = Convert.ToInt32(lee["I_COD_GRUPO_SANGUINEO"]);
                entity.V_DES_GRUPO_SANGUINEO = lee["V_DES_GRUPO_SANGUINEO"].ToString();
                entity.C_ACTIVO = lee["C_ACTIVO"].ToString();
            }

            return entity;
        }

        public List<MA_GRUPO_SANGUINEO> GetAll()
        {
            List<MA_GRUPO_SANGUINEO> lista = new List<MA_GRUPO_SANGUINEO>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_GRUPO_SANGUINEO_LISTAR]");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_GRUPO_SANGUINEO entity = new MA_GRUPO_SANGUINEO();
                    entity.I_COD_GRUPO_SANGUINEO = Convert.ToInt32(lee["I_COD_GRUPO_SANGUINEO"]);
                    entity.V_DES_GRUPO_SANGUINEO = lee["V_DES_GRUPO_SANGUINEO"].ToString();
                    entity.C_ACTIVO = lee["C_ACTIVO"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }
    }

    public class MA_ESTADO_CIVILDA
    {
        public int create(MA_ESTADO_CIVIL entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_ESTADO_CIVIL_CREATE");
                        db.AddInParameter(cmd, "V_DES_ESTADO_CIVIL", DbType.String, entity.V_DES_ESTADO_CIVIL);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
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


        public int delete(int id)
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
                        DbCommand cmd = db.GetStoredProcCommand("[MA_SP_ESTADO_CIVIL_DELETE]");
                        db.AddInParameter(cmd, "I_COD_ESTADO_CIVIL", DbType.Int32, id);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public int edit(MA_ESTADO_CIVIL entity)
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

                        DbCommand cmd = db.GetStoredProcCommand("[MA_SP_ESTADO_CIVIL_EDIT]");
                        db.AddInParameter(cmd, "V_DES_ESTADO_CIVIL", DbType.String, entity.V_DES_ESTADO_CIVIL);
                        db.AddInParameter(cmd, "I_COD_ESTADO_CIVIL", DbType.String, entity.I_COD_ESTADO_CIVIL);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public MA_ESTADO_CIVIL GetById(int id)
        {
            MA_ESTADO_CIVIL entity = new MA_ESTADO_CIVIL();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_ESTADO_CIVIL_DETALLE_X_ID]");
            db.AddInParameter(cmd, "I_COD_ESTADO_CIVIL", DbType.String, id);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.I_COD_ESTADO_CIVIL = Convert.ToInt32(lee["I_COD_ESTADO_CIVIL"]);
                entity.V_DES_ESTADO_CIVIL = lee["V_DES_ESTADO_CIVIL"].ToString();
                entity.C_ACTIVO = lee["C_ACTIVO"].ToString();
            }

            return entity;
        }

        public List<MA_ESTADO_CIVIL> GetAll()
        {
            List<MA_ESTADO_CIVIL> lista = new List<MA_ESTADO_CIVIL>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_ESTADO_CIVIL_LISTAR]");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_ESTADO_CIVIL entity = new MA_ESTADO_CIVIL();
                    entity.I_COD_ESTADO_CIVIL = Convert.ToInt32(lee["I_COD_ESTADO_CIVIL"]);
                    entity.V_DES_ESTADO_CIVIL = lee["V_DES_ESTADO_CIVIL"].ToString();
                    entity.C_ACTIVO = lee["C_ACTIVO"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }
    }

    public class MA_TIPO_IDENTIFICACIONDA
    {
        public int create(MA_TIPO_IDENTIFICACION entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_TIPO_IDENTIFICACION_CREATE");
                        db.AddInParameter(cmd, "V_DES_TIPO_IDENTIFICACION", DbType.String, entity.V_DES_TIPO_IDENTIFICACION);
                        db.AddInParameter(cmd, "V_ABREV_IDENTIFICACION", DbType.String, entity.V_ABREV_IDENTIFICACION);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
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


        public int delete(int id)
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
                        DbCommand cmd = db.GetStoredProcCommand("[MA_SP_TIPO_IDENTIFICACION_DELETE]");
                        db.AddInParameter(cmd, "I_COD_TIPO_IDENTIFICACION", DbType.Int32, id);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public int edit(MA_TIPO_IDENTIFICACION entity)
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

                        DbCommand cmd = db.GetStoredProcCommand("[MA_SP_TIPO_IDENTIFICACION_EDIT]");
                        db.AddInParameter(cmd, "V_DES_TIPO_IDENTIFICACION", DbType.String, entity.V_DES_TIPO_IDENTIFICACION);
                        db.AddInParameter(cmd, "V_ABREV_IDENTIFICACION", DbType.String, entity.V_ABREV_IDENTIFICACION);
                        db.AddInParameter(cmd, "I_COD_TIPO_IDENTIFICACION", DbType.Int32, entity.I_COD_TIPO_IDENTIFICACION);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public MA_TIPO_IDENTIFICACION GetById(int id)
        {
            MA_TIPO_IDENTIFICACION entity = new MA_TIPO_IDENTIFICACION();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_TIPO_IDENTIFICACION_DETALLE_X_ID]");
            db.AddInParameter(cmd, "I_COD_TIPO_IDENTIFICACION", DbType.String, id);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.I_COD_TIPO_IDENTIFICACION = Convert.ToInt32(lee["I_COD_TIPO_IDENTIFICACION"]);
                entity.V_DES_TIPO_IDENTIFICACION = lee["V_DES_TIPO_IDENTIFICACION"].ToString();
                entity.V_ABREV_IDENTIFICACION = lee["V_ABREV_IDENTIFICACION"].ToString();
                entity.C_ACTIVO = lee["C_ACTIVO"].ToString();
            }

            return entity;
        }

        public List<MA_TIPO_IDENTIFICACION> GetAll()
        {
            List<MA_TIPO_IDENTIFICACION> lista = new List<MA_TIPO_IDENTIFICACION>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_TIPO_IDENTIFICACION_LISTAR]");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_TIPO_IDENTIFICACION entity = new MA_TIPO_IDENTIFICACION();
                    entity.I_COD_TIPO_IDENTIFICACION = Convert.ToInt32(lee["I_COD_TIPO_IDENTIFICACION"]);
                    entity.V_DES_TIPO_IDENTIFICACION = lee["V_DES_TIPO_IDENTIFICACION"].ToString();
                    entity.V_ABREV_IDENTIFICACION = lee["V_ABREV_IDENTIFICACION"].ToString();
                    entity.C_ACTIVO = lee["C_ACTIVO"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }

    }

    public class MA_TIPO_DOMICILIODA
    {
        public int create(MA_TIPO_DOMICILIO entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_TIPO_DOMICILIO_CREATE");
                        db.AddInParameter(cmd, "V_DES_TIPO_DOMICILIO", DbType.String, entity.V_DES_TIPO_DOMICILIO);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
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


        public int delete(int id)
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
                        DbCommand cmd = db.GetStoredProcCommand("[MA_SP_TIPO_DOMICILIO_DELETE]");
                        db.AddInParameter(cmd, "I_COD_TIPO_DOMICILIO", DbType.Int32, id);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public int edit(MA_TIPO_DOMICILIO entity)
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

                        DbCommand cmd = db.GetStoredProcCommand("[MA_SP_TIPO_DOMICILIO_EDIT]");
                        db.AddInParameter(cmd, "I_COD_TIPO_DOMICILIO", DbType.Int32, entity.I_COD_TIPO_DOMICILIO);
                        db.AddInParameter(cmd, "V_DES_TIPO_DOMICILIO", DbType.String, entity.V_DES_TIPO_DOMICILIO);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public MA_TIPO_DOMICILIO GetById(int id)
        {
            MA_TIPO_DOMICILIO entity = new MA_TIPO_DOMICILIO();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_TIPO_DOMICILIO_DETALLE_X_ID]");
            db.AddInParameter(cmd, "I_COD_TIPO_DOMICILIO", DbType.String, id);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.I_COD_TIPO_DOMICILIO = Convert.ToInt32(lee["I_COD_TIPO_DOMICILIO"]);
                entity.V_DES_TIPO_DOMICILIO = lee["V_DES_TIPO_DOMICILIO"].ToString();
                entity.C_ACTIVO = lee["C_ACTIVO"].ToString();
            }

            return entity;
        }

        public List<MA_TIPO_DOMICILIO> GetAll()
        {
            List<MA_TIPO_DOMICILIO> lista = new List<MA_TIPO_DOMICILIO>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_TIPO_DOMICILIO_LISTAR]");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_TIPO_DOMICILIO entity = new MA_TIPO_DOMICILIO();
                    entity.I_COD_TIPO_DOMICILIO = Convert.ToInt32(lee["I_COD_TIPO_DOMICILIO"]);
                    entity.V_DES_TIPO_DOMICILIO = lee["V_DES_TIPO_DOMICILIO"].ToString();
                    entity.C_ACTIVO = lee["C_ACTIVO"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }
    }
    public class MA_OCUPACIONDA
    {
        public int create(MA_OCUPACION entity)
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
                        DbCommand cmd = db.GetStoredProcCommand("MA_SP_OCUPACION_CREATE");
                        db.AddInParameter(cmd, "V_DES_OCUPACION", DbType.String, entity.V_DES_OCUPACION);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
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


        public int delete(int id)
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
                        DbCommand cmd = db.GetStoredProcCommand("[MA_SP_OCUPACION_DELETE]");
                        db.AddInParameter(cmd, "I_COD_OCUPACION", DbType.Int32, id);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public int edit(MA_OCUPACION entity)
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

                        DbCommand cmd = db.GetStoredProcCommand("[MA_SP_OCUPACION_EDIT]");
                        db.AddInParameter(cmd, "I_COD_OCUPACION", DbType.Int32, entity.I_COD_OCUPACION);
                        db.AddInParameter(cmd, "V_DES_OCUPACION", DbType.String, entity.V_DES_OCUPACION);
                        resultado = Convert.ToInt32(db.ExecuteNonQuery(cmd, trans));
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
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

        public MA_OCUPACION GetById(int id)
        {
            MA_OCUPACION entity = new MA_OCUPACION();

            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_OCUPACION_DETALLE_X_ID]");
            db.AddInParameter(cmd, "I_COD_OCUPACION", DbType.String, id);
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                lee.Read();
                entity.I_COD_OCUPACION = Convert.ToInt32(lee["I_COD_OCUPACION"]);
                entity.V_DES_OCUPACION = lee["V_DES_OCUPACION"].ToString();
            }

            return entity;
        }

        public List<MA_OCUPACION> GetAll()
        {
            List<MA_OCUPACION> lista = new List<MA_OCUPACION>();
            Database db = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conecion"]);
            DbCommand cmd = db.GetStoredProcCommand("[MA_SP_OCUPACION_LISTAR]");
            using (IDataReader lee = db.ExecuteReader(cmd))
            {
                while (lee.Read())
                {
                    MA_OCUPACION entity = new MA_OCUPACION();
                    entity.I_COD_OCUPACION = Convert.ToInt32(lee["I_COD_OCUPACION"]);
                    entity.V_DES_OCUPACION = lee["V_DES_OCUPACION"].ToString();
                    lista.Add(entity);
                }
            }
            return lista;
        }
    }

}
