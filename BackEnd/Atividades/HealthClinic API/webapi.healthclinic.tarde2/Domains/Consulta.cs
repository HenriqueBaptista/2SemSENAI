using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde2.Domains
{
    /// <summary>
    /// Tabela de Consulta
    /// </summary>
    [Table(nameof(Consulta))]
    public class Consulta
    {
        /// <summary>
        /// Primary Key de Consulta
        /// </summary>
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Prontuário/descrição da consulta
        /// </summary>
        [Column(TypeName = "TEXT")]
        public string? Prontuario { get; set; }


        /// <summary>
        /// Condição - Agendada (true) ou Cancelada (false)
        /// </summary>
        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Condição da consulta (agendada ou cancelada) obrigatória!")]
        public bool Condição { get; set; }


        // Referência e Foreign Key de TipoConsulta

        /// <summary>
        /// Id do tipo de consulta
        /// </summary>
        [Required(ErrorMessage = "Tipo de consulta obrigatório!")]
        public Guid IdTipoConsulta { get; set; }


        /// <summary>
        /// Foreign Key - TipoConsulta
        /// </summary>
        [ForeignKey(nameof(IdTipoConsulta))]
        public TipoConsulta? TipoConsulta { get; set; }


        // Referência e Foreign Key de Agendamento

        /// <summary>
        /// Id do agendamento
        /// </summary>
        [Required(ErrorMessage = "Agendamento obrigatório!")]
        public Guid IdAgendamento { get; set; }


        /// <summary>
        /// Foreign Key - Agendamento
        /// </summary>
        [ForeignKey(nameof(IdAgendamento))]
        public Agendamento? Agendamento { get; set; }
    }
}
