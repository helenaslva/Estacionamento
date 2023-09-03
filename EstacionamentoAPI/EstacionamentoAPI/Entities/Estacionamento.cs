using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EstacionamentoAPI.Entities
{
    public class Estacionamento
    { 
        [Key]
        [Required, NotNull]
        public int Id { get; set; }
        [Required, NotNull]
        public String Placa { get; set; }
        [Required, NotNull]
        public DateTime DataEntrada { get; set; }
        [Required, NotNull]
        public DateTime DataSaida { get; set; }
        [Required, NotNull]
        public TimeSpan Duracao { get; set; }
        [Required]
        public int TempoCobrado { get; set; }
        [Required, NotNull]
        public DateTime DataInsert { get; set; }
        public DateTime? DataAlteracao { get; set; }
        [Required, NotNull]
        public int PrecoId {  get; set; }
        [Required, NotNull]
        public Preco Preco { get; set; }
        [Required, NotNull]
        public double ValorTotal { get; set; }
       
    }
}
