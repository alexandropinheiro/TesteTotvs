using PDV.Dominio.ValorMonetario;
using PDV.Infra.Context;

namespace PDV.Infra.Repository
{
    public class ValorRepository : Repository<Valor>, IValorRepository
    {
        public ValorRepository(PdvContext context) : base(context)
        {
        }
    }
}
