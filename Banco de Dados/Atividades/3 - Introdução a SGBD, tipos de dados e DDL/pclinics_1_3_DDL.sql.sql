CREATE DATABASE exercicio_1_3

USE exercicio_1_3

CREATE TABLE P_Clinica
(
Atendimento INT PRIMARY KEY IDENTITY,
Pet VARCHAR(20) NOT NULL,
Nome_Pet VARCHAR(20) NOT NULL,
Dono VARCHAR(20) NOT NULL,
Veterin�rio VARCHAR(20) NOT NULL
)

SELECT * FROM P_Clinica

INSERT INTO P_Clinica(Pet, Nome_Pet, Dono, Veterin�rio)
VALUES ('Peixe', 'Fishy', 'Luciana', 'Andr�');