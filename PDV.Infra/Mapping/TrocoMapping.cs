using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDV.Dominio.Venda;
using PDV.Infra.Extensions;

namespace PDV.Infra.Mapping
{
    public class TrocoMapping : EntityTypeConfiguration<Troco>
    {
        public override void Map(EntityTypeBuilder<Troco> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.IdValor)
                .IsRequired();

            builder.Property(t => t.IdVenda)
                .IsRequired();

            builder.Property(t => t.QuantidadeValor)
                .IsRequired();

            builder.ToTable("Trocos");

            builder.HasOne(t => t.Valor)
                .WithMany(v => v.Troco)
                .HasForeignKey(t => t.IdValor);

            builder.HasOne(t => t.Venda)
                .WithMany(v => v.Trocos)
                .HasForeignKey(t => t.IdVenda);

        }
    }    
}
