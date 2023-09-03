
namespace EstacionamentoAPI.Results.Estacionamentos
{
    public class ObterEstacionamentoResult
    {
        public int Id { get; set; }
        public String Placa { get; set; }
    
        public DateTime DataEntrada { get; set; }
 
        public DateTime DataSaida { get; set; }
       
        public TimeSpan Duracao { get; set; }
       
        public int TempoCobrado { get; set; }
    
        public DateTime DataInsert { get; set; } 

        public DateTime DataAlteracao { get; set; } 
     
     
        public Entities.Preco Preco { get; set; }
        public double ValorTotal { get; set; }

    }
}
