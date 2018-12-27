using PDV.Dominio.ValorMonetario;
using PDV.Dominio.Venda;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PDV.Servico.Services
{
    public class VendaService : IVendaService
    {
        public void CalcularTroco(Venda venda, List<Valor> valoresParaTroco)
        {   
            var valorDoTroco = venda.ValorDoTroco;
            foreach(var valor in valoresParaTroco.OrderByDescending(v => v.ValorMonetario))
            {
                var qtdNotas = Math.Truncate(valorDoTroco / valor.ValorMonetario);

                if (qtdNotas > 0)
                    venda.AdicionarTroco(valor.Id, Convert.ToInt16(qtdNotas), valor);

                valorDoTroco -= (qtdNotas * valor.ValorMonetario);
            }
        }
    }
}
