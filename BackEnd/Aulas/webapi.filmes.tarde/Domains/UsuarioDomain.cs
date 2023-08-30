using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Usuario
    /// </summary>
    public class UsuarioDomain
    {
        /// <summary>
        /// Id de um usuário já cadastrado
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Email do usuário
        /// </summary>
        [Required(ErrorMessage = "É necessário inserir um email!")] public string? Email { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Required(ErrorMessage = "É necessário inserir uma senha!")] public string? Senha { get; set; }

        /// <summary>
        /// Permissão do usuário - TRUE para administrador, FALSE para comum
        /// </summary>
        public bool PermissãoAdmin { get; set; }

        /// <summary>
        /// Status do usuário - Logado ou deslogado (só é possível logar um por vez)
        /// </summary>
        public bool Logado { get; set; }
    }
}
