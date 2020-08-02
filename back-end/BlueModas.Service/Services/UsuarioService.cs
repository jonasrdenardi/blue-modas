using BlueModas.Domain.Entities;
using BlueModas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Services.Services
{
    public class UsuarioService : IServiceUsuario
    {
        private readonly IRepositoryUsuario _repository;

        public UsuarioService(IRepositoryUsuario repository) => _repository = repository;

        public void Delete(int id) => _repository.Remove(id);

        public IList<Usuario> GetAll() => _repository.GetAll();

        public Usuario GetById(int id) => _repository.GetById(id);

        public Usuario GetByNomeSenha(string nome, string senha) => _repository.GetByNomeSenha(nome, senha);

        public Usuario Insert(Usuario obj)
        {
            _repository.Save(obj);
            return obj;
        }

        public Usuario Update(Usuario obj)
        {
            _repository.Save(obj);
            return obj;
        }
    }
}
