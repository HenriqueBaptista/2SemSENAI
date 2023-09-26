using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    /// <summary>
    /// Tabela de Agendamento
    /// </summary>
    [Table(nameof(Agendamento))]
    public class Agendamento
    {
        /// <summary>
        /// Primary Key de Agendamento
        /// </summary>
        [Key]
        public Guid IdAgendamento { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Dia do agendamento
        /// </summary>
        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Dia do agendamento obrigatório!")]
        public DateOnly DiaAgendamento { get; set; }


        // Referência e Foreign Key de Usuario

        /// <summary>
        /// Id do usuário
        /// </summary>
        [Required(ErrorMessage = "Usuário obrigatório!")]
        public Guid IdUsuario { get; set; }


        /// <summary>
        /// Foreign Key - Usuario
        /// </summary>
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }


        // Referência e Foreign Key de Clinica

        /// <summary>
        /// Id da clínica
        /// </summary>
        [Required(ErrorMessage = "Clínica obrigatória!")]
        public Guid IdClinica { get; set; }


        /// <summary>
        /// Foreign Key - Clinica
        /// </summary>
        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
    }
}
