using PDV.Dominio.Venda;
using PDV.Infra.Mapping;
using PDV.Servico.Services;
using System;
using Xunit;

namespace PDV.Testes.Service
{
    public class VendaServiceTest
    {
        private readonly IVendaService _service;

        public VendaServiceTest()
        {
            _service = new VendaService();
        }

        [Theory]
        [InlineData(80, 120, "Entregar 2 notas de R$20,00.")]
        [InlineData(81, 120, "Entregar 1 nota de R$20,00, 1 nota de R$10,00 e 18 moedas de R$0,50.")]
        [InlineData(100, 230, "Entregar 1 nota de R$100,00, 1 nota de R$20,00 e 1 nota de R$10,00.")]
        [InlineData(100, 100, "Não há troco.")]
        [InlineData(100, 99, "Valor recebido insuficiente.")]
        public void CalcularTrocos(decimal valorTotal, decimal valorRecebido, string retorno)
        {
            var vendaFactory = new VendaFactory(valorTotal, valorRecebido);
            try
            {
                var venda = vendaFactory.Criar();
                var valores = ValorSeeder.RetornaListaValores();
                _service.CalcularTroco(venda, valores);

                Assert.Equal(retorno, venda.DescricaoTroco());
            }
            catch(Exception e)
            {
                Assert.Equal(retorno, e.Message);
            }
            
        }

    }
}
