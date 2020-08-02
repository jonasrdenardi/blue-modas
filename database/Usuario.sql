CREATE TABLE Usuario(
Id			INT IDENTITY(1,1),
Nome    	VARCHAR(255),
Senha		VARCHAR(255), 
Regra		VARCHAR(255),
	CONSTRAINT PK_Usuario PRIMARY KEY(Id)
);

INSERT INTO Usuario
VALUES
('jonas','jonas','manager'),
('robin','robin','employee'),
('batman','batman','manager')
