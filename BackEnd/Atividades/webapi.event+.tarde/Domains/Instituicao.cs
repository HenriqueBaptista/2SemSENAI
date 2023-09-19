using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace webapi.event_.tarde.Domains
{
    /// <summary>
    /// Classe responsável pela tabela Instituicao
    /// </summary>
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        /// <summary>
        /// Primary Key da tabela
        /// </summary>
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();


        /// <summary>
        /// CNPJ da instituição
        /// </summary>
        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ obrigatório!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }


        /// <summary>
        /// Endereço da instituição
        /// </summary>
        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "Endereço obrigatório!")]
        public string? Endereco { get; set; }


        /// <summary>
        /// Nome fantasia da instituição
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome fantasia obrigatório!")]
        public string? NomeFantasia { get; set; }
    }
}
