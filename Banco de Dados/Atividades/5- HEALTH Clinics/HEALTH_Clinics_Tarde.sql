------ DDL - Data Definition Language
CREATE DATABASE HEALTH_Clinics_Tarde

USE HEALTH_Clinics_Tarde

-- criar tabelas do banco de dados
/* CREATE TABLE TipoUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(20) NOT NULL
) */

/* CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario) NOT NULL,
	Email VARCHAR(40),
	Senha VARCHAR (30)
) */

/* CREATE TABLE Paciente
(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	Nome VARCHAR(100) NOT NULL
) */

/* CREATE TABLE Especialidade
(
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	TituloEspecialidade VARCHAR(50) NOT NULL
) */

/*CREATE TABLE Medico
(
	IdMedico INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade) NOT NULL,
	Nome VARCHAR(100) NOT NULL
) */

/* CREATE TABLE TipoConsulta
(
	IdTipoConsulta INT PRIMARY KEY IDENTITY,
	TituloTipoConsulta VARCHAR (60) NOT NULL
) */

/* CREATE TABLE Clinica
(
	IdClinica INT PRIMARY KEY IDENTITY,
	CNPJ CHAR(14) NOT NULL,
	NomeFantasia VARCHAR(30) NOT NULL,
	Endereço VARCHAR(100) NOT NULL
) */

/* CREATE TABLE Consulta
(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdTipoConsulta INT FOREIGN KEY REFERENCES TipoConsulta(IdTipoConsulta) NOT NULL,
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL,
	IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico) NOT NULL,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
	DataConsulta VARCHAR(15) NOT NULL,
	HorarioConsulta VARCHAR(10) NOT NULL,
	Prontuário VARCHAR(300) NOT NULL
) */


------ DML - Data Manipulation Language

/*INSERT INTO TipoUsuario(TituloTipoUsuario)
VALUES
('Administrador'),
('Médico'),
('Comum')*/

/*INSERT INTO Especialidade(TituloEspecialidade)
VALUES
('Dermatologista'),
('Cirurgião'),
('Oftalmologista'),
('Ortopedista'),
('Pediatra'),
('Psiquiatra'),
('Cardiologista')*/

/*INSERT INTO TipoConsulta
VALUES
('Exame dermatológico'),
('Cirurgia'),
('Exame oftalmolígico'),
('Exame ortopédico'),
('Puericultura'),
('Avaliação psiquiátrica'),
('Check-up cardiológico') */

/*INSERT INTO Clinica(CNPJ, NomeFantasia, Endereço)
VALUES
('06144822000122', 'HEALTH Clinics', 'Avenida Unknow 000 - Algum lugar do mundo') */

/*INSERT INTO Usuario(IdTipoUsuario, Email, Senha)
VALUES
(1, 'admino@123', '12345'),
(2, 'medico@134', '244411'),
(2, 'medico200@arroba', '***uau'),
(2, 'psicomantis@mgs', 'megamente'),
(2, 'corazobatente@heart', 'tumtum'),
(2, 'infancia@child', 'arroba@'),
(2, '20pegar70fumar', 'biggas'),
(2, 'cegueta@bah', '0gentileza'),
(3, 'FazuelliFerreira@L', 'FazOL'),
(3, 'RicardinhoMiles@21', 'agaraga'),
(3, 'GameShark@333', 'cheater'),
(3, 'someone12@email.com', '******'),
(3, 'mrWhite@BrkBd', 'Ox'),
(3, 'macacoAranhaColombiano@ben10', 'UAAA')*/

/*INSERT INTO Paciente(IdUsuario, Nome, Idade)
VALUES
(9, 'Fernanda Fazuelli Ferreira', '24'),
(10, 'Miles Ricardo', '18'),
(11 ,'Lucas Vitor Gentil', '20'),
(12, 'Willian Afton', '???'),
(13, 'Dona Vanessa Rochelle', '46'),
(14, 'Nigel RJ', '16')*/

/*INSERT INTO Medico(IdUsuario, IdEspecialidade, Nome)
VALUES
(2, 1, 'Dr. Carlos'),
(3, 2, 'Dr. Eduardo'),
(8, 3, 'Dra. Eliane'),
(7, 4, 'Dr. Jonas'),
(6, 5, 'Dra. Lorraine'),
(4, 6, 'Dr. Mantis'),
(5, 7, 'Dra. Maria')*/

/*INSERT INTO Consulta(IdTipoConsulta, IdPaciente, IdMedico, IdClinica, DataConsulta, HorarioConsulta, Prontuário)
VALUES
(1, 1, 1, 1, '12/10/2015', '14:00', 'Paciente está com problemas de alergia de pele. Encaminhada para Dr. Carlos'),
(2, 2, 2, 1, '16/10/2015', '14:30', 'Paciente necessita de cirurgia do fígado. Encaminhado para Dr. Eduardo'),
(3, 5, 3, 1, '20/11/2015', '13:30', 'Paciente aparenta ter problemas de catarata. Encaminhada para Dra. Eliane'),
(4, 4, 4, 1, '13/01/2016', '17:25', 'Paciente está com problemas na perna. Encaminhado para Dr. Jonas'),
(5, 6, 5, 1, '22/06/2017', '16:00', 'Paciente pediu informação de seu peso. Encaminhado para Dra. Lorraine'),
(6, 3, 6, 1, '01/13/2077', '25:00', 'PaCiENtE Se eNContrA CoM uM ViRUs DescONHEcido. ajuDA, Dr. Mantis!!'),
(7, 2, 7, 1, '24/07/2023', '19:45', 'Paciente infartou. Encaminhado para Dra. Maria')*/

------ DQL - Data Query Language

SELECT
Consulta.DataConsulta AS [Data],
Consulta.HorarioConsulta AS [Horário],
TipoConsulta.TituloTipoConsulta AS [Tipo de Consulta],
Paciente.Nome AS [Paciente],
Medico.Nome AS [Médico/a],
Consulta.Prontuário
FROM
Consulta
INNER JOIN TipoConsulta
ON TipoConsulta.IdTipoConsulta = Consulta.IdTipoConsulta
INNER JOIN Paciente
ON Paciente.IdPaciente = Consulta.IdPaciente
INNER JOIN Medico
ON Medico.IdMedico = Consulta.IdMedico


SELECT 
TipoUsuario.TituloTipoUsuario AS [Acesso],
Usuario.Email,
Usuario.Senha
FROM
Usuario
INNER JOIN TipoUsuario
ON TipoUsuario.IdTipoUsuario = Usuario.IdTipoUsuario


SELECT
Paciente.Nome,
Paciente.Idade,
Usuario.Email AS [Email]
FROM
Paciente
INNER JOIN Usuario
ON Usuario.IdUsuario = Paciente.IdUsuario





------ VER AS TABELAS
SELECT * FROM TipoUsuario
SELECT * FROM Usuario
SELECT * FROM Paciente
SELECT * FROM Especialidade
SELECT * FROM Medico
SELECT * FROM TipoConsulta
SELECT * FROM Clinica
SELECT * FROM Consulta