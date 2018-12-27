using PDV.Dominio;
using PDV.Dominio.Venda;

using PDV.Infra;
using PDV.Infra.Repository;
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

        [Fact]
        public void CalcularTrocos()
        {

        }
    }
}
