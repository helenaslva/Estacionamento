using EstacionamentoAPI.Models;
using EstacionamentoAPI.Shared;

namespace EstacionamentoAPI.Handler.Precos
{
    public interface IPrecoHandler
    {
        Task<Output> AdicionarPrecoHandler(AdicionarPrecoModel adicionarPrecoModel);
        
    }
}
