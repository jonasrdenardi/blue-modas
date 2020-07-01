CREATE TABLE Produto(
Id			INT IDENTITY(1,1),
Descricao	VARCHAR(255),
Valor		FLOAT, 
Imagem		IMAGE,
	CONSTRAINT PK_Produto PRIMARY KEY(Id)
);

DROP TABLE Produto;

INSERT INTO Produto
SELECT 'Calça Jeans Feminina', 130.45, BULKCOLUMN FROM OPENROWSET(BULK 'C:\Users\Public\Downloads\imagens\calca_jeans_feminina.jpg', SINGLE_BLOB) AS IMAGEM;
INSERT INTO Produto
SELECT 'Calça Jeans Masculina', 122.87, BULKCOLUMN FROM OPENROWSET(BULK 'C:\Users\Public\Downloads\imagens\calca_jeans_masculina.jpg', SINGLE_BLOB) AS IMAGEM;
INSERT INTO Produto
SELECT 'Camisa Masculina', 87.00, BULKCOLUMN FROM OPENROWSET(BULK 'C:\Users\Public\Downloads\imagens\camisa_masculina.jpg', SINGLE_BLOB) AS IMAGEM;
INSERT INTO Produto
SELECT 'Camisa Femina', 69.99, BULKCOLUMN FROM OPENROWSET(BULK 'C:\Users\Public\Downloads\imagens\camiseta_feminina.jpg', SINGLE_BLOB) AS IMAGEM;
INSERT INTO Produto
SELECT 'Sapato Feminino', 89.90, BULKCOLUMN FROM OPENROWSET(BULK 'C:\Users\Public\Downloads\imagens\sapato_feminino.jpg', SINGLE_BLOB) AS IMAGEM;
INSERT INTO Produto
SELECT 'Moletom Masculino', 175.99, BULKCOLUMN FROM OPENROWSET(BULK 'C:\Users\Public\Downloads\imagens\moletom_masculino.jpg', SINGLE_BLOB) AS IMAGEM;

select * from Produto a;

delete Produto;












