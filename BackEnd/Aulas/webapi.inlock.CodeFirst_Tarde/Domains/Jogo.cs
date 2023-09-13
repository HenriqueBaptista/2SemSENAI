using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.CodeFirst_Tarde.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        string? Nome { get; set; }


        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do jogo é necessária!")]
        public string? Descricao { get; set; }


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de lançamento do jogo é necessária!")]
        public DateTime? DataLancamento { get; set; }


        [Column(TypeName = "DECIMAL(4,2)")]
        [Required(ErrorMessage = "O preço do jogo é obrigatório!")]
        public decimal Preco { get; set; }


        // Referência da tabela estúdio - FK
        public Guid IdEstudio { get; set; }


        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set;}
    }
}
