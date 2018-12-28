using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PDV.Api.ViewModels;
using PDV.Dominio;
using PDV.Dominio.DTO;
using PDV.Dominio.ValorMonetario;
using PDV.Dominio.Venda;
using System;
using System.Collections.Generic;

namespace PDV.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VendaController : Controller
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IValorRepository _valorRepository;
        private readonly IVendaService _vendaService;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        private readonly List<Valor> valoresParaTroco = new List<Valor>();

        public VendaController(IVendaRepository vendaRepository,
                               IValorRepository valorRepository,
                               IVendaService vendaService,
                               IUnitOfWork uow,
                               IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _valorRepository = valorRepository;
            _vendaService = vendaService;
            _uow = uow;
            _mapper = mapper;

            valoresParaTroco = _valorRepository.ObterTodos();
        }

        // GET api/venda/gravar
        [HttpPost]
        [Route("gravar")]
        public IActionResult Gravar([FromBody]VendaViewModel vendaViewModel)
        {
            try
            {
                var vendaDTO = _mapper.Map<VendaDTO>(vendaViewModel);

                var vendaFactory = new VendaFactory(vendaDTO.ValorTotal, vendaDTO.ValorRecebido);
                var venda = vendaFactory.Criar();
                
                _vendaService.CalcularTroco(venda, valoresParaTroco);
                _vendaRepository.Gravar(venda);

                _uow.Commit();

                return Ok(venda.DescricaoTroco());

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}