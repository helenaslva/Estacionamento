namespace EstacionamentoAPI.Results.Preco
{
    public class ObterPrecoResult
    {
        public int Id { get; set; }
        public DateTime DataValidadeInicial { get; set; }
        public DateTime DataValidadeFinal { get; set; }
        public double Valor { get; set; }
    }
}
