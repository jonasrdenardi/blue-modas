using BlueModas.Domain.Entities;
using BlueModas.Domain.Interfaces;
using BlueModas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueModas.Infra.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente, int>, IRepositoryCliente
    {
        public ClienteRepository(BlueModasContext context) : base(context) { }

        public void Remove(int id) => base.Delete(id);

        public void Save(Cliente obj)
        {
            if (obj.Id == 0)
                base.Insert(obj);
            else
                base.Update(obj);
        }

        public Cliente GetById(int id) => base.Select(id);

        public Cliente GetByEmail(string email) => _blueModasContext.Cliente.FirstOrDefault(x => x.Email.Equals(email));

        public IList<Cliente> GetAll() => base.Select();

    }
}
