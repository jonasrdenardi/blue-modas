import { Component, OnInit} from '@angular/core';
import { CestaProduto } from 'src/cestaProduto/cestaProduto';
import { CestaService } from "src/app/cesta/cesta.service";

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html'
})
export class MenuComponent implements OnInit {
  
  public produtosCesta: CestaProduto[] = [];
  public qtdProdutos: number = 0;
  
  constructor(){} 

  ngOnInit(): void {
    CestaService.get('alterCesta').subscribe(param => this.addCestaProduto());
  }

  addCestaProduto(){
    this.produtosCesta = CestaService.produtosCesta;
    this.qtdProdutos = CestaService.qtdProdutos;
  }

}
