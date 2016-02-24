using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.DataAccess;
using BussinessLogic.Interfaces;
using BussinessEntity;
using Personal.Interfaces;

namespace BussinessLogic
{
    public class tipoModalidadBL : IMaTipoModalidadRepository
    {
        public int create<T>(T entity)
        {
            return new tipoModalidadDA().create((MA_TIPO_MODALIDAD)(object)entity);
        }

        public List<T> GetAll<T>()
        {
            return (List<T>)(object)new tipoModalidadDA().GetAll(); ;
        }
        public T GetById<T>(object id)
        {
            return (T)(object)new tipoModalidadDA().GetById((int)id);
        }
        public int edit<T>(T entity)
        {
            return new tipoModalidadDA().edit((MA_TIPO_MODALIDAD)(object)entity);
        }
        public int delete(object id)
        {
            return new tipoModalidadDA().delete((int)id);
        }


        public List<MA_TIPO_MODALIDAD> tipoModalidadPorTipoEmpleado(int iCodigoTipoEmpleado)
        {
            return new tipoModalidadDA().tipoModalidadPorTipoEmpleado(iCodigoTipoEmpleado);
        }
    }

    public class MaCargoBL : IRepository
    {
        public int create<T>(T entity)
        {
            return new MaCargoDA().create((MA_CARGO)(object)entity);
        }
        public List<T> GetAll<T>()
        {
            return (List<T>)(object)new MaCargoDA().GetAll(); ;
        }
        public T GetById<T>(object id)
        {
            return (T)(object)new MaCargoDA().GetById((int)id);
        }
        public int edit<T>(T entity)
        {
            return new MaCargoDA().edit((MA_CARGO)(object)entity);
        }
        public int delete(object id)
        {
            return new MaCargoDA().delete((int)id);
        }
    }

    public class MaCarreraProfesionalBL : IRepository
    {
        public int create<T>(T entity)
        {

            return new MaCarreraProfesionalDA().create((MA_CARRERA_PROFESIONALES)(object)entity);
        }
        public List<T> GetAll<T>()
        {
            return (List<T>)(object)new MaCarreraProfesionalDA().GetAll(); ;
        }
        public T GetById<T>(object id)
        {
            return (T)(object)new MaCarreraProfesionalDA().GetById((int)id);
        }
        public int edit<T>(T entity)
        {
            return new MaCarreraProfesionalDA().edit((MA_CARRERA_PROFESIONALES)(object)entity);
        }
        public int delete(object id)
        {
            return new MaCarreraProfesionalDA().delete((int)id);
        }
    }

    public class MaEspecialidadBL : IRepository
    {
        public int create<T>(T entity)
        {
            return new MaEspecialidadDA().create((MA_ESPECIALIDAD)(object)entity);
        }
        public List<T> GetAll<T>()
        {
            return (List<T>)(object)new MaEspecialidadDA().GetAll(); ;
        }
        public T GetById<T>(object id)
        {
            return (T)(object)new MaEspecialidadDA().GetById((int)id);
        }
        public int edit<T>(T entity)
        {
            return new MaEspecialidadDA().edit((MA_ESPECIALIDAD)(object)entity);
        }
        public int delete(object id)
        {
            return new MaEspecialidadDA().delete((int)id);
        }
    }

    public class MaGradMilitarBL : IGradoMilitarRepository
    {

        public int create<T>(T entity)
        {
            return new MaGradMilitarDA().create((MA_GRADO_MILITAR)(object)entity);
        }
        public List<T> GetAll<T>()
        {
            return (List<T>)(object)new MaGradMilitarDA().GetAll(); ;
        }
        public T GetById<T>(object id)
        {
            return (T)(object)new MaGradMilitarDA().GetById((string)id);
        }
        public int edit<T>(T entity)
        {
            return new MaGradMilitarDA().edit((MA_GRADO_MILITAR)(object)entity);
        }
        public int delete(object id)
        {
            return new MaGradMilitarDA().delete((string)id);
        }

        public List<MA_GRADO_MILITAR> listarGradoMilitarXinstitucion(int codInstitucion, string activo)
        {
            return new MaGradMilitarDA().listarGradoMilitarXinstitucion(codInstitucion, activo);
        }
    }


    public class MA_GRUPO_SANGUINEOBL : IRepository
    {
        public int create<T>(T entity)
        {
            return new MA_GRUPO_SANGUINEODA().create((MA_GRUPO_SANGUINEO)(object)entity);
        }

        public List<T> GetAll<T>()
        {
            return (List<T>)(object)new MA_GRUPO_SANGUINEODA().GetAll(); ;
        }
        public T GetById<T>(object id)
        {
            return (T)(object)new MA_GRUPO_SANGUINEODA().GetById((int)id);
        }
        public int edit<T>(T entity)
        {
            return new MA_GRUPO_SANGUINEODA().edit((MA_GRUPO_SANGUINEO)(object)entity);
        }
        public int delete(object id)
        {
            return new MA_GRUPO_SANGUINEODA().delete((int)id);
        }
    }


    public class MA_ESTADO_CIVILBL : IRepository
    {
        public int create<T>(T entity)
        {
            return new MA_ESTADO_CIVILDA().create((MA_ESTADO_CIVIL)(object)entity);
        }

        public List<T> GetAll<T>()
        {
            return (List<T>)(object)new MA_ESTADO_CIVILDA().GetAll(); ;
        }
        public T GetById<T>(object id)
        {
            return (T)(object)new MA_ESTADO_CIVILDA().GetById((int)id);
        }
        public int edit<T>(T entity)
        {
            return new MA_ESTADO_CIVILDA().edit((MA_ESTADO_CIVIL)(object)entity);
        }
        public int delete(object id)
        {
            return new MA_ESTADO_CIVILDA().delete((int)id);
        }
    }


    public class MA_TIPO_IDENTIFICACIONBL : IRepository
    {
        public int create<T>(T entity)
        {
            return new MA_TIPO_IDENTIFICACIONDA().create((MA_TIPO_IDENTIFICACION)(object)entity);
        }

        public List<T> GetAll<T>()
        {
            return (List<T>)(object)new MA_TIPO_IDENTIFICACIONDA().GetAll(); ;
        }
        public T GetById<T>(object id)
        {
            return (T)(object)new MA_TIPO_IDENTIFICACIONDA().GetById((int)id);
        }
        public int edit<T>(T entity)
        {
            return new MA_TIPO_IDENTIFICACIONDA().edit((MA_TIPO_IDENTIFICACION)(object)entity);
        }
        public int delete(object id)
        {
            return new MA_TIPO_IDENTIFICACIONDA().delete((int)id);
        }
    }


    public class MA_TIPO_DOMICILIOBL : IRepository
    {
        public int create<T>(T entity)
        {
            return new MA_TIPO_DOMICILIODA().create((MA_TIPO_DOMICILIO)(object)entity);
        }
        public List<T> GetAll<T>()
        {
            return (List<T>)(object)new MA_TIPO_DOMICILIODA().GetAll(); ;
        }
        public T GetById<T>(object id)
        {
            return (T)(object)new MA_TIPO_DOMICILIODA().GetById((int)id);
        }
        public int edit<T>(T entity)
        {
            return new MA_TIPO_DOMICILIODA().edit((MA_TIPO_DOMICILIO)(object)entity);
        }
        public int delete(object id)
        {
            return new MA_TIPO_DOMICILIODA().delete((int)id);
        }

    }


    public class MA_OCUPACIONBL : IRepository
    {
        public int create<T>(T entity)
        {
            return new MA_OCUPACIONDA().create((MA_OCUPACION)(object)entity);
        }

        public List<T> GetAll<T>()
        {
            return (List<T>)(object)new MA_OCUPACIONDA().GetAll(); ;
        }
        public T GetById<T>(object id)
        {
            return (T)(object)new MA_OCUPACIONDA().GetById((int)id);
        }
        public int edit<T>(T entity)
        {
            return new MA_OCUPACIONDA().edit((MA_OCUPACION)(object)entity);
        }
        public int delete(object id)
        {
            return new MA_OCUPACIONDA().delete((int)id);
        }

    }
}
