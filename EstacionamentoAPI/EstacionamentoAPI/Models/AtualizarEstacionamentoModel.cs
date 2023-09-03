using EstacionamentoAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EstacionamentoAPI.Models
{
    public class AtualizarEstacionamentoModel
    {
        public string Placa { get; set; }
        public DateTime DataSaida { get; set; }
    }
}
