﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PDV.Dominio.ValorMonetario;
using PDV.Dominio.Venda;
using PDV.Infra.Extensions;
using PDV.Infra.Mapping;
using System.IO;
namespace PDV.Infra.Context
{
    public class PdvContext : DbContext
    {
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Troco> Troco { get; set; }
        public DbSet<Valor> Valor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new VendaMapping());
            modelBuilder.AddConfiguration(new TrocoMapping());
            modelBuilder.AddConfiguration(new ValorMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
    