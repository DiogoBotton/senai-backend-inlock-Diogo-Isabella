CREATE DATABASE InLock_Tarde;
go
USE InLock_Tarde;
go
CREATE TABLE TiposUsuarios (
	Id INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR (200),
);


CREATE TABLE Estudios (
	Id INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR (200) NOT NULL
);

CREATE TABLE Jogos (
	Id INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (200) ,
	Descricao VARCHAR (200),
	DataLancamento DATE,
	Valor MONEY,
	EstudioId INT FOREIGN KEY REFERENCES Estudios(Id)
);

CREATE TABLE Usuarios (
	Id INT PRIMARY KEY IDENTITY,
	Email VARCHAR (200),
	Senha VARCHAR (200),
	TipoUsuarioId INT FOREIGN KEY REFERENCES TiposUsuarios(Id)
);
INSERT INTO TiposUsuarios (Descricao)
VALUES ('Administrador') 
, ('Cliente');


INSERT INTO Estudios (Descricao)
VALUES ('Blizzard') ,
('Rockstar Studio'),
('Square Enix');

SELECT * FROM Estudios;

INSERT INTO Usuarios (Email, Senha, TipoUsuarioId)
VALUES ('admi@admin.com' , 'admin' , 1),
('cliente@cliente.com', 'cliente', 2);


INSERT INTO Jogos (Nome, Descricao, DataLancamento, Valor, EstudioId)
VALUES ('Diablo 3', 'é um jogo que contém bastante ação e é
viciante, seja você um novato ou um fã', '2012/05/15', 99.00, 1),
('Red Dead Redemption II', 'jogo eletrônico de ação-aventura western',
'2018/10/26',120.00, 2);