CREATE TABLE PedidoProduto(
IdPedido		INT,
IdProduto    	INT,
Quantidade		INT,
	CONSTRAINT PK_PedidoProduto PRIMARY KEY(IdPedido,IdProduto),
	CONSTRAINT FK_PedidoProduto_IdPedido FOREIGN KEY(IdPedido)
		REFERENCES Pedido(Id),
	CONSTRAINT FK_PedidoProduto_IdProduto FOREIGN KEY(IdProduto)
		REFERENCES Produto(Id)
);

DROP TABLE PedidoProduto;