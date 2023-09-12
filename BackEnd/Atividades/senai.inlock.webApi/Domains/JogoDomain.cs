using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai.inlock.webApi_.Domains
{
    /// <summary>
    /// Classe responsável pelas propriedades do Jogo
    /// </summary>
    public class JogoDomain
    {
        /// <summary>
        /// Id do jogo
        /// </summary>
        public int IdJogo { get; set; }


        /// <summary>
        /// Id do estúdio responsável pelo jogo
        /// </summary>
        [Required(ErrorMessage = "O jogo precisa ter um estúdio, logo o Id do estúdio é obrigatório!")]
        public int IdEstudio { get; set; }


        /// <summary>
        /// Nome do jogo
        /// </summary>
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")] public string? Nome { get; set; }


        /// <summary>
        /// Descrição do jogo
        /// </summary>
        [Required(ErrorMessage = "A descrição do jogo é obrigatória!")] public string? Descricao { get; set; }


        /// <summary>
        /// Data de lançamento do jogo
        /// </summary>
        [Required(ErrorMessage = "A data de lançamento do jogo é necessária")]
        public string? DataLancamento { get; set; }


        /// <summary>
        /// Preço do jogo
        /// </summary>
        [Required (ErrorMessage = "O valor do jogo é necessário")] public double Valor { get; set; }
    }
}
