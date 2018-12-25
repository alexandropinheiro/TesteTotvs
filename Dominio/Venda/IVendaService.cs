using PDV.Dominio.ValorMonetario;
using System.Collections.Generic;

namespace PDV.Dominio.Venda
{
    public interface IVendaService
    {
        void CalcularTroco(Venda venda, List<Valor> valoresParaTroco);
    }
}
