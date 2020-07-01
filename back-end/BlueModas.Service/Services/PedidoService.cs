using BlueModas.Domain.Entities;
using BlueModas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Services.Services
{
    public class PedidoService : IServicePedido
    {
        private readonly IRepositoryPedido _repository;

        public PedidoService(IRepositoryPedido repository) =>  _repository = repository;

        public void Delete(int id) => _repository.Remove(id);

        public IList<Pedido> GetAll() => _repository.GetAll();

        public Pedido GetById(int id) => _repository.GetById(id);
        
        public Pedido Insert(Pedido obj)
        {
            _repository.Save(obj);
            return obj;
        }

        public Pedido Update(Pedido obj)
        {
            _repository.Save(obj);
            return obj;
        }
    }
}
