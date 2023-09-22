using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    /// <summary>
    /// Repositório responsável pelos métodos de Instituicao
    /// </summary>
    public class InstituicaoRepository : IInstituicaoRepository
    {
        /// <summary>
        /// Acesso a content
        /// </summary>
        private readonly EventContext _eventContext;

        /// <summary>
        /// Construtor para obtenção do acesso a context
        /// </summary>
        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        } //


        /// <summary>
        /// Atualiza instituições
        /// </summary>
        public void Atualizar(Guid id, Instituicao instuicao)
        {
            try
            {
                Instituicao instituicaoBuscada = _eventContext.Instituicao.Select(i => new Instituicao
                {
                    IdInstituicao = i.IdInstituicao,
                    CNPJ = i.CNPJ,
                    Endereco = i.Endereco,
                    NomeFantasia = i.NomeFantasia
                }).FirstOrDefault(i => i.IdInstituicao == id)!;

                instituicaoBuscada = instuicao;

                _eventContext.Instituicao.Update(instuicao);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        } //


        /// <summary>
        /// Busca instituições pelo Id
        /// </summary>
        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscada = _eventContext.Instituicao.Select(i => new Instituicao
                {
                    IdInstituicao = i.IdInstituicao,
                    CNPJ = i.CNPJ,
                    Endereco = i.Endereco,
                    NomeFantasia = i.NomeFantasia
                }).FirstOrDefault(i => i.IdInstituicao == id)!;

                return instituicaoBuscada;
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Cadastra instituições
        /// </summary>
        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                _eventContext.Instituicao.Add(instituicao);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Deleta instituições
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                Instituicao instituicao = new Instituicao();

                instituicao.IdInstituicao = id;

                _eventContext.Instituicao.Remove(instituicao);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Lista instituições
        /// </summary>
        public List<Instituicao> Listar()
        {
            return _eventContext.Instituicao.Select(i => new Instituicao
            {
                IdInstituicao = i.IdInstituicao,
                CNPJ= i.CNPJ,
                Endereco= i.Endereco,
                NomeFantasia= i.NomeFantasia,
            }).ToList();
        } //
    }
} // Complete
