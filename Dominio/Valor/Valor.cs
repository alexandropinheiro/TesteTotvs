using PDV.Dominio.Base;
using PDV.Dominio.Venda;
using System.Collections.Generic;

namespace PDV.Dominio.ValorMonetario
{
    public class Valor : EntidadeBase
    {
        public string DescricaoValor { get; set; }
        public decimal ValorMonetario { get; set; }
        public TipoValor TipoValor { get; set; }

        public ICollection<Troco> Troco { get; set; }

        public string DescricaoTipoValor {
            get {
                return TipoValor == TipoValor.Nota ? "Nota" : "Moeda";
            }
        }
    }
}