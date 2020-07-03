using BlueModas.Domain.DTOs;
using BlueModas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Domain.Interfaces
{
    public interface IServicePedido : IBaseService<Pedido> 
    {
        DTO_PedidoCompleto InsertPedidoCompleto(DTO_PedidoCompleto obj);
    }
}
