import { Component, OnInit, EventEmitter } from '@angular/core';
import { Produto } from 'src/produtos/produto';
import { ProdutoService } from 'src/produtos/produtos.service';
import { error } from '@angular/compiler/src/util';

import { CestaService } from "src/app/cesta/cesta.service";
import { CestaProduto } from 'src/cestaProduto/cestaProduto';

@Component({
  selector: 'app-lista-produto',
  templateUrl: './lista-produto.component.html',
  styleUrls: ['./lista-produto.component.css'],
})
export class ListaProdutoComponent implements OnInit {

  constructor(private produtoService: ProdutoService) { }

  public produtos: Produto[];
  // public cesta: number = 0;

  ngOnInit(): void {
    this.produtoService.obterProdutos()
      .subscribe(
        produtos => {
          this.produtos = produtos;
        },
        error => console.log(error)
      );
  }

  aumentar(idProduto : string){
    var qtd = Number((<HTMLSelectElement>document.getElementById(idProduto)).value);
    (<HTMLSelectElement>document.getElementById(idProduto)).value = String(++qtd);
  }

  diminuir(idProduto : string){
    var qtd = Number((<HTMLSelectElement>document.getElementById(idProduto)).value);
    if(qtd > 0){
      (<HTMLSelectElement>document.getElementById(idProduto)).value = String(--qtd);
    }
    
  }

  addCesta(produto : Produto){
    var el = (<HTMLSelectElement>document.getElementById(String(produto.Id)));
    var qtd = Number(el.value);
    var cestaProduto = new CestaProduto();
    cestaProduto.IdProduto = produto.Id;
    cestaProduto.Quantidade = qtd;
    CestaService.addCestaProduto(produto, cestaProduto);
  }

}


