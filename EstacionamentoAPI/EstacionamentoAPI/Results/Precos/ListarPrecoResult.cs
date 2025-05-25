namespace EstacionamentoAPI.Results.Precos
{
    public class ListarPrecosResult
    {
        public int Id { get; set; }
        public DateTime DataValidadeInicial { get; set; }
        public DateTime DataValidadeFinal { get; set; }
        public double Valor { get; set; }
    }
}

