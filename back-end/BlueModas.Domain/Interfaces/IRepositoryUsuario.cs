using BlueModas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Domain.Interfaces
{
    public interface IRepositoryUsuario : IBaseRepository<Usuario>
    {
        Usuario GetByNomeSenha(string nome, string senha);
    }
}
