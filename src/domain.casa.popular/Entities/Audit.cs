namespace domain.casa.popular.Entities
{
    using System;

    public class Audit
    {
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsActive { get; set; }
    }
}
