using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.CodeFirst_Tarde.Domains
{
    /// <summary>
    /// Classe responsável pelas propriedades e tabela TiposUsuario
    /// </summary>
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        /// <summary>
        /// Id do tipo do usuário
        /// </summary>
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Titulo do tipo do usuário
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O tipo do usuário é obrigatório!")]
        public string? Titulo { get; set; }
    }
}
