using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    /// <summary>
    /// Tabela de Clinica
    /// </summary>
    [Table(nameof(Clinica))]
    public class Clinica
    {
        /// <summary>
        /// Primary Key de Clinica
        /// </summary>
        [Key]
        public Guid IdClinica { get; set; }


        /// <summary>
        /// Endereço da clínica
        /// </summary>
        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Endereço obrigatório!")]
        public string? Endereco { get; set; }


        /// <summary>
        /// Horario de funcionamenro da clínica
        /// </summary>
        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horário de funcionamento obrigatório!")]
        public TimeOnly HorarioFunionamento { get; set; }


        /// <summary>
        /// CNPJ da clínica
        /// </summary>
        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ Obrigatório!")]
        public string? CNPJ { get; set; }


        /// <summary>
        /// Nome fantasia da clínica
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome fantasia obrigatório!")]
        public string? NomeFantasia { get; set; }


        /// <summary>
        /// Razão social da clínica
        /// </summary>
        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Razão social obrigatória!")]
        public string? RazaoSocial { get; set; }
    }
}
