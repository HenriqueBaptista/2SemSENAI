--DDL- Data Defifinition Language

-- criar o banco de dados
CREATE DATABASE [Event+_Tarde]

USE [Event+_Tarde]

-- criar as tabelas
CREATE TABLE TiposDeUsuario
(
	IdTipoDeUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE TiposDeEvento
(
	IdTipoDeEvento INT PRIMARY KEY IDENTITY,
	TituloTipoEvento VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Instituicao
(
	IdInstituicao INT PRIMARY KEY IDENTITY,
	CNPJ CHAR(14) NOT NULL UNIQUE,
	Endereco VARCHAR(200) NOT NULL,
	NomeFantasia VARCHAR(200) NOT NULL
)

-- criar tabelas com foreign keys
CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoDeUsuario INT FOREIGN KEY REFERENCES TiposDeUsuario(IdTipoDeUsuario) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL UNIQUE,
	Senha VARCHAR(50) NOT NULL
)

CREATE TABLE Evento
(
	IdEvento INT PRIMARY KEY IDENTITY,
	IdTipoDeEvento INT FOREIGN KEY REFERENCES TiposDeEvento(IdTipoDeEvento) NOT NULL,
	IdInstituicao INT FOREIGN KEY REFERENCES  Instituicao(IdInstituicao) NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	Descricao VARCHAR(200) NOT NULL,
	DataEvento DATE NOT NULL,
	HorarioEvento TIME NOT NULL
)

CREATE TABLE PresencasEvento
(
IdPresencaEvento INT PRIMARY KEY IDENTITY,
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
Situacao BIT DEFAULT(0)
)

CREATE TABLE ComentarioEvento
(
	IdComentarioEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	Descricao VARCHAR(200) NOT NULL,
	Exibe BIT DEFAULT(0)
)





-- DML - Data Manipulation Language

-- INSERT INTO TiposDeUsuario (TituloTipoUsuario) VALUES ('Administrador'), ('Comum');
-- INSERT INTO TiposDeEvento (TituloTipoEvento) VALUES ('SQL Server');
-- INSERT INTO Instituicao (CNPJ, Endereco, NomeFantasia ) VALUES ('23928566000183' , 'Rua Niteroi, 180 São Caetano do Sul', 'DevSchool');
-- INSERT INTO Usuario (IdTipoDeUsuario, Nome, Email, Senha) VALUES (1,'Eduardo Costa','edu@admin.com','123');
-- INSERT INTO Evento (IdTipoDeEvento, IdInstituicao, Nome, Descricao, DataEvento, HorarioEvento)
-- VALUES (1, 1, 'Intensivão do SQL Server', 'Aprenda os principais conceitos de SQL Server na prática', '2023-09-11', '15:30:00');
-- INSERT INTO PresencasEvento (IdUsuario, IdEvento, Situacao) VALUES (1, 1, 1)
-- INSERT INTO ComentarioEvento (IdUsuario, IdEvento, Descricao, Exibe)
-- VALUES (1, 1, 'Bro, o negócio é tão dahora que a careca veio a tona!', 1)


-- visualizar tabelas
SELECT * FROM Usuario
SELECT * FROM Evento
SELECT * FROM ComentarioEvento
SELECT * FROM PresencasEvento
SELECT * FROM Instituicao
SELECT * FROM TiposDeEvento
SELECT * FROM TiposDeUsuario

-- DQL - Data Query Language

SELECT
	Usuario.Nome AS [Nome do usuário],
	TiposDeUsuario.TituloTipoUsuario AS [Tipo de usuário],
	Evento.DataEvento AS [Data do evento],
	CONCAT	(Instituicao.NomeFantasia, ' - ', Instituicao.Endereco) AS [Local do evento],
	TiposDeEvento.TituloTipoEvento AS [Tipo de evento],
	Evento.Nome AS [Nome do evento],
	Evento.Descricao AS [Descrição do evento],
	CASE WHEN PresencasEvento.Situacao = 1 THEN 'Confirmado' ELSE 'Não confirmado' END AS [Presença confirmada?],
	ComentarioEvento.Descricao AS [Comentário]
FROM Evento
	INNER JOIN TiposDeEvento 
	ON Evento.IdTipoDeEvento = TiposDeEvento.IdTipoDeEvento
	INNER JOIN Instituicao
	ON Evento.IdInstituicao = Instituicao.IdInstituicao
	INNER JOIN PresencasEvento
	ON Evento.IdEvento = PresencasEvento.IdEvento
	INNER JOIN Usuario
	ON Usuario.IdUsuario = PresencasEvento.IdUsuario
	INNER JOIN TiposDeUsuario
	ON TiposDeUsuario.IdTipoDeUsuario = Usuario.IdTipoDeUsuario
	LEFT JOIN ComentarioEvento
	ON ComentarioEvento.IdUsuario = Usuario.IdUsuario
