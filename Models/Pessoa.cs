namespace Hospedagem.Models
{
    public class Pessoa
    {
        public Pessoa() { }

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public string NomeCompleto
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Sobrenome))
                    return Nome.ToUpper();
                return $"{Nome} {Sobrenome}".ToUpper();
            }
        }
    }
}
