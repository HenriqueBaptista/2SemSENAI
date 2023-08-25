using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Genero
    /// </summary>
    public class GeneroDomain
    {
        /// <summary>
        /// Id do objeto Gênero
        /// </summary>
        public int IdGenero { get; set; }


        /// <summary>
        /// Nome do objeto Gênero
        /// </summary>
        [Required(ErrorMessage = "O nome do gênero é obrigatório!")]
        public string? Nome { get; set; }
    }
}
