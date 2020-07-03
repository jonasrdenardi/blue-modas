import { Component, OnInit } from '@angular/core';
import { CestaService } from "src/app/cesta/cesta.service";
import { Pedido } from 'src/pedidos/pedido';
import { PedidoProduto } from 'src/pedidoProduto/pedidoProduto';
import { PedidoService } from 'src/pedidos/pedidos.service';
import { DTO_PedidoCompleto } from 'src/pedidos/DTO_PedidoCompleto';
import { Produto } from 'src/produtos/produto';
import { Router } from '@angular/router';
import { Cliente } from 'src/clientes/cliente';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styles: [
  ]
})
export class PedidoComponent implements OnInit {

  public dtoPP = new DTO_PedidoCompleto();
  public produtos: Produto[] = [];
  public cliente = new Cliente();

  constructor(private pedidoService: PedidoService, private router: Router) { 
    this.dtoPP.Pedido = new Pedido();
    this.dtoPP.PedidoProduto = new Array<PedidoProduto>();
    this.produtos = Object.assign([], CestaService.produtos);
    this.cliente = CestaService.cliente;
  }

  ngOnInit(): void {
    this.efetivarPedido();
  }

  efetivarPedido() {
    if (CestaService.produtosCesta.length == 0) {
      alert("Nenhum produto adicionado a cesta");
      this.router.navigate(['/produtos']);
    } else {

      var pedido = new Pedido();
      pedido.IdCliente = CestaService.cliente.Id;
      pedido.DataCriacao = new Date();

      var pp = CestaService.produtosCesta.map(cp => {
                var pedProd = new PedidoProduto();
                pedProd.IdProduto = cp.IdProduto;
                pedProd.Quantidade = cp.Quantidade;
                return pedProd;
      });
      
      var dto = new DTO_PedidoCompleto();
      dto.Pedido = pedido;
      dto.PedidoProduto = pp;

      this.pedidoService.add(dto)
      .subscribe(
      dtoPP => {
        this.dtoPP = dtoPP;
        this.limparCesta();
      },
      error => console.log(error)
    );

    }
  }

  getDescricao(idProduto: number) {
    return this.produtos.find(x => x.Id == idProduto).Descricao;
  }

  getImagem(idProduto: number) {
    return this.produtos.find(x => x.Id == idProduto).Imagem;
  }

  getValorUn(idProduto: number) {
    return this.produtos.find(x => x.Id == idProduto).Valor;
  }

  getTotalPedido() {    
    return this.dtoPP.PedidoProduto.reduce((soma, pp) => soma + this.getTotalProduto(pp), 0);
  }

  getTotalProduto(pp: PedidoProduto) {
    return this.produtos.find(x => x.Id == pp.IdProduto).Valor * pp.Quantidade;
  }

  limparCesta(){
    CestaService.limparCesta();
  }
}
