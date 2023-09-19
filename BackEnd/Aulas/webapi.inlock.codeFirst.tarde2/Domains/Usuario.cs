using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace webapi.inlock.CodeFirst_Tarde.Domains
{
    /// <summary>
    /// Classe responsável pelas propriedades e tabela Usuario
    /// </summary>
    [Table("Usuario")]
    public class Usuario
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Email do usuário
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email do usuário é obrigatório!")]
        public string? Email{ get; set; }


        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha precisa ter de 6 a 60 caracteres!")]
        public string? Senha { get; set; }


        /// <summary>
        /// Id do tipo de usuário
        /// </summary>
        // Referência a tabela TiposUsuario
        [Required(ErrorMessage = "O tipo do usuário é obrigatório")]
        public Guid IdTipoUsuario { get; set; }


        /// <summary>
        /// Foreign Key de TipoUsuario
        /// </summary>
        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario? TipoUsuario { get; set; }
    }
}