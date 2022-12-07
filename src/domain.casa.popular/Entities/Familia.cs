namespace domain.casa.popular.Entities
{
    using System;

    public class Familia : Audit
    {
        public Guid Id { get; set; }
        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}