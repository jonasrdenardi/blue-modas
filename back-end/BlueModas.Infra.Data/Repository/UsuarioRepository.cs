using BlueModas.Domain.Entities;
using BlueModas.Domain.Interfaces;
using BlueModas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueModas.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario, int>, IRepositoryUsuario
    {
        public UsuarioRepository(BlueModasContext context) : base(context) { }

        public void Remove(int id) => base.Delete(id);

        public void Save(Usuario obj)
        {
            if (obj.Id == 0)
                base.Insert(obj);
            else
                base.Update(obj);
        }

        public Usuario GetById(int id) => base.Select(id);

        public IList<Usuario> GetAll() => base.Select();

        public Usuario GetByNomeSenha(string nome, string senha)
             => _blueModasContext.Usuario.FirstOrDefault(x => x.Nome.Equals(nome) && x.Senha.Equals(senha));
    }
}
