using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PDV.Infra.Context;
using System.IO;

namespace PDV.Testes.Setup
{
    public static class TestDbContextOptionsBuilder
    {
        public static DbContextOptions BuildOptions(SqliteConnection sqliteConnection)
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PdvContext>();

            optionsBuilder.UseSqlServer(sqliteConnection);
            // config.GetConnectionString("DefaultConnection")
            return optionsBuilder.Options;
        }
    }
}
