using PDV.Dominio.Base;
using PDV.Dominio.ValorMonetario;
using System;

namespace PDV.Dominio.Venda
{
    public class Troco : EntidadeBase
    {
        public Guid IdVenda { get; set; }
        public Guid IdValor { get; set; }
        public int QuantidadeValor { get; set; }

        public Venda Venda { get; set; }
        public Valor Valor { get; set; }
    }
}
