CREATE TABLE CestaProduto(
IdCesta			INT,
IdProduto    	INT,
Quantidade		INT,
	CONSTRAINT PK_CestaProduto PRIMARY KEY(IdCesta,IdProduto),
	CONSTRAINT FK_CestaProduto_IdCesta FOREIGN KEY(IdCesta)
		REFERENCES Cesta(Id),
	CONSTRAINT FK_CestaProduto_IdProduto FOREIGN KEY(IdProduto)
		REFERENCES Produto(Id)
);

DROP TABLE CestaProduto;