import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Produto } from 'src/produtos/produto';
import { ProdutoService } from 'src/produtos/produtos.service';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-lista-produto',
  templateUrl: './lista-produto.component.html',
  styleUrls: ['./lista-produto.component.css'],
})
export class ListaProdutoComponent implements OnInit {

  constructor(private produtoService: ProdutoService) { }

  public produtos: Produto[];
  // public cesta: number = 0;
  @Output() produtoAdd = new EventEmitter();

  ngOnInit(): void {
    this.produtoService.obterProdutos()
      .subscribe(
        produtos => {
          this.produtos = produtos;
          console.log(produtos);
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
      (<HTMLSelectElement>document.getElementById(idProduto)).value = String(++qtd);
    }
    
  }

   adicionarNaCesta(idProduto : string){
     var el = (<HTMLSelectElement>document.getElementById(idProduto));
    var qtd = Number(el.value);

    if(qtd > 0){
      el.value = String(++qtd);
    }

    // this.cesta += Number(el.value);
    el.value = "0";
  }

  addCesta(produto : Produto){
    this.produtoAdd.emit(produto);
  }

}


