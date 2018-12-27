using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PDV.Infra.Context;
using System;
using System.IO;

namespace PDV.Testes.Setup
{
    public static class TestDbContextOptionsBuilder
    {
        public static DbContextOptions BuildOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PdvContext>();
            
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.development.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return optionsBuilder.Options;
        }
    }
}