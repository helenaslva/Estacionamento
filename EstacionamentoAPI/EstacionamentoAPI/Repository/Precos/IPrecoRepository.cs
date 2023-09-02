using EstacionamentoAPI.Results.Preco;

namespace EstacionamentoAPI.Repository.Preco
{
    public interface IPrecoRepository
    {
        Task<ObterPrecoResult> ObterPrecoPorData(DateTime data);
    }
}
