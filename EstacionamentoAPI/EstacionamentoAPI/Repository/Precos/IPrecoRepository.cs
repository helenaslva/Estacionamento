
using EstacionamentoAPI.Shared;
using EstacionamentoAPI.Entities;
using EstacionamentoAPI.Results.Preco;
using EstacionamentoAPI.Results.Precos;

namespace EstacionamentoAPI.Repository.Precos
{
    public interface IPrecoRepository
    {
        Task<ObterPrecoResult> ObterPrecoPorData(DateTime data);
        Task<ObterPrecoResult> AdicionarPreco(Entities.Preco preco);
        Task<List<ListarPrecosResult>> ListarPrecos();

      
    }
}
