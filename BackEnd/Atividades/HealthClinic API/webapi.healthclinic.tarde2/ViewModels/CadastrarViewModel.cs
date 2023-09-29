using Microsoft.EntityFrameworkCore;

namespace webapi.healthclinic.tarde2.ViewModels
{
    /// <summary>
    /// ViewModel para o método cadastrar
    /// </summary>
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(CPF), IsUnique = true)]

    public class CadastrarViewModel
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string? Nome { get; set; }


        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }


        /// <summary>
        /// Senha
        /// </summary>
        public string? Senha { get; set; }


        /// <summary>
        /// CPF
        /// </summary>
        public string? CPF { get; set; }
    }
}
