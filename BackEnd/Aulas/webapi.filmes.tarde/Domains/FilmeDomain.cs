using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Filme
    /// </summary>
    public class FilmeDomain
    {
        /// <summary>
        /// Id do filme
        /// </summary>
        public int IdFilme { get; set; }

        /// <summary>
        /// Titulo do filme
        /// </summary>
        [Required(ErrorMessage = "O título do filme é obrigatório")]
        public string? Titulo { get; set; }

        /// <summary>
        /// Id do genero do filme
        /// </summary>
        public int IdGenero { get; set; }


        /// <summary>
        /// Referência para a classe GêneroDomain
        /// </summary>
        public GeneroDomain? Genero { get; set; }
    }
}
