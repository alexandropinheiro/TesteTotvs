using Microsoft.Data.Sqlite;
using PDV.Infra.Context;

namespace PDV.Testes.Setup
{
    public static class TestDbContextBuilder
    {
        public static PdvContext BuildDbContext(SqliteConnection sqliteConnection)
        {
            return new PdvContext();// estDbContextOptionsBuilder.BuildOptions(sqliteConnection));
        }
    }
}
