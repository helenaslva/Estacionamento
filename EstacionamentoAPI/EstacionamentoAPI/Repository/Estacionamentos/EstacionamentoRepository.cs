using EstacionamentoAPI.Data;
using EstacionamentoAPI.Entities;
using EstacionamentoAPI.Results.Estacionamentos;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EstacionamentoAPI.Repository.Estacionamentos
{

    public class EstacionamentoRepository : IEstacionamentoRepository
    {

        private readonly EstacionamentoContext _context;
        private readonly DbSet<Estacionamento> _estacionamento;
        public EstacionamentoRepository(EstacionamentoContext context)
        {
            _context = context;
            _estacionamento = _context.Set<Estacionamento>();
        }
        public async Task<List<ListarEstacionamentoResult>> ListagemEstacionamentos()
        {
            return await _estacionamento
                
          .Select(x => new ListarEstacionamentoResult
          {
              Id = x.Id,
              Placa = x.Placa,
              DataEntrada = x.DataEntrada,
              DataSaida = x.DataSaida,
              Duracao = x.Duracao,
              TempoCobrado = x.TempoCobrado,
              Preco = x.Preco.Valor,
              ValorTotal = x.ValorTotal,
          })
          .ToListAsync();
        }

        public Task<ObterEstacionamentoResult?> ObterEstacionamento(int id)
        {
            return  _estacionamento
                .Include(x => x.Preco)
                .Where(x => x.Id == id)
           .Select(x => new ObterEstacionamentoResult
           {
               Id = x.Id,
               Placa = x.Placa,
               DataEntrada = x.DataEntrada,
               DataSaida = x.DataSaida,
               Duracao = x.Duracao,
               TempoCobrado = x.TempoCobrado,
               Preco = x.Preco,
               ValorTotal = x.ValorTotal,
           })
           .FirstOrDefaultAsync();
        }

        public async Task<int> SalvarEstacionamento(Estacionamento estacionamento)
        {
            var salvo = _estacionamento.Add(estacionamento).Entity;
            await _context.SaveChangesAsync();
            return salvo.Id;
        }

        public async Task AtualizarEstacionamento(Estacionamento estacionamento)
        {
            var atualizado = _estacionamento.Update(estacionamento);
            await _context.SaveChangesAsync(); ;
           
        }

        public Task<ObterEstacionamentoResult?> ObterEstacionamentoPorPlaca(string placa)
        {

            return _estacionamento
                .Include(x => x.Preco)
                .Where(x => x.Placa.Equals(placa))
           .Select(x => new ObterEstacionamentoResult
           {
               Id = x.Id,
               Placa = x.Placa,
               DataEntrada = x.DataEntrada,
               DataSaida = x.DataSaida,
               Duracao = x.Duracao,
               TempoCobrado = x.TempoCobrado,
               Preco = x.Preco,
               ValorTotal = x.ValorTotal,
           })
           .FirstOrDefaultAsync();

        }

        public async Task<int> DeletarEstacionamentoPorId(Estacionamento estacionamento)
        {
            var removido = _context.Remove(estacionamento);
            await _context.SaveChangesAsync();
            return estacionamento.Id;
        }


    }
}
