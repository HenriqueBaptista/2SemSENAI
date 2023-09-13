using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace webapi.inlock.CodeFirst_Tarde.Domains
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email do usuário é obrigatório!")]
        public string? Email{ get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha precisa ter de 6 a 20 caracteres!")]
        public string? Senha { get; set; }
    }
}