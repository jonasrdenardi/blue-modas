import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Produto } from './produto';
import { Observable } from 'rxjs';


@Injectable()
export class ProdutoService{

    constructor(private http: HttpClient){}

    protected url: string = "https://localhost:44336/api/";

    obterProdutos() : Observable<Produto[]>{
        return this.http.get<Produto[]>(this.url + "produto");
    }
}