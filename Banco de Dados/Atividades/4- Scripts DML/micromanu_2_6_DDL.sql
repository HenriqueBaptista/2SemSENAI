CREATE DATABASE exercicio_1_6

USE exercicio_1_6

CREATE TABLE MicroManu
(
Manuteção INT PRIMARY KEY IDENTITY,
Equipamento VARCHAR(20) NOT NULL,
Serviço VARCHAR(20) NOT NULL,
Cliente VARCHAR(20) NOT NULL,
Email VARCHAR(30) NOT NULL,
)

SELECT * FROM MicroManu

INSERT INTO MicroManu(Equipamento, Serviço, Cliente, Email)
VALUES ('TV','Concerto','Bianca','BBB2077@.cococococo@.com')

UPDATE MicroManu
SET Email = 'Sergio123@.com'
WHERE Manuteção = 1