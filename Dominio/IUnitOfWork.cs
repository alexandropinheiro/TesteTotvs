namespace PDV.Dominio
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
