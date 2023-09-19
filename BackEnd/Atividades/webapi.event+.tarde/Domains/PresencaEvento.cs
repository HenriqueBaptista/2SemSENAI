using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    /// <summary>
    /// Classe responsável pela tabela PresencaEvento
    /// </summary>
    [Table(nameof(PresencaEvento))]
    public class PresencaEvento
    {
        /// <summary>
        /// Primary Key da tabela
        /// </summary>
        [Key]
        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Situação da presença - Presente (true) ou Ausente (false)
        /// </summary>
        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Situação do usuário obrigatória!")]
        public bool Situacao { get; set; }



        ///////////// Referências e Foreign Keys

        /// <summary>
        /// Id do usuário
        /// </summary>
        [Required(ErrorMessage = "Usuário obrigatório!")]
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Foreign Key para usar Usuario
        /// </summary>
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }



        /// <summary>
        /// Id do evento
        /// </summary>
        [Required(ErrorMessage = "Evento obrigatório")]
        public Guid IdEvento { get; set; }

        /// <summary>
        /// Foreign Key para usar Evento
        /// </summary>
        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
