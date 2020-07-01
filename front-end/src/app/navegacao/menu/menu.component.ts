import { Component, Input } from '@angular/core';
import { Produto } from 'src/produtos/produto';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html'
})
export class MenuComponent{
   
  @Input() cestaProdutos : Produto[] = [];

}
