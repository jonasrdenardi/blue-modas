using BlueModas.Domain.Entities;
using BlueModas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Services.Services
{
    public class ClienteService : IServiceCliente
    {
        private readonly IRepositoryCliente _repository;

        public ClienteService(IRepositoryCliente repository) =>  _repository = repository;

        public void Delete(int id) => _repository.Remove(id);

        public IList<Cliente> GetAll() => _repository.GetAll();

        public Cliente GetById(int id) => _repository.GetById(id);
        
        public Cliente Insert(Cliente obj)
        {
            _repository.Save(obj);
            return obj;
        }

        public Cliente Update(Cliente obj)
        {
            _repository.Save(obj);
            return obj;
        }
    }
}
