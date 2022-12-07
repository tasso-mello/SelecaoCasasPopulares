namespace repository.casa.popular.Configurations
{
    using domain.casa.popular.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasIndex(i => i.Id).IsUnique();

            builder.Property(p => p.Nome).IsRequired().HasMaxLength(150);
            
            builder.Property(p => p.Idade).IsRequired();

            builder.Property(p => p.Sexo).IsRequired().HasMaxLength(1);

            builder.Property(i => i.Salario).IsRequired().HasDefaultValue(0);

            builder.ToTable("Pessoas");
        }
    }
}
