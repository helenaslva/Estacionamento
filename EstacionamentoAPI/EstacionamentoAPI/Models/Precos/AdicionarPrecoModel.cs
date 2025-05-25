using EstacionamentoAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EstacionamentoAPI.Models
{
    public class AdicionarPrecoModel
    {
        public DateTime DataValidadeInicial { get; set; }
     
        public DateTime DataValidadeFinal { get; set; }
   
        public double Valor { get; set; }
    }
}
