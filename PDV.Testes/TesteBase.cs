using PDV.Infra.Context;
using PDV.Infra.Setup;
using PDV.Testes.Setup;

namespace PDV.Testes
{
    public abstract class TesteBase
    {
        protected PdvContext Context;
        protected IDatabaseInitializer databaseInitializer;        

        protected void Setup()
        {
            Context = TestDbContextBuilder.BuildDbContext();
            databaseInitializer = new DatabaseInitializer(Context);
            
            databaseInitializer.ApplyMigrationsIfPossible();
            databaseInitializer.Seed();
        }
                
        protected void TearDown()
        {
            Context.Database.EnsureDeleted();
            databaseInitializer = null;
        }
    }
}