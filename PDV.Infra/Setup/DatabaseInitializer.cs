using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using PDV.Infra.Context;
using PDV.Infra.Mapping;

namespace PDV.Infra.Setup
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly PdvContext _context;

        public DatabaseInitializer(PdvContext context)
        {
            _context = context;
        }

        public virtual bool ApplyMigrationsIfPossible()
        {
            var applied = _context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = _context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            var allMigrationsApplied = !total.Except(applied).Any();

            if (allMigrationsApplied) return false;
            
            if (!_context.Database.EnsureCreated())
                _context.Database.Migrate();

            return true;
        }

        public virtual void Seed()
        {
            if (!_context.Valor.Any())
            {                
                _context.AddRange(ValorSeeder.RetornaListaValores());
                _context.SaveChanges();
            }
        }
    }
}