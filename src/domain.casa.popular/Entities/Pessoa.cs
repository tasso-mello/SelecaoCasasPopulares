namespace domain.casa.popular.Entities
{
    using System;

    public class Pessoa : Audit
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public decimal Salario { get; set; }
    }
}