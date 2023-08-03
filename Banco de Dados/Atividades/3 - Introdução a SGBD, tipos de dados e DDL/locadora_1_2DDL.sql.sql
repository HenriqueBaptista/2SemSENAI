CREATE DATABASE exercicio_1_2;

USE exercicio_1_2;

-- TABLE Empresa
--(
--Aluguel INT PRIMARY KEY IDENTITY,
--Carro VARCHAR(20) NOT NULL,
--Pessoa VARCHAR(20) NOT NULL,
--Status VARCHAR(20) NOT NULL
--)

SELECT * FROM Empresa

INSERT INTO Empresa(Carro, Pessoa, Status)
VALUES ('Fiat UNO', 'Bob', 'Atrasado')