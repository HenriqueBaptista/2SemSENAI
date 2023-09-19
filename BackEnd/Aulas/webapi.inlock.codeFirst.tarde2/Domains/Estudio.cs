using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.CodeFirst_Tarde.Domains
{
    /// <summary>
    /// Classe responsável pelas propriedades e tabela do Estudio
    /// </summary>
    [Table("Estudio")]
    public class Estudio
    {
        /// <summary>
        /// Id do estudio
        /// </summary>
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Nome do estudio
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string? Nome { get; set; }


        /// <summary>
        /// Lista de jogo do estúdio para métodos
        /// </summary>
        // Referência da lista de jogos
        public List<Jogo>? Jogo { get; set; }
    }
}