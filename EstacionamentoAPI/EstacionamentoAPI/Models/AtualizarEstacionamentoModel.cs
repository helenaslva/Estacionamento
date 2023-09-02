using EstacionamentoAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EstacionamentoAPI.Models
{
    public class AtualizarEstacionamentoModel
    {
        public int Id { get; set; }
        public DateTime DataSaida { get; set; }
    }
}
