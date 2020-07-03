import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Cliente } from './cliente';
import { Observable } from 'rxjs';


@Injectable()
export class ClienteService{

    constructor(private http: HttpClient){}

    protected url: string = "https://localhost:44336/api/";
    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      }


     addOrUpdate(cliente : Cliente) : Observable<Cliente>{
        var retorno = this.http.post<Cliente>(this.url + "cliente", JSON.stringify(cliente), this.httpOptions);
        return retorno;
     }
}