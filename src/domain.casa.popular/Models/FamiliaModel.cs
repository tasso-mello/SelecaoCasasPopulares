namespace domain.casa.popular.Models
{
    using domain.casa.popular.Entities;
    using Newtonsoft.Json;

    public class FamiliaModel
    {
        public IEnumerable<PessoaModel> Pessoas { get; set; }
        public decimal? Renda { get; set; }
    }
}
