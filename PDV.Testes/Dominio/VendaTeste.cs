using PDV.Dominio.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PDV.Testes
{
    public class VendaTeste : BaseTeste
    {
        [Fact]
        public void AnalizandoValorDoTroco_Correto()
        {
            var venda = new Venda(70, 100)
            {
                Id = Guid.NewGuid()
            };

            Assert.Equal(30, venda.ValorDoTroco);
        }

        [Fact]
        public void AnalizandoDescricaoDoTrocoDuasNotas_Correto()
        {
            var venda = new Venda(70, 100)
            {
                Id = Guid.NewGuid()
            };

            var valor20 = Valores.FirstOrDefault(x => x.ValorMonetario == 20);
            var valor10 = Valores.FirstOrDefault(x => x.ValorMonetario == 10);
            var listaTrocos = new List<Troco>
            {
                new Troco {
                    Id = Guid.NewGuid(),
                    IdValor = valor20.Id,
                    IdVenda = venda.Id,
                    QuantidadeValor = 1,
                    Valor = valor20,
                    Venda = venda
                },
                new Troco
                {
                    Id = Guid.NewGuid(),
                    IdValor = valor10.Id,
                    IdVenda = venda.Id,
                    QuantidadeValor = 1,
                    Valor = valor10,
                    Venda = venda
                }
            };

            venda.AdicionarListaDeTrocos(listaTrocos);
            Assert.Equal("Entregar 1 nota de R$20,00 e 1 nota de R$10,00", venda.DescricaoTroco());
        }

        [Fact]
        public void AnalizandoDescricaoDoTroco_Correto()
        {
            var venda = new Venda(80, 100)
            {
                Id = Guid.NewGuid()
            };

            var valor = Valores.FirstOrDefault(x => x.ValorMonetario == 20);
            var idTroco = Guid.NewGuid();

            venda.AdicionarTroco(
                valor.Id,
                1,
                valor);

            Assert.Equal("Entregar 1 nota de R$20,00", venda.DescricaoTroco());
        }

        [Fact]
        public void AnalizandoValorInsuficiente()
        {
            var venda = new Venda(100, 90)
            {
                Id = Guid.NewGuid()
            };
                        
            Assert.Equal("Valor recebido insuficiente", venda.DescricaoTroco());
        }

        [Fact]
        public void AnalizandoValorTotaleRecebidoIguais()
        {
            var venda = new Venda(100, 100)
            {
                Id = Guid.NewGuid()
            };

            Assert.Equal("N�o h� troco", venda.DescricaoTroco());
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}