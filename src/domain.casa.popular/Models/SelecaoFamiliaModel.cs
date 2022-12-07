namespace domain.casa.popular.Models
{
    public class SelecaoFamiliaModel
    {
        public SelecaoFamiliaModel(FamiliaModel familia, int pontos)
        {
            Familia = familia;
            Pontos = pontos;
        }

        public FamiliaModel Familia { get; private set; }
        public int Pontos { get; private set; }
    }
}
