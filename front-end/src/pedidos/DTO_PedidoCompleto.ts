import { Pedido } from './pedido';
import { PedidoProduto } from 'src/pedidoProduto/pedidoProduto';

export class DTO_PedidoCompleto{
    Pedido: Pedido;
    PedidoProduto: PedidoProduto[];
}