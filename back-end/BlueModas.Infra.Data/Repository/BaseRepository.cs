using BlueModas.Domain.Entities;
using BlueModas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueModas.Infra.Data.Repository
{
    public class BaseRepository<T, B> where T : BaseEntity<B>
    {
        protected readonly BlueModasContext _blueModasContext;

        public BaseRepository(BlueModasContext BlueModasContext)
        {
            _blueModasContext = BlueModasContext;
        }

        protected virtual void Insert(T obj)
        {
            _blueModasContext.Set<T>().Add(obj);
            _blueModasContext.SaveChanges();
        }

        protected virtual void Update(T obj)
        {
            _blueModasContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _blueModasContext.SaveChanges();
        }

        protected virtual void Delete(int id)
        {
            _blueModasContext.Set<T>().Remove(Select(id));
            _blueModasContext.SaveChanges();
        }

        protected virtual IList<T> Select() =>
            _blueModasContext.Set<T>().ToList();

        protected virtual T Select(int id) =>
            _blueModasContext.Set<T>().Find(id);
    }
}
