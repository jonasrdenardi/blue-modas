using BlueModas.Domain.Entities;
using BlueModas.Domain.Interfaces;
using BlueModas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Infra.Data.Repository
{
    public class PedidoRepository : BaseRepository<Pedido, int>, IRepositoryPedido
    {
        public PedidoRepository(BlueModasContext context) : base(context) { }

        public void Remove(int id) => base.Delete(id);

        public void Save(Pedido obj)
        {
            if (obj.Id == 0)
                base.Insert(obj);
            else
                base.Update(obj);
        }

        public Pedido GetById(int id) => base.Select(id);

        public IList<Pedido> GetAll() => base.Select();

    }
}
