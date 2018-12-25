using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using PDV.Dominio.ValorMonetario;
using PDV.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PDV.Infra.Setup
{
    public class DatabaseInitializer : IDataBaseInitializer
    {
        private readonly PdvContext _context;

        public DatabaseInitializer(PdvContext context)
        {
            _context = context;
        }

        public virtual bool ApplyMigrations()
        {
            var applied = _context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = _context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            var allMigrationsApplied = !total.Except(applied).Any();

            if (allMigrationsApplied) return false;

            _context.Database.Migrate();
            return true;
        }

        public virtual void Seed()
        {
            var valores = new List<Valor>
            {
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
            };

            _context.Set<Valor>().AddRange(valores);
            _context.SaveChanges();
        }
    }
}
