using EstacionamentoAPI.Data;
using EstacionamentoAPI.Entities;
using EstacionamentoAPI.Repository.Precos;
using EstacionamentoAPI.Results.Estacionamentos;
using EstacionamentoAPI.Results.Preco;
using EstacionamentoAPI.Results.Precos;
using EstacionamentoAPI.Shared;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EstacionamentoAPI.Repository.Preco
{
    public class PrecoRepository : IPrecoRepository
    {
        private readonly EstacionamentoContext _context;
        private readonly DbSet<EstacionamentoAPI.Entities.Preco> _preco;
        public PrecoRepository(EstacionamentoContext context)
        {
            _context = context;
            _preco = _context.Set<EstacionamentoAPI.Entities.Preco>();
        }

        public async Task<ObterPrecoResult> AdicionarPreco(Entities.Preco preco)
        {
            var novoPreco = _preco.Add(preco).Entity;
            await _context.SaveChangesAsync();
            return new ObterPrecoResult
            {
                Id = novoPreco.Id,
                DataValidadeInicial = novoPreco.DataValidadeInicial,
                DataValidadeFinal = novoPreco.DataValidadeFinal,
                Valor = novoPreco.Valor
            };
        }

        public async Task<List<ListarPrecosResult>> ListarPrecos()
        {
            return await _preco
                .Select(x => new ListarPrecosResult
                {
                    DataValidadeInicial = x.DataValidadeInicial,
                    DataValidadeFinal = x.DataValidadeFinal,
                    Valor = x.Valor

                }).ToListAsync();
        }

        public Task<ObterPrecoResult?> ObterPrecoPorData(DateTime data)
        {
            return _preco
               .Where(p => p.DataValidadeInicial <= data && (p.DataValidadeFinal == null || p.DataValidadeFinal >= data))
               .Select(x => new ObterPrecoResult
               {
                   Id = x.Id,
                   DataValidadeInicial = x.DataValidadeInicial,
                   DataValidadeFinal = x.DataValidadeFinal,
                   Valor = x.Valor

               })
               .FirstOrDefaultAsync();
        }
    }
}

