using PDV.Dominio;
using PDV.Infra.Context;

namespace PDV.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PdvContext _contexto;

        public UnitOfWork(PdvContext contexto)
        {
            _contexto = contexto;
        }

        public bool Commit()
        {
            return _contexto.SaveChanges() > 0;
        }        
    }
}
