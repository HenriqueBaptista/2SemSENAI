namespace webapi.healthclinic.tarde2.Utils
{
    /// <summary>
    /// Classe responsável pela criptografia
    /// </summary>
    public static class Criptografia
    {
        /// <summary>
        /// Gera a hash para a criptografia
        /// </summary>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Compara as hashs, tanto a original quanto a da senha
        /// </summary>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
