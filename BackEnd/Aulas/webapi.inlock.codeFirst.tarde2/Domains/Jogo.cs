using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.CodeFirst_Tarde.Domains
{
    /// <summary>
    /// Classe responsável pelas propriedades e tabela do Jogo
    /// </summary>
    [Table("Jogo")]
    public class Jogo
    {
        /// <summary>
        /// Id do jogo
        /// </summary>
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Nome do jogo
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string? Nome { get; set; }


        /// <summary>
        /// Descrição do jogo
        /// </summary>
        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do jogo é necessária!")]
        public string? Descricao { get; set; }


        /// <summary>
        /// Data de lançamento do jogo
        /// </summary>
        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de lançamento do jogo é necessária!")]
        public DateTime? DataLancamento { get; set; }


        /// <summary>
        /// Preço do jogo
        /// </summary>
        [Column(TypeName = "DECIMAL(4,2)")]
        [Required(ErrorMessage = "O preço do jogo é obrigatório!")]
        public decimal Preco { get; set; }


        /// <summary>
        /// Id do estudio do jogo
        /// </summary>
        // Referência da tabela estúdio - FK
        public Guid IdEstudio { get; set; }


        /// <summary>
        /// Foreign Key de estúdio
        /// </summary>
        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set;}
    }
}
