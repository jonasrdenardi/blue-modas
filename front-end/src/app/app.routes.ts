import {Routes} from '@angular/router';
import { ContatoComponent } from './institucional/contato/contato.component';
import { SobreComponent } from './institucional/sobre/sobre.component';
import { ListaProdutoComponent } from './produtos/lista-produto/lista-produto.component';
import { CestaComponent } from './cesta/cesta.component';
import { ClienteComponent } from './cliente/cliente.component';
import { PedidoComponent } from './pedido/pedido.component';

export const rootRouterConfig: Routes = [
    {path: '', redirectTo: '/produtos', pathMatch: 'full'},
    {path: 'contato', component: ContatoComponent},
    {path: 'sobre', component: SobreComponent},
    {path: 'produtos', component: ListaProdutoComponent},
    {path: 'cesta', component: CestaComponent},
    {path: 'cliente', component: ClienteComponent},
    {path: 'pedido', component: PedidoComponent},
];

