using BlueModas.Domain.Entities;
using BlueModas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Services.Services
{
    public class ProdutoService : IServiceProduto
    {
        private readonly IRepositoryProduto _repository;

        public ProdutoService(IRepositoryProduto repository) =>  _repository = repository;

        public void Delete(int id) => _repository.Remove(id);

        public IList<Produto> GetAll() => _repository.GetAll();

        public Produto GetById(int id) => _repository.GetById(id);
        
        public Produto Insert(Produto obj)
        {
            _repository.Save(obj);
            return obj;
        }

        public Produto Update(Produto obj)
        {
            _repository.Save(obj);
            return obj;
        }
    }
}
