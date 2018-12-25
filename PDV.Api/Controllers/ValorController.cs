using Microsoft.AspNetCore.Mvc;
using PDV.Dominio;
using PDV.Dominio.ValorMonetario;
using PDV.Dominio.Venda;
using System;

namespace PDV.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValorController : Controller
    {
        private readonly IValorRepository _valorRepository;
        private readonly IUnitOfWork _uow;

        public ValorController(IValorRepository valorRepository, IUnitOfWork uow)
        {
            _valorRepository = valorRepository;
            _uow = uow;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var valor100 = new Valor { Id = Guid.NewGuid(), DescricaoValor = "R$100,00", TipoValor = TipoValor.Nota, ValorMonetario = 100 };
            _valorRepository.Gravar(valor100);

            var valor50 = new Valor { Id = Guid.NewGuid(), DescricaoValor = "R$50,00", TipoValor = TipoValor.Nota, ValorMonetario = 50 };
            _valorRepository.Gravar(valor50);

            var valor20 = new Valor { Id = Guid.NewGuid(), DescricaoValor = "R$20,00", TipoValor = TipoValor.Nota, ValorMonetario = 20 };
            _valorRepository.Gravar(valor20);

            var valor10 = new Valor { Id = Guid.NewGuid(), DescricaoValor = "R$10,00", TipoValor = TipoValor.Nota, ValorMonetario = 10 };
            _valorRepository.Gravar(valor10);

            var valor050 = new Valor { Id = Guid.NewGuid(), DescricaoValor = "R$0,50", TipoValor = TipoValor.Moeda, ValorMonetario = Convert.ToDecimal(0.5) };
            _valorRepository.Gravar(valor050);

            var valor010 = new Valor { Id = Guid.NewGuid(), DescricaoValor = "R$0,10", TipoValor = TipoValor.Moeda, ValorMonetario = Convert.ToDecimal(0.1) };
            _valorRepository.Gravar(valor010);

            var valor005 = new Valor { Id = Guid.NewGuid(), DescricaoValor = "R$0,05", TipoValor = TipoValor.Moeda, ValorMonetario = Convert.ToDecimal(0.05) };
            _valorRepository.Gravar(valor005);

            var valor001 = new Valor { Id = Guid.NewGuid(), DescricaoValor = "R$0,01", TipoValor = TipoValor.Moeda, ValorMonetario = Convert.ToDecimal(0.01) };
            _valorRepository.Gravar(valor001);

            _uow.Commit();

            return Ok();
        }
    }
}