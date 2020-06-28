CREATE TABLE Cliente(
Id			INT IDENTITY(1,1),
Nome		VARCHAR(255),
Email		VARCHAR(255) UNIQUE,
Telefone	VARCHAR(255),
	CONSTRAINT PK_Cliente PRIMARY KEY(Id),
);


INSERT INTO Cliente
VALUES
('Jonas Denardi', 'jonas_denardi@email.com', '(19) 99874-1234'),
('João dos Santos', 'joao_santos@email.com', '(19) 95467-2156'),
('Fernando Oliveira', 'fernando_oliveira@email.com', '(19) 94547-2354')

select a.* from Cliente a;

delete Cliente