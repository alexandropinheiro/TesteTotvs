using PDV.Dominio.Venda;
using PDV.Infra.Context;

namespace PDV.Infra.Repository
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(PdvContext context) : base(context)
        {
        }
    }
}
