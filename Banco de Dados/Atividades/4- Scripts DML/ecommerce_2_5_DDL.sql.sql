CREATE DATABASE exercicio_1_5

USE exercicio_1_5

CREATE TABLE SenaiShop
(
Nm_Pedido INT PRIMARY KEY IDENTITY,
Produto VARCHAR(20) NOT NULL,
Categoria VARCHAR(20) NOT NULL,
Subcategoria VARCHAR(20) NOT NULL,
Cliente VARCHAR(20) NOT NULL
)

SELECT * FROM SenaiShop

INSERT INTO SenaiShop(Produto, Categoria, Subcategoria, Cliente)
VALUES ('Lâmpada','Elétrico','Iluminação','Vanessa')

UPDATE SenaiShop
SET Produto = 'Sansung TAB E'
WHERE Nm_Pedido = 1