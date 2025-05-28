namespace Hospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            if (string.IsNullOrWhiteSpace(tipoSuite))
                throw new ArgumentException("Tipo de suíte não pode estar vazio.");

            if (capacidade <= 0)
                throw new ArgumentException("A capacidade da suíte deve ser maior que zero.");

            if (valorDiaria < 0)
                throw new ArgumentException("O valor da diária não pode ser negativo.");

            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }

        public override string ToString()
        {
            return $"Tipo: {TipoSuite}, Capacidade: {Capacidade}, Valor Diária: R$ {ValorDiaria:F2}";
        }
    }
}
