using EstacionamentoAPI.Entities;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repository.Estacionamentos;
using EstacionamentoAPI.Repository.Precos;
using EstacionamentoAPI.Shared;

namespace EstacionamentoAPI.Handler.Precos
{
    public class PrecoHandler : IPrecoHandler
    {
        IPrecoRepository _precoRepository;

        public PrecoHandler(IPrecoRepository precoRepository)
        {
            _precoRepository = precoRepository;
        }

        public async Task<Output> AdicionarPrecoHandler(AdicionarPrecoModel adicionarPrecoModel)
        {
            try
            {
                var preco = new Preco
                {
                    DataValidadeInicial = adicionarPrecoModel.DataValidadeInicial,
                    DataValidadeFinal = adicionarPrecoModel.DataValidadeFinal,
                    Valor = adicionarPrecoModel.Valor
                };

                var precoSalvo = _precoRepository.AdicionarPreco(preco);
                if (precoSalvo.Id != 0)
                {
                    return new Output() { IsSuccess = true, Message = "Salvo com sucesso" };
                }
                else
                {
                    return new Output() { IsSuccess = false, Message = "Não foi possível salvar o preço." };
                }

            }
            catch (Exception ex) { return new Output() { IsSuccess = false, Message = $"Um erro inesperado ocorreu: {ex.Message} " }; }
        }
    }
}
