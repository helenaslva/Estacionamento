using EstacionamentoAPI.Entities;
using EstacionamentoAPI.Results.Estacionamentos;

namespace EstacionamentoAPI.Repository.Estacionamentos
{
    public interface IEstacionamentoRepository
    {
        Task<List<ListarEstacionamentoResult>> ListagemEstacionamentos();
        Task<ObterEstacionamentoResult> ObterEstacionamento(int id);
        Task<int> SalvarEstacionamento(Estacionamento estacionamento);
        Task AtualizarEstacionamento(Estacionamento estacionamento);
        Task<ObterEstacionamentoResult> ObterEstacionamentoPorPlaca(string placa);
        Task<int> DeletarEstacionamentoPorId(Estacionamento estacionamento);
    }
}
