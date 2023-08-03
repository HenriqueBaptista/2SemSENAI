CREATE DATABASE exercicio_1_4

USE exercicio_1_4

CREATE TABLE OPTUSMusic
(
Album INT PRIMARY KEY IDENTITY,
Titulo VARCHAR(20) NOT NULL,
Data VARCHAR(20) NOT NULL,
Local VARCHAR(20) NOT NULL,
Tempo VARCHAR(20) NOT NULL,
Artista VARCHAR(20) NOT NULL,
Estilo VARCHAR (20) NOT NULL,
Status VARCHAR(20) NOT NULL,
)

SELECT * FROM OPTUSMusic;

INSERT INTO OPTUSMusic(Titulo, Data, Local, Tempo, Artista, Estilo, Status)
VALUES ('Danza', '14/04/2012', 'Argentina', '1h3m', 'Brotha', 'Samba', 'Indisponível')