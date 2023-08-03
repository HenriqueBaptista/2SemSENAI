CREATE DATABASE exercicio_1_2;

USE exercicio_1_2;

CREATE TABLE Empresa
(
Aluguel INT PRIMARY KEY IDENTITY,
Carro VARCHAR(20) NOT NULL,
Pessoa VARCHAR(20) NOT NULL,
Status VARCHAR(20) NOT NULL
)

SELECT * FROM Empresa

INSERT INTO Empresa(Carro, Pessoa, Status)
VALUES ('Fiat UNO', 'Bob', 'Atrasado')

UPDATE Empresa
SET Carro = 'Celta', Pessoa = 'Ronaldo', Status = 'Atrasado'
WHERE Aluguel = 4

DELETE FROM Empresa WHERE Aluguel = 1
DELETE FROM Empresa WHERE Aluguel = 2
DELETE FROM Empresa WHERE Aluguel = 3

