CREATE TABLE Cliente(
Id			INT IDENTITY(1,1),
Nome		VARCHAR(255),
Email		VARCHAR(255),
Telefone	VARCHAR(255),
	CONSTRAINT PK_Cliente PRIMARY KEY(Id),
);
