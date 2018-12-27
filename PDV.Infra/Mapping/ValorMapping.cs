using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDV.Dominio.ValorMonetario;
using PDV.Infra.Extensions;

namespace PDV.Infra.Mapping
{
    public class ValorMapping : EntityTypeConfiguration<Valor>
    {
        public override void Map(EntityTypeBuilder<Valor> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DescricaoValor)
                .HasMaxLength(8)
                .HasColumnType("varchar(8)")
                .IsRequired();

            builder.Property(t => t.ValorMonetario)
                .IsRequired();

            builder.Seed();

            builder.ToTable("Valores");
        }
    }
}
