using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    /// <summary>
    /// Tabela de TipoConsulta
    /// </summary>
    [Table(nameof(TipoConsulta))]
    public class TipoConsulta
    {
        /// <summary>
        /// Primary Key de TipoConsulta
        /// </summary>
        [Key]
        public Guid IdTipoConsulta { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Titulo do tipo de consulta
        /// </summary>
        [Column (TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Titulo do tipo de consulta obrigatório!")]
        public string? Titulo { get; set; }
    }
}
