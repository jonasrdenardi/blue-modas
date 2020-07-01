using BlueModas.Domain.Entities;
using BlueModas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Services.Services
{
    public class CestaService : IServiceCesta
    {
        private readonly IRepositoryCesta _repository;

        public CestaService(IRepositoryCesta repository) =>  _repository = repository;

        public void Delete(int id) => _repository.Remove(id);

        public IList<Cesta> GetAll() => _repository.GetAll();

        public Cesta GetById(int id) => _repository.GetById(id);
        
        public Cesta Insert(Cesta obj)
        {
            _repository.Save(obj);
            return obj;
        }

        public Cesta Update(Cesta obj)
        {
            _repository.Save(obj);
            return obj;
        }
    }
}
