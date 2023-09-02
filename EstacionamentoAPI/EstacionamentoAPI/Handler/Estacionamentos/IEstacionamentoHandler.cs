using EstacionamentoAPI.Entities;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repository.Estacionamentos;
using EstacionamentoAPI.Repository.Preco;
using EstacionamentoAPI.Shared;

namespace EstacionamentoAPI.Handler.Estacionamentos;


public interface IEstacionamentoHandler
{
    Task<Output>SalvarEstacionamentoHandler(SalvarEstacionamentoModel salvarEstacionamentoModel);
    Task<Output>AtualizarEstacionamentoHandler(AtualizarEstacionamentoModel atualizarEstacionamentoModel);
    
}
