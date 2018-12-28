using PDV.Dominio.ValorMonetario;
using PDV.Dominio.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PDV.Testes
{
    public class VendaTeste
    {
        private List<Valor> Valores;

        public VendaTeste()
        {            
            Valores = new List<Valor>
            {
                new Valor { Id = Guid.NewGuid(), TipoValor = TipoValor.Nota, ValorMonetario = 100, DescricaoValor = "R$100,00" },
                new Valor { Id = Guid.NewGuid(), TipoValor = TipoValor.Nota, ValorMonetario = 50, DescricaoValor = "R$50,00" },
                new Valor { Id = Guid.NewGuid(), TipoValor = TipoValor.Nota, ValorMonetario = 20, DescricaoValor = "R$20,00" },
                new Valor { Id = Guid.NewGuid(), TipoValor = TipoValor.Nota, ValorMonetario = 10, DescricaoValor = "R$10,00" },
                new Valor { Id = Guid.NewGuid(), TipoValor = TipoValor.Moeda, ValorMonetario = Convert.ToDecimal(0.5), DescricaoValor = "R$0,50" },
                new Valor { Id = Guid.NewGuid(), TipoValor = TipoValor.Moeda, ValorMonetario = Convert.ToDecimal(0.1), DescricaoValor = "R$0,10" },
                new Valor { Id = Guid.NewGuid(), TipoValor = TipoValor.Moeda, ValorMonetario = Convert.ToDecimal(0.05), DescricaoValor = "R$0,05" },
                new Valor { Id = Guid.NewGuid(), TipoValor = TipoValor.Moeda, ValorMonetario = Convert.ToDecimal(0.01), DescricaoValor = "R$0,01" }
            };
        }

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
            Assert.Equal("Entregar 1 nota de R$20,00 e 1 nota de R$10,00.", venda.DescricaoTroco());
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

            Assert.Equal("Entregar 1 nota de R$20,00.", venda.DescricaoTroco());
        }

        [Fact]
        public void AnalizandoValorInsuficiente()
        {
            var venda = new Venda(100, 90)
            {
                Id = Guid.NewGuid()
            };
                        
            Assert.Equal("Valor recebido insuficiente.", venda.DescricaoTroco());
        }

        [Fact]
        public void AnalizandoValorTotaleRecebidoIguais()
        {
            var venda = new Venda(100, 100)
            {
                Id = Guid.NewGuid()
            };

            Assert.Equal("Não há troco.", venda.DescricaoTroco());
        }
        
        [Fact]
        public void ExecutandoVendaFactory()
        {
            var valorTotal = 110;
            var valorRecebido = 150;

            var vendaFactory = new VendaFactory(valorTotal, valorRecebido);
            var venda = vendaFactory.Criar();

            Assert.Equal(valorTotal, venda.ValorTotal);
            Assert.Equal(valorRecebido, venda.ValorRecebido);
            Assert.Equal((valorRecebido - valorTotal), venda.ValorDoTroco);
        }

        [Fact]
        public void ExecutandoVendaFactoryErroValorInsuficiente()
        {
            var vendaFactory = new VendaFactory(110, 100);

            try
            {
                var venda = vendaFactory.Criar();
                Assert.Null(venda);
            }catch(Exception e)
            {
                Assert.Equal("Valor recebido insuficiente.", e.Message);
            }
        }

        [Fact]
        public void AlterarVenda()
        {
            var valorTotal = 110;
            var valorRecebido = 150;

            var vendaFactory = new VendaFactory(valorTotal, valorRecebido);
            var venda = vendaFactory.Criar();
            Assert.Equal(40, venda.ValorDoTroco);

            venda.AlterarValores(170, 250);
            Assert.Equal(80, venda.ValorDoTroco);
        }        
    }
}
