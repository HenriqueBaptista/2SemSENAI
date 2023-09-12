using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    /// <summary>
    /// Classe responsável pelas propriedades do Estúdio
    /// </summary>
    public class EstudioDomain
    {
        /// <summary>
        /// Id do Estúdio
        /// </summary>
        public int IdEstudio { get; set; }

        /// <summary>
        /// Nome do estúdio
        /// </summary>
        [Required(ErrorMessage = "O nome do estúdio é obrigatório!")] public string? Nome { get; set; }
    }
}
