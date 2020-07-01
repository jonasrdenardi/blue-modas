import { Component, Input } from '@angular/core';
import { Produto } from 'src/produtos/produto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  
  public cesta: number = 0;

  title = 'Blue Modas';

  addCesta(){
    this.cesta++;
    console.log(this.cesta);
  }
}
