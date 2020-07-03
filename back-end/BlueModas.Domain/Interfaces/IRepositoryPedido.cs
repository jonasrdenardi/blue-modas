using BlueModas.Domain.DTOs;
using BlueModas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
                    
namespace BlueModas.Domain.Interfaces
{
    public interface IRepositoryPedido : IBaseRepository<Pedido> 
    {
        void InsertPedidoCompleto(DTO_PedidoCompleto pedidoCompleto);
    }
}
