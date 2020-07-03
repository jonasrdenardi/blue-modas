import { EventEmitter } from '@angular/core';
import { Produto } from 'src/produtos/produto';
import { CestaProduto } from 'src/cestaProduto/cestaProduto';
import { Cliente } from 'src/clientes/cliente';

export class CestaService {

    public static produtosCesta: CestaProduto[] = [];
    public static produtos: Produto[] = [];
    public static qtdProdutos: number = 0;
    public static cliente: Cliente;

    private static emitters: {
        [nomeEvento: string]: EventEmitter<any>
    } = {}

    static get(nomeEvento: string): EventEmitter<any> {
        if (!this.emitters[nomeEvento])
            this.emitters[nomeEvento] = new EventEmitter<any>();
        return this.emitters[nomeEvento];
    }

    static addCestaProduto(produto: Produto, cestaProduto : CestaProduto) {

        var prodCesta = this.produtosCesta.find(x => x.IdProduto == cestaProduto.IdProduto);
        if (!prodCesta) {
            this.produtosCesta.push(cestaProduto);
            this.produtos.push(produto);
            this.qtdProdutos += cestaProduto.Quantidade;
        } else {
            this.qtdProdutos += cestaProduto.Quantidade;
            prodCesta.Quantidade += cestaProduto.Quantidade;
        }

        this.get('alterCesta').emit(null); 
    }

    static UpdateCestaProduto(cestaProduto : CestaProduto, qtd : number) {
        cestaProduto.Quantidade = qtd;
        this.qtdProdutos = this.produtosCesta.reduce((soma, pc) => soma + pc.Quantidade, 0);

        this.get('alterCesta').emit(null); 
    }

    static RemoveCestaProduto(cestaProduto : CestaProduto) {

        var prod = this.produtos.find(x => x.Id == cestaProduto.IdProduto);
        var indexProd = this.produtos.indexOf(prod);
        this.produtos.splice(indexProd, 1);
    
        var indexProd = this.produtosCesta.indexOf(cestaProduto);
        this.produtosCesta.splice(indexProd, 1);
        
        this.qtdProdutos = this.produtosCesta.reduce((soma, pc) => soma + pc.Quantidade, 0);

        this.get('alterCesta').emit(null); 
    }

    static limparCesta(){
        this.produtosCesta = [];
        this.produtos = [];
        this.qtdProdutos = 0;
                
        this.get('alterCesta').emit(null); 
    }

}