using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDV.Dominio.Venda;
using PDV.Infra.Extensions;

namespace PDV.Infra.Mapping
{
    public class VendaMapping : EntityTypeConfiguration<Venda>
    {
        public override void Map(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(v => v.Id);                

            builder.Property(v => v.ValorTotal)
                .IsRequired();

            builder.Property(v => v.ValorRecebido)
                .IsRequired();

            builder.ToTable("Vendas");

            builder.HasMany(t => t.Trocos)
                .WithOne(v => v.Venda)
                .HasForeignKey(t => t.IdVenda);
        }
    }
}
