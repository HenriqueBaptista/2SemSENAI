using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    /// <summary>
    /// Classe responsável pela tabela TipoEvento
    /// </summary>
    [Table(nameof(TipoEvento))]
    public class TipoEvento
    {
        /// <summary>
        /// Primary Key da tabela
        /// </summary>
        [Key]
        public Guid IdTipoEvento { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Titulo do tipo evento
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Titulo do tipo de evento obrigatório!")]
        public string? Titulo { get; set; }
    }
}
