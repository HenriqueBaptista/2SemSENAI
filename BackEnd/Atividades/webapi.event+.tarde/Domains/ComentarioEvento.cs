using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    /// <summary>
    /// Classe responsável pela tabela ComentarioEvento
    /// </summary>
    [Table(nameof(ComentarioEvento))]
    public class ComentarioEvento
    {
        /// <summary>
        /// Primary Key da tabela
        /// </summary>
        [Key]
        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Descrição do comentário
        /// </summary>
        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição obrigatória!")]
        public string? Descricao { get; set; }


        /// <summary>
        /// Indica se o comentário é exibível ou não
        /// </summary>
        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Obrigatório saber se é ou não exibível!")]
        public bool Exibe { get; set; }



        ///////////// Referências e Foreign Keys

        /// <summary>
        /// Id do Usuário responsável pelo comentário
        /// </summary>
        [Required(ErrorMessage = "Usuário obrigatório!")]
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Foreign Key para usar Usuario
        /// </summary>
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }



        /// <summary>
        /// Id do evento que receberá o comentário
        /// </summary>
        [Required(ErrorMessage = "Evento obrigatório!")]
        public Guid IdEvento { get; set; }

        /// <summary>
        /// Foreign Key para usar Evento
        /// </summary>
        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
