using BlueModas.Domain.Entities;
using BlueModas.Domain.Interfaces;
using BlueModas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Infra.Data.Repository
{
    public class CestaRepository : BaseRepository<Cesta, int>, IRepositoryCesta
    {
        public CestaRepository(BlueModasContext context) : base(context) { }

        public void Remove(int id) => base.Delete(id);

        public void Save(Cesta obj)
        {
            if (obj.Id == 0)
                base.Insert(obj);
            else
                base.Update(obj);
        }

        public Cesta GetById(int id) => base.Select(id);

        public IList<Cesta> GetAll() => base.Select();

    }
}
