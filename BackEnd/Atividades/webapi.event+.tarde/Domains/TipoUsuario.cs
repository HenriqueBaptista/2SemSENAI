using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    /// <summary>
    /// Classe responsável pela tabela TipoUsuario
    /// </summary>
    [Table(nameof(TipoUsuario))]
    public class TipoUsuario
    {
        /// <summary>
        /// Primary Key da tabela
        /// </summary>
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Titulo do tipo de usuário
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Titulo do tipo de usuário obrigatório!")]
        public string? Titulo { get; set; }
    }
}
