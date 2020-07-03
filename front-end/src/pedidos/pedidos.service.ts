import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Pedido } from './pedido';
import { Observable } from 'rxjs';
import { DTO_PedidoCompleto } from './DTO_PedidoCompleto';


@Injectable()
export class PedidoService{

    constructor(private http: HttpClient){}

    protected url: string = "https://localhost:44336/api/";
    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    
     add(pedidoCompleto : DTO_PedidoCompleto) : Observable<DTO_PedidoCompleto>{
        var retorno = this.http.post<DTO_PedidoCompleto>(this.url + "pedido/pedidocompleto", JSON.stringify(pedidoCompleto), this.httpOptions);
        return retorno;
     }
}