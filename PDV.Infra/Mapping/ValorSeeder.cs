using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDV.Dominio.ValorMonetario;
using System;

namespace PDV.Infra.Mapping
{
    public static class ValorSeeder
    {
        public static void Seed(this EntityTypeBuilder<Valor> builder)
        {
            builder.HasData(
                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Nota,
                    ValorMonetario = 100,
                    DescricaoValor = "R$100,00"
                },
                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Nota,
                    ValorMonetario = 50,
                    DescricaoValor = "R$50,00"
                },
                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Nota,
                    ValorMonetario = 20,
                    DescricaoValor = "R$20,00"
                },
                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Nota,
                    ValorMonetario = 10,
                    DescricaoValor = "R$10,00"
                },
                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Moeda,
                    ValorMonetario = Convert.ToDecimal(0.5),
                    DescricaoValor = "R$0,50"
                },
                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Moeda,
                    ValorMonetario = Convert.ToDecimal(0.1),
                    DescricaoValor = "R$0,10"
                },
                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Moeda,
                    ValorMonetario = Convert.ToDecimal(0.05),
                    DescricaoValor = "R$0,05"
                },
                new Valor
                {
                    Id = Guid.NewGuid(),
                    TipoValor = TipoValor.Moeda,
                    ValorMonetario = Convert.ToDecimal(0.01),
                    DescricaoValor = "R$0,01"
                }
            );
        }
    }
}
