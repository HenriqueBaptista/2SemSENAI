using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace webapi.event_.tarde.Domains
{
    /// <summary>
    /// Classe responsável pela tabela Usuario
    /// </summary>
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        /// <summary>
        /// Primary Key da tabela
        /// </summary>
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Nome do usuário
        /// </summary>
        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Nome do usuário obrigatório!")]
        public string? Nome { get; set; }


        /// <summary>
        /// Email do usuário
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email do usuário obrigatório!")]
        public string? Email { get; set; }


        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "Senha obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter 6 a 60 caracteres!")]
        public string? Senha { get; set; }



        ///////////// Referência a tabela TipoUsuario + Foreign Key

        /// <summary>
        /// Id do tipo de usuário
        /// </summary>
        [Required(ErrorMessage = "Tipo de usuario obrigatório!")]
        public Guid IdTipoUsuario { get; set; }

        /// <summary>
        /// Foreign Key para usar TipoUsuario
        /// </summary>
        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
