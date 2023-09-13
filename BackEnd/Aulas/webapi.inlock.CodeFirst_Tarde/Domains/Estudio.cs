using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.CodeFirst_Tarde.Domains
{
    [Table("Estudio")]
    public class Estudio
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        string? Nome { get; set; }

        // Referência da lista de jogos
        public List<Jogo>? Jogo { get; set; }
    }
}
