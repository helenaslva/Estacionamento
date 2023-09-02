using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Entities
{
    public class Preco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime DataValidadeInicial { get; set; }
        [Required]
        public DateTime DataValidadeFinal { get; set; }
        [Required]
        public double Valor { get; set; }

        public List<Estacionamento> Estacionamentos { get; set; }   
    }
}
