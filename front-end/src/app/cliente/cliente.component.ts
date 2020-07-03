import { Component, OnInit } from '@angular/core';
import { Cliente } from 'src/clientes/cliente';
import { ClienteService } from 'src/clientes/clientes.service';
import { Router } from '@angular/router';
import { CestaService } from '../cesta/cesta.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styles: [
  ]
})
export class ClienteComponent implements OnInit {

  public nome : string = "";
  public email : string = "";
  public telefone : string = "";

  constructor(private clienteService: ClienteService, private router: Router) { }

  ngOnInit(): void {
  }

  efetivarPedido(){

    if(!this.nome || !this.email || !this.telefone){
      alert("Preencha todos os campos!");
      return;
    }

    var cliente = new Cliente();
    cliente.Nome = this.nome;
    cliente.Email = this.email;
    cliente.Telefone = this.telefone;

    this.clienteService.addOrUpdate(cliente)
      .subscribe(
      clienteAdd => {
        CestaService.cliente = clienteAdd;
        this.router.navigate(['/pedido']);
      },
      error => console.log(error)
    );

  }

}
