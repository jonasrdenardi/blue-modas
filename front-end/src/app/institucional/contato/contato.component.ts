import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contato',
  templateUrl: './contato.component.html'
})
export class ContatoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    var bttn = document.getElementById("btnSubmit");  
    bttn.onclick = function() {  
     alert("Email enviado");
    };
  }

}
