using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    /// <summary>
    /// Tabela de TipoUsuario
    /// </summary>
    [Table(nameof(TipoUsuario))]
    public class TipoUsuario
    {
        /// <summary>
        /// Primary Key de TipoUsuario
        /// </summary>
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Título do tipo de usuário
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Título do tipo de usuário obrigatório!")]
        public string? Titulo { get; set; }
    }
}
