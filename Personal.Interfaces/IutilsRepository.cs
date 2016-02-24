using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interfaces
{
    public interface IutilsRepository
    {
        int create<T>(T x);
        //List<T> GetID<T>(int id);
        // List<T> GetAll<T>();
        //int update<T>(T x);
        //int delete(int id);
    }

    public interface IRepository
    {
        List<T> GetAll<T>();
        int create<T>(T x);
        T GetById<T>(object id);
        int edit<T>(T x);
        int delete(object id);
    }


}
