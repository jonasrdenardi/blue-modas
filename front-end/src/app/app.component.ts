import { Component, Input } from '@angular/core';
import { Produto } from 'src/produtos/produto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  
  public cestaAC: Produto[] = [];

  title = 'Blue Modas';

  addCesta(produtoCesta : Produto){
    this.cestaAC.push(produtoCesta)
  }
}
