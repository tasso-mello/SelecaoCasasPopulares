namespace domain.casa.popular.Models
{
    public class PessoaModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public decimal Salario { get; set; } = 0;
    }
}
