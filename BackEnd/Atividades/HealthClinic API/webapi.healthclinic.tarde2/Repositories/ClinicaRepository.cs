using webapi.healthclinic.tarde2.Contexts;
using webapi.healthclinic.tarde2.Interfaces;

using webapi.healthclinic.tarde2.Domains;

namespace webapi.healthclinic.tarde2.Repositories
{

    /// <summary>
    /// Repositório de Clinica
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext healthContext;

        /// <summary>
        /// Usa a HealthContext
        /// </summary>
        public ClinicaRepository()
        {
            healthContext = new HealthContext();
        }


        /// <summary>
        /// Atualiza clínicas
        /// </summary>
        public void Atualizar(Guid id, Clinica clinica)
        {
            try
            {
                Clinica clinicaAtualizar = healthContext.Clinica.Select(c => new Clinica
                {
                    IdClinica = c.IdClinica,
                    Endereco = c.Endereco,
                    CNPJ = c.CNPJ,
                    HorarioFunionamento = c.HorarioFunionamento,
                    NomeFantasia = c.NomeFantasia,
                    RazaoSocial = c.RazaoSocial
                }).FirstOrDefault(c => c.IdClinica == id)!;

                clinicaAtualizar = clinica;

                healthContext.Update(clinica);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Cadastra clínicas
        /// </summary>
        public void Cadastrar(Clinica clinica)
        {
            try
            {
                healthContext.Clinica.Add(clinica);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deleta clínicas
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                Clinica clinica = new Clinica();

                clinica.IdClinica = id;

                healthContext.Clinica.Remove(clinica);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lista clínicas
        /// </summary>
        public List<Clinica> Listar()
        {
            try
            {
                return healthContext.Clinica.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
