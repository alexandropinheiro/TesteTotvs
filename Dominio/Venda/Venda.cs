using PDV.Dominio.Base;
using PDV.Dominio.ValorMonetario;
using System;
using System.Collections.Generic;

namespace PDV.Dominio.Venda
{
    public class Venda : EntidadeBase
    {
        public decimal ValorTotal { get; set; }
        public decimal ValorRecebido { get; set; }

        public Venda(decimal valorTotal, decimal valorRecebido)
        {
            ValorTotal = valorTotal;
            ValorRecebido = valorRecebido;

            Trocos = new List<Troco>();
        }

        public ICollection<Troco> Trocos { get; set; }

        public decimal ValorDoTroco
        {
            get
            {
                return ValorRecebido - ValorTotal;
            }
        }

        public void AdicionarListaDeTrocos(List<Troco> trocos)
        {
            foreach (var troco in trocos)
                Trocos.Add(troco);
        }

        public void AdicionarTroco(Guid idValor, int qtdValor, Valor valor)
        {
            Trocos.Add(new Troco { Id = Guid.NewGuid(), IdValor = idValor, QuantidadeValor = qtdValor, Valor = valor });
        }

        public void AlterarValores(decimal valorTotal, decimal valorRecebido)
        {
            ValorTotal = valorTotal;
            ValorRecebido = valorRecebido;
        }

        public string DescricaoTroco()
        {
            if (ValorDoTroco < 0)
                return "Valor recebido insuficiente";

            if (ValorDoTroco == 0)
                return "Não há troco";

            var descricaoTroco = "";
            var i = 1;
            foreach(var troco in Trocos)
            {
                var plural = troco.QuantidadeValor > 1 ? "s" : string.Empty;
                var conectivo = Trocos.Count > 1 && i == Trocos.Count ? " e " : ", ";

                descricaoTroco += 
                    string.IsNullOrEmpty(descricaoTroco) ?
                        $"{troco.QuantidadeValor} {troco.Valor.TipoValor.ToString().ToLower()}{plural} de {troco.Valor.DescricaoValor}" :
                        $"{conectivo}{troco.QuantidadeValor} {troco.Valor.TipoValor.ToString().ToLower()}{plural} de {troco.Valor.DescricaoValor}";
                i++;
            }

            return $"Entregar {descricaoTroco}";
        }
    }
}
