import { Component, OnInit } from '@angular/core';
import { CestaService } from "src/app/cesta/cesta.service";
import { ActivatedRoute } from '@angular/router';
import { CestaProduto } from 'src/cestaProduto/cestaProduto';
import { Produto } from 'src/produtos/produto';

@Component({
  selector: 'app-cesta',
  templateUrl: './cesta.component.html',
  styles: [
  ]
})
export class CestaComponent implements OnInit {

  public produtosCesta: CestaProduto[] = [];
  public produtos: Produto[] = [];

  constructor() { }

  ngOnInit(): void {
    this.produtosCesta = CestaService.produtosCesta;
    this.produtos = CestaService.produtos;
  }

  getDescricao(idProduto: number) {
    return this.produtos.find(x => x.Id == idProduto).Descricao;
  }

  getImagem(idProduto: number) {
    return this.produtos.find(x => x.Id == idProduto).Imagem;
  }

  aumentar(idProduto: string) {
    var qtd = Number((<HTMLSelectElement>document.getElementById(idProduto)).value);
    (<HTMLSelectElement>document.getElementById(idProduto)).value = String(++qtd);
  }

  diminuir(idProduto: string) {
    var qtd = Number((<HTMLSelectElement>document.getElementById(idProduto)).value);
    if (qtd > 0) {
      (<HTMLSelectElement>document.getElementById(idProduto)).value = String(--qtd);
    }
  }

  addCesta(produto: Produto) {
    var el = (<HTMLSelectElement>document.getElementById(String(produto.Id)));
    var qtd = Number(el.value);
    var cestaProduto = new CestaProduto();
    cestaProduto.IdProduto = produto.Id;
    cestaProduto.Quantidade = qtd;
    CestaService.addCestaProduto(produto, cestaProduto);
  }

  atualizar(cestaProduto: CestaProduto) {
    var el = (<HTMLSelectElement>document.getElementById(String(cestaProduto.IdProduto)));
    var qtd = Number(el.value);

    CestaService.UpdateCestaProduto(cestaProduto, qtd);
  }

  remover(cestaProduto: CestaProduto) {
    CestaService.RemoveCestaProduto(cestaProduto);
  }

}
