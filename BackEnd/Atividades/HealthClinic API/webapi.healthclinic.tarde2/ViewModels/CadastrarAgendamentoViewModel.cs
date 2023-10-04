using System.ComponentModel.DataAnnotations;
using webapi.healthclinic.tarde2.Domains;

namespace webapi.healthclinic.tarde2.ViewModels
{
    /// <summary>
    /// ViewModel para o método Login
    /// </summary>
    public class CadastrarAgendamentoViewModel
    {
        /// <summary>
        /// Dia do agendamento
        /// </summary>
        [Required(ErrorMessage = "Dia do agendamento obrigatório!")]
        public DateOnly DiaAgendamento { get; set; }

        /// <summary>
        /// Paciente
        /// </summary>
        [Required(ErrorMessage = "Paciente obrigatório!")]
        public Usuario? IdPaciente;

        /// <summary>
        /// Médico
        /// </summary>
        [Required(ErrorMessage = "Médico obrigatório!")]
        public Usuario? Médico { get; set; }
    }
}
