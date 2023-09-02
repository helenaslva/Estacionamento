using EstacionamentoAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EstacionamentoAPI.Results.Estacionamentos
{
    public class ListarEstacionamentoResult
    {
        public int Id { get; set; }
        public String Placa { get; set; }
       
        public DateTime DataEntrada { get; set; }
       
        public DateTime DataSaida { get; set; }
        
        public TimeSpan Duracao { get; set; }
       
        public int TempoCobrado { get; set; }
        public EstacionamentoAPI.Entities.Preco Preco { get; set; }
        public double ValorTotal { get; set; }

    }
}
