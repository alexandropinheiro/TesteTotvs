namespace PDV.Infra.Setup
{
    public interface IDataBaseInitializer
    {
        bool ApplyMigrations();
        void Seed();
    }
}
