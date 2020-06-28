using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Domain.Interfaces
{
    public interface IBaseService<T>
    {
        T Insert(T obj);

        T Update(T obj);

        void Delete(int id);

        T GetById(int id);

        IList<T> GetAll();
    }
}
