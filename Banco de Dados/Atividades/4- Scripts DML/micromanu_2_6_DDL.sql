CREATE DATABASE exercicio_1_6

USE exercicio_1_6

CREATE TABLE MicroManu
(
Manute��o INT PRIMARY KEY IDENTITY,
Equipamento VARCHAR(20) NOT NULL,
Servi�o VARCHAR(20) NOT NULL,
Cliente VARCHAR(20) NOT NULL,
Email VARCHAR(30) NOT NULL,
)

SELECT * FROM MicroManu

INSERT INTO MicroManu(Equipamento, Servi�o, Cliente, Email)
VALUES ('TV','Concerto','Bianca','BBB2077@.cococococo@.com')

UPDATE MicroManu
SET Email = 'Sergio123@.com'
WHERE Manute��o = 1