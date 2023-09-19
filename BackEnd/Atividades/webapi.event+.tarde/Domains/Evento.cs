using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    /// <summary>
    /// Classe responsável pela tabela Evento
    /// </summary>
    [Table(nameof(Evento))]
    public class Evento
    {
        /// <summary>
        /// Primary key da tabela
        /// </summary>
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Data do evento
        /// </summary>
        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data do evento obrigatória!")]
        public DateTime DataEvento { get; set; }


        /// <summary>
        /// Nome do evento
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do evento obrigatório!")]
        public string? NomeEvento { get; set; }


        /// <summary>
        /// Descrição do evento
        /// </summary>
        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do evento obrigatória!")]
        public string? Descricao { get; set; }



        ///////////// Referências e Foreign Keys

        /// <summary>
        /// Id do tipo do evento
        /// </summary>
        [Required(ErrorMessage = "Tipo do evento obrigatório!")]
        public Guid IdTipoEvento { get; set; }

        /// <summary>
        /// Foreign Key para usar TipoEvento
        /// </summary>
        [ForeignKey(nameof(IdTipoEvento))]
        public TipoEvento? TipoEvento { get; set; }


        /// <summary>
        /// Id da instituição
        /// </summary>
        [Required(ErrorMessage = "Instituição obrigatória!")]
        public Guid IdInstituicao { get; set; }

        /// <summary>
        /// Foreign Key para usar Instituição
        /// </summary>
        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }
    }
}
