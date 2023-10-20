USE FilmesTarde;

SELECT * FROM Genero;
SELECT * FROM Filme;

CREATE TABLE Usuario
(
IdUsuario INT PRIMARY KEY IDENTITY,
Email VARCHAR(65) NOT NULL UNIQUE,
Senha VARCHAR(50) NOT NULL,
Permissao VARCHAR(30)
)

/*INSERT INTO Usuario(Email, Senha, Permissao) 	 */
/*VALUES										 */
/*('admin@admin.com', 'admin', 'Administrador'), */
/*('comum@comum.com', 'comum', 'Comum')			 */

SELECT * FROM Usuario

SELECT IdUsuario, Email, Permissao FROM Usuario WHERE Email = 'admin@admin.com' AND Senha = 'admin'