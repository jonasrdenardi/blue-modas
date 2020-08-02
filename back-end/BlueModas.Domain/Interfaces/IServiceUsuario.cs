using BlueModas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Domain.Interfaces
{
    public interface IServiceUsuario : IBaseService<Usuario>
    {
        Usuario GetByNomeSenha(string nome, string senha);
    }

}
