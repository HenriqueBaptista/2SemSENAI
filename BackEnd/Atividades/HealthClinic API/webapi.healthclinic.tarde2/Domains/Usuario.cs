using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde2.Domains
{
    /// <summary>
    /// Tabela de Usuario
    /// </summary>
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(CPF), IsUnique = true)]
    public class Usuario
    {
        /// <summary>
        /// Primary Key de Usuario
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
        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Email do usuário obrigatório!")]
        public string? Email { get; set; }


        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "Senha do usuário obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter 6 a 60 caracteres!")]
        public string? Senha { get; set; }


        /// <summary>
        /// CPF do usuário
        /// </summary>
        [Column(TypeName = "VARCHAR(25)")]
        [Required(ErrorMessage = "CPF do usuário obrigatória!")]
        public string? CPF { get; set; }


        /// <summary>
        /// Data de nascimento do usuário
        /// </summary>
        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de nascimento do usuário obrigatória!")]
        public DateTime DataNascimento { get; set; }


        // Referência e Foreign Key de TipoUsuario

        /// <summary>
        /// Tipo de usuário
        /// </summary>
        [Required(ErrorMessage = "Tipo de usuario obrigatório!")]
        public Guid IdTipoUsuario { get; set; }


        /// <summary>
        /// Foreign Key - TipoUsuario
        /// </summary>
        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
